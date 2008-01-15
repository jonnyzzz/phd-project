using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Agregated;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Scheme.Impl
{
  public abstract class SimbolicImageBuildTestBase
  {
    protected abstract ISystemInfo SystemInfo { get;}
    protected abstract ISystemSpace SystemSpace { get;}

    protected ICellImageBuilderIntegerCoordinatesSettings Method;
    protected long[] MethodSubdivision;

    [SetUp]
    public virtual void SetUp()
    {
      Method = new BoxMethodSettings(0.1);
      MethodSubdivision = new long[] {2, 2 };
    }

    protected delegate void AddAssertActions(ActionBuilderAdapter ad, IAction leaf);

    protected virtual void DoTest(int steps, AddAssertActions addAssertActions)
    {
      DoTest(steps, delegate { }, addAssertActions);
    }

    protected virtual void DoTest(int steps, AddAssertActions loop, AddAssertActions addAssertActions)
    {
      ActionGraph agr = new ActionGraph();
      ActionBuilderAdapter gr = new ActionBuilderAdapter(agr);
      IAction system = new SystemInfoAction(SystemInfo, SystemSpace);

      IAction a5 = new ChainRecurrenctSimbolicImageAction();
      IAction method = new SetMethod(Method, MethodSubdivision);

      IAction a4 = gr.AddLine(
        system,
        new CreateCoordinateSystemAction(),
        new CreateInitialCellsAction(),
        new BuildSymbolicImageAction());

      gr.AddEdge(system, a4);
      gr.AddEdge(method, a4);
      gr.AddEdge(a4, a5);

      gr.AddEdge(a4, new DumpGraphInfoAction());
      gr.AddEdge(a5, new DumpGraphComponentsInfoAction());

      AgregateAction buildSI = new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            SymbolicImageConstructionStep build = new SymbolicImageConstructionStep();
            bld.AddEdge(bld.Start, build);
            bld.AddEdge(build, bld.End);
            ProxyAction b = new ProxyAction();
            ParallelAction b2 = new ParallelAction(new DumpGraphInfoAction(),
                                                  new DumpGraphComponentsInfoAction(),
                                                  new DumpMethodAction()
              );
            ProxyAction p = new ProxyAction();
            bld.AddEdge(build, b);
            bld.AddEdge(bld.Start, p);
            bld.AddEdge(p, b);
            bld.AddEdge(b, b2);

            loop(new ActionBuilderAdapter(bld), b);
          });

      IAction buildIS = new LoopAction(steps, buildSI);

      gr.AddEdge(a5, buildIS);
      gr.AddEdge(system, buildIS);
      gr.AddEdge(method, buildIS);

      addAssertActions(gr, buildIS);

      agr.Execute();
    }


    public class AssertGraphAction : IntegerCoordinateSystemActionBase2
    {
      public IConstraint GraphNodesConstraint;
      public IConstraint GraphEdgesConstraint;
      
      public IConstraint CompontentsCountConstraint;
      public IConstraint CompontentsNodesCountConstraint;

      protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
      {
        return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.Graph<Q>()), Create(Keys.GraphComponents<Q>()));
      }

      protected override void Apply<T, Q>(T system, Context input, Context output)
      {
        IGraph<Q> graph = Keys.Graph<Q>().Get(input);
        IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
        int nodesInComponents = CollectionUtil.Count(comps.GetNodes(new List<IStrongComponentInfo>(comps.Components)));

        Apply(GraphNodesConstraint, graph.NodesCount);
        Apply(GraphEdgesConstraint, graph.EdgesCount);        
        Apply(CompontentsCountConstraint, comps.ComponentCount);
        Apply(CompontentsNodesCountConstraint, nodesInComponents);
      }

      private static void Apply<T>(IConstraint constraint, T t)
      {
        if (constraint != null)
          Assert.That(t, constraint);
      }
    }
  }
}