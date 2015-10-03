using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class ClearCurveSlotAction : ActionBase
  {
    private readonly string myKey;

    public ClearCurveSlotAction(string key)
    {
      myKey = key;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      CurveLengthSlotHelper.Get(myKey, SlotStore.Get(ctx)).Clear();
    }
  }
}