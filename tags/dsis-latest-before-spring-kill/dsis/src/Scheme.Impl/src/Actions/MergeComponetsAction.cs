using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class MergeComponetsAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
      var data = comps.GetCoordinates(comps.Components);

      Keys.CellsEnumerationKey<Q>().Set(output, data);
    }    
  }
}