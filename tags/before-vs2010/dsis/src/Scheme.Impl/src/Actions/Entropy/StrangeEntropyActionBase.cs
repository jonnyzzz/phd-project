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
                     Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var graph = Keys.Graph<Q>().Get(input);
      var comps = Keys.GetGraphComponents<Q>().Get(input);
      var ps = GetParams(input);

      var measure = new StrangeEntropyEvaluator<Q>().Measure(graph, comps, ps);

      Keys.GraphMeasure<Q>().Set(output, measure);      
//      Keys.GraphEntropyKey.Set(output, measure);      
    }

    protected abstract StrangeEntropyEvaluatorParams GetParams(Context input);
  }
}