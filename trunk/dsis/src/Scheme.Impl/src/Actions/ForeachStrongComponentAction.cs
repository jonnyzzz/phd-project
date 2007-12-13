using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Impl.Actions
{
  public class ForeachStrongComponentAction : IntegerCoordinateSystemActionBase2
  {
    private readonly IAction myBody;

    public ForeachStrongComponentAction(IAction body)
    {
      myBody = body;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        ActionGraph ag = new ActionGraph();
        UpdateContextAction ac = new UpdateContextAction(
          delegate(Context _, Context ctx)
            {
              IGraphStrongComponents<Q> oneComponent =
                new OneComponentsGraphAdapter<Q>(comps, info);

              IGraphWithStrongComponent<Q> graph =
                oneComponent.AsGraphWithStrongComponents(new IStrongComponentInfo[] {info});

              ctx.AddAll(input);

              Keys.Graph<Q>().Set(ctx, graph);
              Keys.GraphComponents<Q>().Set(ctx, graph.ComputeStrongComponents(NullProgressInfo.INSTANCE));
            });

        UpdateContextAction save = new UpdateContextAction(
          delegate(Context @in, Context _) { output.AddAll(@in); });

        ag.AddEdge(ac, myBody);
        ag.AddEdge(myBody, save);

        ag.Execute();
      }
    }
  }
}