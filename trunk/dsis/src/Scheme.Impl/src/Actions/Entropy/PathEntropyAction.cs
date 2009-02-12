using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Path;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class PathEntropyAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GetGraphComponents<Q>().Get(input);

      var path = new PathBuilder<Q>(comps);
      path.BuildPath();
      IGraphMeasure<Q> measure = path.Entropy();

      Keys.GraphMeasure<Q>().Set(output, measure);      
//      Keys.GraphEntropyKey.Set(output, measure);      
    }    
  }
}