using System.Collections.Generic;
using System.Linq;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Agregated;
using DSIS.Scheme.Impl.Actions.Console;
using NUnit.Framework;

namespace DSIS.Scheme.Impl.Tests
{
  public abstract class SimbolicImageBuildTestBase
  {
    protected abstract ISystemInfo SystemInfo { get; }
    protected abstract ISystemSpace SystemSpace { get; }

    protected ICellImageBuilderIntegerCoordinatesSettings Method;
    protected long[] MethodSubdivision;

    [SetUp]
    public virtual void SetUp()
    {
      Method = new BoxMethodSettings(0.1);
      MethodSubdivision = new long[] {2, 2};
    }

    protected delegate void AddAssertActionsLoop(ILoopAction loop, ActionBuilderAdapter ad, IAction leaf);

    protected delegate void AddAssertActions(ActionBuilderAdapter ad, IAction leaf);

    protected virtual void DoTest(int steps, AddAssertActions addAssertActions)
    {
      DoTest(steps, delegate { }, addAssertActions);
    }

    protected virtual void DoTest(int steps, AddAssertActionsLoop loop, AddAssertActions addAssertActions)
    {
      var agr = new ActionGraph();
      var gr = new ActionBuilderAdapter(agr);
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

      IAction buildIS = new LoopAction("",
                                       steps,
                                       x => new AgregateAction(
                                              delegate(IActionGraphPartBuilder bld)
                                                {
                                                  var build = new SymbolicImageConstructionStep();
                                                  bld.AddEdge(bld.Start, build);
                                                  bld.AddEdge(build, bld.End);
                                                  var b = new ProxyAction();
                                                  var b2 = new ParallelAction(new DumpGraphInfoAction(),
                                                                              new DumpGraphComponentsInfoAction(),
                                                                              new DumpMethodAction()
                                                    );
                                                  var p = new ProxyAction();
                                                  bld.AddEdge(build, b);
                                                  bld.AddEdge(bld.Start, p);
                                                  bld.AddEdge(p, b);
                                                  bld.AddEdge(b, b2);

                                                  loop(x, new ActionBuilderAdapter(bld), b);
                                                }));

      gr.AddEdge(a5, buildIS);
      gr.AddEdge(system, buildIS);
      gr.AddEdge(method, buildIS);

      addAssertActions(gr, buildIS);

      agr.Execute();
    }


    public class AssertGraphAction : IntegerCoordinateSystemActionBase3
    {
      public IConstraint GraphNodesConstraint;
      public IConstraint GraphEdgesConstraint;

      public IConstraint CompontentsCountConstraint;
      public IConstraint CompontentsNodesCountConstraint;

      protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
      {
        return ColBase(base.Check<T, Q>(ctx), Create(Keys.Graph<Q>()), Create(Keys.GetGraphComponents<Q>()));
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        IGraph<Q> graph = Keys.Graph<Q>().Get(input);
        IGraphStrongComponents<Q> comps = Keys.GetGraphComponents<Q>().Get(input);
        int nodesInComponents = comps.GetNodes(comps.Components).Count();

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