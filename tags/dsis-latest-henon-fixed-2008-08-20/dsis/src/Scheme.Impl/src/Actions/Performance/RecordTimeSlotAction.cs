using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using JetBrains.dotTrace.Api;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public class RecordTimeSlotAction : IAction
  {
    private readonly IAction myAction;
    private readonly string mySlot;

    public RecordTimeSlotAction(IAction action, string slot)
    {
      myAction = action;
      mySlot = slot;
    }

    public Context Apply(Context ctx)
    {
      PerformanceSlot ps = PerformanceSlot.Get(mySlot, SlotStore.Get(ctx));
      DateTime start = DateTime.Now;
      
      CPUProfiler.Start();
      var res = myAction.Apply(ctx);
      CPUProfiler.Stop();

      ps.AddTimeSlot(DateTime.Now - start);
      return res;
    }

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myAction.Compatible(ctx);        
    }
  }
}