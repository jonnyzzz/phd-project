using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class EigenEntropyAction : IntegerCoordinateSystemActionBase3
  {
    private const double EPS = 1e-4;

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var graph = Keys.GraphComponents<Q>().Get(input);
      var evaluator = new EigenEntropyEvaluatorImpl<Q>(EPS, graph.AsGraph(graph.Components));

      IGraphMeasure<Q> entropy = new EigenEntropyMeasure<Q>(evaluator);
      Keys.GraphEntropyKey.Set(output, entropy);
      Keys.GraphMeasure<Q>().Set(output, entropy);
    }
  }
}