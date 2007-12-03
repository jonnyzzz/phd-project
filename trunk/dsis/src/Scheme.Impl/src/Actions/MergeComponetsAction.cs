using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class MergeComponetsAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return Col(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);
      CountEnumerable<Q> data = comps.GetCoordinates(new List<IStrongComponentInfo>(comps.Components));

      Keys.CellsEnumerationKey<Q>().Set(output, data);
    }    
  }
}