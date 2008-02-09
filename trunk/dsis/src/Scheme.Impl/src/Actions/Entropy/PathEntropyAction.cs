using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Path;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class PathEntropyAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      PathBuilder<Q> path = new PathBuilder<Q>(comps);
      path.BuildPath();
      IGraphMeasure<Q> measure = path.Entropy();

      Keys.GraphMeasure<Q>().Set(output, measure);      
      Keys.GraphEntropyKey.Set(output, measure);      
    }    
  }
}