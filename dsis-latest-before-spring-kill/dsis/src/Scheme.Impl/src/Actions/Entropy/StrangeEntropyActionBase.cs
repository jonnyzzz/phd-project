using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public abstract class StrangeEntropyActionBase : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.Graph<Q>()),
                     Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraph<Q> graph = Keys.Graph<Q>().Get(input);
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
      StrangeEntropyEvaluatorParams ps = GetParams(input);

      IGraphMeasure<Q> measure = new StrangeEntropyEvaluator<Q>().Measure(graph, comps, ps);

      Keys.GraphMeasure<Q>().Set(output, measure);      
      Keys.GraphEntropyKey.Set(output, measure);      
    }

    protected abstract StrangeEntropyEvaluatorParams GetParams(Context input);
  }
}