using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class ChainRecurrenctSimbolicImageAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return new[] { Create(Keys.Graph<Q>()) };     
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IProgressInfo info = NullProgressInfo.INSTANCE;
      IGraph<Q> graph = Keys.Graph<Q>().Get(input);
      IGraphStrongComponents<Q> comps = graph.ComputeStrongComponents(info);

      Keys.GraphComponents<Q>().Set(output, comps);
    }    
  }
}