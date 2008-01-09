using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class EigenPerComoponentAction : IntegerCoordinateSystemActionBase2
  {
    private const double EPS = 1e-4;

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      double? value = null;
      foreach (IStrongComponentInfo info in comps.Components)
      {
        IGraph<Q> graph = comps.AsGraph(new IStrongComponentInfo[] {info});

        EigenEntropyEvaluatorImpl<Q> evaluator = new EigenEntropyEvaluatorImpl<Q>(EPS, graph);
        IGraphEntropy entropy = evaluator.ComputeEntropy();
        double ent = entropy.GetEntropy();

        if (value == null || value.Value < ent)
          value = ent;
      }

      Keys.GraphEntropyKey.Set(output, new GraphEntropy(value ?? double.NaN));
    }
  }
}