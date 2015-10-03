using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Actions
{
  public class TransparentAction : IAction
  {
    private readonly IAction myAction;

    public TransparentAction(IAction action)
    {
      myAction = action;
    }

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myAction.Compatible(ctx);
    }

    public Context Apply(Context ctx)
    {
      return myAction.Apply(ctx);
    }
  }
}