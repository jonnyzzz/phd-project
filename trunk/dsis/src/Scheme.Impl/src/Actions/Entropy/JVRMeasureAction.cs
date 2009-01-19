using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMeasureAction : IntegerCoordinateSystemActionBase3
  {
    private readonly JVRMeasureOptions myOpts;

    public JVRMeasureAction() : this(new JVRMeasureOptions())
    {
    }

    public JVRMeasureAction(JVRMeasureOptions opts)
    {
      myOpts = opts;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.Graph<Q>()), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var graph = Keys.Graph<Q>().Get(input);
      var comps = Keys.GraphComponents<Q>().Get(input);

      var evaluator = new JVREvaluator<Q>(myOpts);
      var measure = evaluator.Measure(graph, comps);
      
      Keys.GraphMeasure<Q>().Set(output, measure);
//      Keys.GraphEntropyKey.Set(output, measure);
    }
  }
}