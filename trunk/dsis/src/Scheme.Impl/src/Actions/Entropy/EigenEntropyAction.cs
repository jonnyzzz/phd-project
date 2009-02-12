using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class EigenEntropyAction : IntegerCoordinateSystemActionBase3
  {
    private readonly EigenEntropyOptions myOptions;

    public EigenEntropyAction(EigenEntropyOptions options)
    {
      myOptions = options;
    }

    public EigenEntropyAction() : this(new EigenEntropyOptions())
    {
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var graph = Keys.GetGraphComponents<Q>().Get(input);
      var evaluator = new EigenEntropyEvaluatorImpl<Q>(myOptions.Eps, graph.AsGraph(graph.Components));

      IGraphMeasure<Q> entropy = new EigenEntropyMeasure<Q>(evaluator);
      Keys.GraphMeasure<Q>().Set(output, entropy);
    }
  }
}