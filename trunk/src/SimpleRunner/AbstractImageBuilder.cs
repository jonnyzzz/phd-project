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

namespace DSIS.SimpleRunner
{
  public abstract class AbstractImageBuilder<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  { 
    private readonly List<IAbstractImageBuilderListener<T,Q>> myListeners = new List<IAbstractImageBuilderListener<T, Q>>();
    private readonly List<IProvideExtendedListener> myExtensions = new List<IProvideExtendedListener>();

    protected abstract Pair<IDiscreteSystemInfo, T> CreateInfos();
    protected abstract ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods();
    protected abstract long[] Subdivide { get;}
    protected abstract IGraphWithStrongComponent<Q> CreateGraph(T system);
    protected abstract bool PerformStep(CellProcessorContext<Q, Q> ctx, AbstractImageBuilderContext<Q> cx, long stepCount);
    protected virtual IEnumerable<IStrongComponentInfo> FilterStrongComponents(IGraphStrongComponents<Q> info, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      return info.Components;
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

    public void AddListener(IAbstractImageBuilderListener<T,Q> listener)
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

    public void RemoveListener(IAbstractImageBuilderListener<T,Q> listener)
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

    protected virtual void DoConstruct(ICellImageBuilder<Q> builder, ICellImageBuilderSettings settings, IProgressInfo progress)
    {
      Pair<IDiscreteSystemInfo, T> infos = CreateInfos();
      IGraphWithStrongComponent<Q> graph = CreateGraph(infos.Second);

      AbstractImageBuilderContext<Q> cx = new AbstractImageBuilderContext<Q>(infos.First, builder, settings);

      OnComputationStarted(infos.Second, cx);

      ICellCoordinateSystemConverter<Q, Q> conv = infos.Second.Subdivide(Subdivide);
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

      SymbolicImageConstructionProcess<Q, Q> proc = new SymbolicImageConstructionProcess<Q, Q>();

      IGraphStrongComponents<Q> comps = null;
      long stepCount = 0;
      while(PerformStep(ctx, cx, stepCount))
      {
        OnStepStarted((T) ctx.Converter.FromSystem, cx);

        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);

        OnGraphConstructed(graph, (T) ctx.Converter.ToSystem, cx);

        comps = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        OnGraphComponentsConstructed(comps, graph, (T)ctx.Converter.ToSystem, cx);

        OnStepFinished(comps, graph, (T)ctx.Converter.ToSystem, cx);

        stepCount++;

        IEnumerable<IStrongComponentInfo> componentsId = FilterStrongComponents(comps, graph, (T)ctx.Converter.ToSystem, cx);

        graph = new TarjanGraph<Q>(ctx.Converter.ToSystem);
        conv = ctx.Converter.ToSystem.Subdivide(Subdivide);

        ctx = ctx.CreateNextContext(comps.GetCoordinates(componentsId), conv, new GraphCellImageBuilder<Q>(graph));

      }
      OnComputationFinished(comps, graph, (T)ctx.Converter.ToSystem, cx);
    }

    protected virtual void OnComputationStarted(T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.ComputationStarted(system, cx);
      }
    }

    protected virtual void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.OnStepStarted(system, cx);
      }
    }

    protected virtual void OnGraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.GraphConstructed(graph, system, cx);
      }
    }

    protected virtual void OnGraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.GraphComponentsConstructed(comps, graph, system, cx);
      }
    }

    protected virtual void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.OnStepFinished(comps, graph, system, cx);
      }
    }

    protected virtual void OnComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
      {
        listener.ComputationFinished(comps, graph, system, cx);
      }
    }
  }
}