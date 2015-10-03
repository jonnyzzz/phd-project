using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class MergeComponetsAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var comps = Keys.GetGraphComponents<Q>().Get(input);
      var data = comps.Accessor(comps.Components).GetCoordinates();

      Keys.CellsEnumerationKey<Q>().Set(output, data);
    }    
  }
}