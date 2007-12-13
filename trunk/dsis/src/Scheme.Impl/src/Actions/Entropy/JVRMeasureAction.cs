using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMeasureAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.Graph<Q>()), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphWithStrongComponent<Q> graph = Keys.Graph<Q>().Get(input);
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      JVREvaluator<Q> evaluator = new JVREvaluator<Q>();
      IGraphMeasure<Q> measure = evaluator.Measure(graph, comps);
      Keys.GraphMeasure<Q>().Set(output, measure);
    }
  }
}