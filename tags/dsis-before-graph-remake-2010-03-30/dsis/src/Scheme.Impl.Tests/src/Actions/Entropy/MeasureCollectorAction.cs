using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class MeasureCollectorAction : IntegerCoordinateSystemActionBase2
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      throw new System.NotImplementedException();
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return base.Check<T, Q>(system, ctx);
    }
  }
}