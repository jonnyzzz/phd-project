using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Performance
{
  public class DumpSlotTimesAction : ActionBase
  {
    private readonly string myName;

    public DumpSlotTimesAction(string name)
    {
      myName = name;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      SlotStore ss = SlotStore.Get(ctx);
      PerformanceSlot ps = PerformanceSlot.Get(myName, ss);
      Logger.Instance(ctx).Write("------------------->>");
      Logger.Instance(ctx).Write("Performance: {0}={1}ms", myName, ps.Time.TotalMilliseconds);
      Logger.Instance(ctx).Write("-------------------<<");
    }
  }
}