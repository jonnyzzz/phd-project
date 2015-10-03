using System;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions.Impl
{
  public class ActionHandlerBase : IActionHandler
  {
    private readonly string myActionId;

    public ActionHandlerBase(string actionId)
    {
      myActionId = actionId;
    }

    public string ActionId
    {
      get { return myActionId; }
    }

    public virtual bool Enabled(Context ctx)
    {
      return true;
    }

    public virtual bool Do(Context ctx)
    {
      return false;
    }
  }
}