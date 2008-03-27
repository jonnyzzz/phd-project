using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
{
  public class MergeInputAndOutputAction : ActionBase
  {
    private readonly ISimpleAction myDelegate;

    public MergeInputAndOutputAction(ISimpleAction @delegate)
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