using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMeasureAction : IntegerCoordinateSystemActionBase2
  {
    private readonly JVRMeasureOptions myOpts;

    public JVRMeasureAction(JVRMeasureOptions opts)
    {
      myOpts = opts;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.Graph<Q>()), Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      var graph = Keys.Graph<Q>().Get(input);
      var comps = Keys.GetGraphComponents<Q>().Get(input);

      var evaluator = CreateEvaluator<Q>(myOpts, input);
      var measure = evaluator.Measure(graph, comps);
      
      Keys.GraphMeasure<Q>().Set(output, measure);
//      Keys.GraphEntropyKey.Set(output, measure);
    }

    protected virtual JVREvaluator<Q> CreateEvaluator<Q>(JVRMeasureOptions opts, Context ctx) 
      where Q : ICellCoordinate
    {
      return new JVREvaluator<Q>(myOpts);
    }
  }
}