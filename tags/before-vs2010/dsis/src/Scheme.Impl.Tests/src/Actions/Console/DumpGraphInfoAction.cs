using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphInfoAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                 Create(Keys.Graph<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraph<Q> gr = Keys.Graph<Q>().Get(input);

      Logger.Instance(input).Write("Graph: Nodes {0}, Edges {1}", gr.NodesCount, gr.EdgesCount);
    }
  }
}
