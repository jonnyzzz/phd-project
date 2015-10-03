using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
{
  public class ReplaceContextAction : ActionBase
  {
    private readonly ISimpleAction myAction;

    public ReplaceContextAction(ISimpleAction action)
    {
      myAction = action;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myAction.Compatible(ctx);
    }

    protected override void Apply(Context ctx, Context result)
    {
      result.AddAll(ctx);
      result.AddAll(myAction.Apply(ctx));
    }
  }
}