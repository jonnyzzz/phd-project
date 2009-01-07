using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class EigenPerComoponentAction : IntegerCoordinateSystemActionBase3
  {
    private const double EPS = 1e-4;

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      double? value = null;
      foreach (IStrongComponentInfo info in comps.Components)
      {
        IGraph<Q> graph = comps.AsGraph(new[] {info});

        var evaluator = new EigenEntropyEvaluatorImpl<Q>(EPS, graph);
        IGraphEntropy entropy = evaluator.ComputeEntropy();
        double ent = entropy.GetEntropy();

        if (value == null || value.Value < ent)
          value = ent;
      }

      Keys.GraphEntropyKey.Set(output, new GraphEntropy("Eigen entropy", value ?? double.NaN));
    }
  }
}