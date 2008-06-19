using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  [Obsolete("Get rid of it")]
  public class ProxyAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      result.AddAll(ctx);
    }
  }

  [Obsolete("Get rid of it")]
  public class NoCheckAction : ActionBase
  {
    private readonly IAction myAction;

    public NoCheckAction(IAction action)
    {
      myAction = (IAction)action;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      result.AddAll(myAction.Apply(ctx));
    }
  }
}