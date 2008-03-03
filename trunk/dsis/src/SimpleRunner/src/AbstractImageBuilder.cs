using System;
using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class AbstractImageBuilder<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly List<IAbstractImageBuilderListener<T, Q>> myListeners =
      new List<IAbstractImageBuilderListener<T, Q>>();

    private readonly List<IProvideExtendedListener> myExtensions = new List<IProvideExtendedListener>();
    private CreateSystem<T> myCreateSystem = null;
    private bool myUseUnsimmetric = false;

    protected abstract long[] Subdivide { get; }
    protected abstract T CreateCoordinateSystem(ISystemInfo info);
    protected abstract ISystemInfo CreateSystemInfo();
    protected abstract ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods();
    protected abstract IGraphWithStrongComponent<Q> CreateGraph(T system);

    protected abstract bool PerformStep(ICellProcessorContext<Q, Q> ctx, AbstractImageBuilderContext<Q> cx,
                                        long stepCount);

    protected virtual IEnumerable<IStrongComponentInfo> FilterStrongComponents(IGraphStrongComponents<Q> info,
                                                                               IGraph<Q> graph, T system,
                                                                               AbstractImageBuilderContext<Q> cx)
    {
      return info.Components;
    }

    public bool UseUnsimmetric
    {
      get { return myUseUnsimmetric; }
      set { myUseUnsimmetric = value; }
    }

    protected virtual long[] GetSubdivide(long step)
    {
      if (myUseUnsimmetric)
      {
        step %= Subdivide.Length;
        long d = Subdivide[step];

        long[] part = new long[Subdivide.Length];
        for (int i = 0; i < part.Length; i++)
        {
          part[i] = i == step ? d : 1;
        }
        return part;
      } 
      
      return Subdivide;      
    }

    internal CreateSystem<T> CreateSystem
    {
      get { return myCreateSystem; }
      set { myCreateSystem = value; }
    }

    protected virtual T CreateCoordinateSystemInternal(ISystemInfo info)
    {
      throw new Exception("Refactoring required. ISystemSpace!");
      /*
      if (myCreateSystem != null)
        return myCreateSystem(info.SystemSpace, info.SystemSpace.InitialSubdivision);
      else
        return CreateCoordinateSystem(info);
       */
    }

    protected virtual Pair<ISystemInfo, T> CreateInfos()
    {
      ISystemInfo info = CreateSystemInfo();
      return new Pair<ISystemInfo, T>(info, CreateCoordinateSystemInternal(info));
    }

    public virtual void ComputeAllMethods(IProgressInfo progress)
    {
      ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> methods = GetMethods();
      progress.Minimum = 0;
      progress.Maximum = methods.Count;
      foreach (Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings> pair in methods)
      {
        DoConstruct(pair.First, pair.Second, progress.SubProgress(1));
      }
    }

    public void AddListener(IAbstractImageBuilderListener<T, Q> listener)
    {
      IProvideExtendedListener ext = listener as IProvideExtendedListener;
      if (ext != null)
      {
        foreach (IAbstractImageBuilderListener<T, Q> builderListener in myListeners)
        {
          ext.AddListener(builderListener);
        }
        myExtensions.Add(ext);
      }
      myListeners.Add(listener);
      foreach (IProvideExtendedListener extension in myExtensions)
      {
        extension.AddListener(listener);
      }
    }

    public void RemoveListener(IAbstractImageBuilderListener<T, Q> listener)
    {
      IProvideExtendedListener ext = listener as IProvideExtendedListener;
      if (ext != null)
      {
        foreach (IAbstractImageBuilderListener<T, Q> builderListener in myListeners)
        {
          ext.RemoveListener(builderListener);
        }
        myExtensions.Remove(ext);
      }
      myListeners.Remove(listener);
      foreach (IProvideExtendedListener extension in myExtensions)
      {
        extension.RemoveListener(listener);
      }
    }

    protected delegate VoidDelegate WithListener(IAbstractImageBuilderListener<T, Q> listener);
    protected void Fire(WithListener listener)
    {
      List<VoidDelegate> post =new List<VoidDelegate>();
      foreach (IAbstractImageBuilderListener<T, Q> builderListener in myListeners)
      {
        VoidDelegate p = listener(builderListener);
        if (p != null)
        {
          post.Add(p);
        }
      }

      foreach (VoidDelegate voidDelegate in post)
      {
        voidDelegate();
      }
    }

    protected virtual void DoConstruct(ICellImageBuilder<Q> builder, ICellImageBuilderSettings settings,
                                       IProgressInfo progress)
    {
      Pair<ISystemInfo, T> infos = CreateInfos();
      IGraphWithStrongComponent<Q> graph = CreateGraph(infos.Second);

      AbstractImageBuilderContext<Q> cx = new AbstractImageBuilderContext<Q>(infos.First, builder, settings);

      OnComputationStarted(infos.Second, cx);


      long stepCount = 0;
      long[] subdivide = GetSubdivide(stepCount);
      ICellCoordinateSystemConverter<Q, Q> conv = infos.Second.Subdivide(subdivide);
      CellProcessorContext<Q, Q> ctx =
        new CellProcessorContext<Q, Q>(
          infos.Second.InitialSubdivision,
          conv,
          builder,
          new CellImageBuilderContext<Q>(
            infos.First,
            settings,
            conv.ToSystem, new GraphCellImageBuilder<Q>(graph)
            )
          );

      ICellProcessor<Q, Q> proc = CreateCellConstructionProcess();

      IGraphStrongComponents<Q> comps = null;

      IGraph<Q> prevGraph = graph;
      while (PerformStep(ctx, cx, stepCount))
      {
        OnStepStarted((T) ctx.Converter.FromSystem, cx, subdivide);

        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);

        OnGraphConstructed(graph, (T) ctx.Converter.ToSystem, cx);

        comps = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        OnGraphComponentsConstructed(comps, graph, (T) ctx.Converter.ToSystem, cx);

        OnStepFinished(comps, graph, (T) ctx.Converter.ToSystem, cx);

        stepCount++;

        IEnumerable<IStrongComponentInfo> componentsId =
          FilterStrongComponents(comps, graph, (T) ctx.Converter.ToSystem, cx);

        prevGraph = graph;
        graph = new TarjanGraph<Q>(ctx.Converter.ToSystem);
        conv = ctx.Converter.ToSystem.Subdivide(subdivide = GetSubdivide(stepCount));

        ctx = ctx.CreateNextContext(comps.GetCoordinates(new List<IStrongComponentInfo>(componentsId)), conv, new GraphCellImageBuilder<Q>(graph));
      }

      OnComputationFinished(comps, prevGraph, (T)prevGraph.CoordinateSystem, cx);
    }

    protected virtual ICellProcessor<Q, Q> CreateCellConstructionProcess()
    {
      return new SymbolicImageConstructionProcess<Q, Q>();
//      return new ThreadedSymbolicImageConstructionProcess<Q, Q>();
    }

    protected virtual void OnComputationStarted(T system, AbstractImageBuilderContext<Q> cx)
    {
      List<VoidDelegate> post = new List<VoidDelegate>();
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        VoidDelegate d = listener.ComputationStartedC(system, cx, myUseUnsimmetric);
        if (d != null)
        {
          post.Add(d);
        }
      }

      foreach (VoidDelegate voidDelegate in post)
      {
        voidDelegate();
      }
    }

    protected virtual void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      Fire(delegate(IAbstractImageBuilderListener<T, Q> listener)
             {
               return listener.OnStepStartedC(system, cx, (long[]) subdivide.Clone());
             });
    }

    protected virtual void OnGraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      Fire(delegate(IAbstractImageBuilderListener<T, Q> listener)
             {
               return listener.GraphConstructedC(graph, system, cx);
             });
    }

    protected virtual void OnGraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                        AbstractImageBuilderContext<Q> cx)
    {
      Fire(delegate(IAbstractImageBuilderListener<T, Q> listener)
             {
               return listener.GraphComponentsConstructedC(comps, graph, system, cx);
             });
    }

    protected virtual void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                          AbstractImageBuilderContext<Q> cx)
    {
      Fire(delegate(IAbstractImageBuilderListener<T, Q> listener)
             {
               return listener.OnStepFinishedC(comps, graph, system, cx);
             });
    }

    protected virtual void OnComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                 AbstractImageBuilderContext<Q> cx)
    {
      Fire(delegate(IAbstractImageBuilderListener<T, Q> listener)
      {
        return listener.ComputationFinishedC(comps, graph, system, cx);
      });
    }
  }
}