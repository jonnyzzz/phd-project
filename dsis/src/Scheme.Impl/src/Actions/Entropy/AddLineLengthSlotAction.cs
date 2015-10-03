using System.Collections.Generic;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class AddLineLengthSlotAction : ActionBase
  {
    private readonly string myKey;
    private readonly ILoopAction myLoopIndex;

    public AddLineLengthSlotAction(string key, ILoopAction loopIndex)
    {
      myKey = key;
      myLoopIndex = loopIndex;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(Keys.LineKey), Create(myLoopIndex.Key));
    }

    protected override void Apply(Context ctx, Context result)
    {
      var idx = myLoopIndex.Key.Get(ctx);
      var line = Keys.LineKey.Get(ctx);
      var slot = CurveLengthSlotHelper.Get(myKey, SlotStore.Get(ctx));

      slot.AddData(idx.Index, line.Count, line.Length);
    }
  }
}