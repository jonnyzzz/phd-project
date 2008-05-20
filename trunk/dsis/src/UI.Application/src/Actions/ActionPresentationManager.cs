using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Spring;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  [UsedBySpring]
  public class ActionPresentationManager : IActionPresentationManager
  {
    private readonly ActionDescriptor myRootAction = new ActionDescriptor("root", null, "", "", "RootAction");

    private readonly Dictionary<string, ActionDescriptor> myIdToAction = new Dictionary<string, ActionDescriptor>();

    private readonly MultiDictionary<string, IActionHandler> myIdToHandler =
      new MultiDictionary<string, IActionHandler>(EqualityComparerFactory<string>.GetComparer());

    private readonly MultiDictionary<string, ActionDescriptor> myChildren =
      new MultiDictionary<string, ActionDescriptor>(EqualityComparerFactory<string>.GetComparer());

    public void RegisterAction(ActionDescriptor desc)
    {
      myChildren.AddValue(desc.ParentId, desc);
      myIdToAction.Add(desc.ActionId, desc);
    }

    public void RegisterHandler(IActionHandler handler)
    {
      myIdToHandler.AddValue(handler.ActionId, handler);      
    }

    public ActionDescriptor RootAction
    {
      get { return myRootAction; }
    }

    public IEnumerable<ActionDescriptor> Children(ActionDescriptor action)
    {
      foreach (var child in myChildren.GetValues(action.ActionId))
      {
        yield return child;
      }
    }

    public IActionHandler Handler(ActionDescriptor action)
    {
      return new ActionHandlerProxy(action.ActionId, myIdToHandler.GetValues(action.ActionId));
    }

    private class ActionHandlerProxy : IActionHandler
    {
      private readonly string myId;
      private readonly List<IActionHandler> myChain;

      public ActionHandlerProxy(string id, IEnumerable<IActionHandler> chain)
      {
        myChain = new List<IActionHandler>(chain);
        myId = id;
      }

      public string ActionId
      {
        get { return myId; }
      }

      public bool Do(Context ctx)
      {
        foreach (var handler in myChain)
        {
          if (handler.Enabled(ctx) && handler.Do(ctx))
            return true;
        }
        return false;
      }

      public bool Enabled(Context ctx)
      {
        foreach (var handler in myChain)
        {
          if (handler.Enabled(ctx))
            return true;
        }
        return false;
      }
    }
  }
}