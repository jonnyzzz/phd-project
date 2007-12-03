using System;
using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphInfoAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return new ContextMissmatchCheck[] {
        Create(Keys.Graph<Q>())
      };
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphWithStrongComponent<Q> gr = Keys.Graph<Q>().Get(input);

      System.Console.Out.WriteLine("Graph: Nodes {0}, Edges {1}", gr.NodesCount, gr.EdgesCount);
    }
  }
}
