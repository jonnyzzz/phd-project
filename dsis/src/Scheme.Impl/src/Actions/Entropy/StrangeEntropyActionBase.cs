using System.Collections.Generic;
using System.Linq;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public abstract class StrangeEntropyActionBase : IntegerCoordinateComponentsActionBase
  {
    protected override IEnumerable<ContextMissmatchCheck> Check<T, Q, TNode>(T system, Context ctx, IReadonlyGraphStrongComponents<Q, TNode> comps)
    {
      return ColBase(base.Check(system, ctx, comps).ToArray(),
                     Create(Keys.Graph<Q>()),
                     Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q, TNode>(T system, Context input, Context output, IReadonlyGraphStrongComponents<Q, TNode> components)
    {
      var ps = GetParams(input);

      var measure = new StrangeEntropyEvaluator<Q, TNode>().Measure(components.UnderlyingGraph, components, ps);

      Keys.GraphMeasure<Q>().Set(output, measure);      
//      Keys.GraphEntropyKey.Set(output, measure);      
    }

    protected abstract StrangeEntropyEvaluatorParams GetParams(Context input);
  }
}