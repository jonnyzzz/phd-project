using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
{
  public class LoopIndexIncrementAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(LoopAction.LoopIndexKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      LoopIndex index = LoopAction.LoopIndexKey.Get(ctx);
      LoopAction.LoopIndexKey.Set(result, index.Next());
    }
  }
}