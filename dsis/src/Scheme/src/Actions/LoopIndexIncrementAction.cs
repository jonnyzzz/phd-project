using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
{
  public class LoopIndexIncrementAction : ActionBase
  {
    private readonly ILoopAction myLoop;

    public LoopIndexIncrementAction(ILoopAction loop)
    {
      myLoop = loop;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(myLoop.Key));
    }

    protected override void Apply(Context ctx, Context result)
    {
      var key = myLoop.Key;
      LoopIndex index = key.Get(ctx);
      key.Set(result, index.Next());
    }
  }
}