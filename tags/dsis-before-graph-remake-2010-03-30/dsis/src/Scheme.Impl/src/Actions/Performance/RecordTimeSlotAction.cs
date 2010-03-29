using System;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public class RecordTimeSlotAction : RecordTimeActionBase
  {
    private readonly string mySlot;

    public RecordTimeSlotAction(IAction action, string slot) : base(action)
    {
      mySlot = slot;
    }

    protected override void ActionFinished(Context ctx, Context output, TimeSpan span)
    {
      PerformanceSlot ps = PerformanceSlot.Get(mySlot, SlotStore.Get(ctx));
      ps.AddTimeSlot(span);
    }

    protected override IAction CloneInternal(IAction action)
    {
      return new RecordTimeSlotAction(action, mySlot);
    }
  }
}