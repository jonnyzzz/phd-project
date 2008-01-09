using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class EigenEntropyAction : IntegerCoordinateSystemActionBase2
  {
    private const double EPS = 1e-4;

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.Graph<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraph<Q> graph = Keys.Graph<Q>().Get(input);
      EigenEntropyEvaluatorImpl<Q> evaluator = new EigenEntropyEvaluatorImpl<Q>(EPS, graph);

      IGraphEntropy entropy = evaluator.ComputeEntropy();
      Keys.GraphEntropyKey.Set(output, entropy);
    }
  }
}