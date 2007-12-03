using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public class MergeInputAndOutputAction : ActionBase
  {
    private readonly IAction myDelegate;

    public MergeInputAndOutputAction(IAction @delegate)
    {
      myDelegate = @delegate;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myDelegate.Compatible(ctx);
    }

    protected override void Apply(Context ctx, Context result)
    {
      result.AddAll(ctx);
      result.AddAll(myDelegate.Apply(ctx));
    }
  }
}