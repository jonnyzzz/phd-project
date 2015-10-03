using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation]
  public class ActionPresentationManager : IActionPresentationManager
  {
    private readonly ActionDescriptor myRootAction = new ActionDescriptor("root", null, "", "", "RootAction");

    private readonly Dictionary<string, IActionDescriptor> myIdToAction = new Dictionary<string, IActionDescriptor>();

    private readonly MultiDictionary<string, IActionHandler> myIdToHandler =
      new MultiDictionary<string, IActionHandler>(EqualityComparerFactory<string>.GetComparer());

    private readonly MultiDictionary<string, IActionDescriptor> myChildren =
      new MultiDictionary<string, IActionDescriptor>(EqualityComparerFactory<string>.GetComparer());

    public void RegisterAction(IActionDescriptor desc)
    {
      myChildren.AddValue(desc.ParentId, desc);

      if (!string.IsNullOrEmpty(desc.ActionId))
      {
        myIdToAction.Add(desc.ActionId, desc);
      }
    }

    public IActionDescriptor GetDescriptor(string actionId)
    {
      return myIdToAction[actionId];
    } 

    public void RegisterHandler(IActionHandler handler)
    {
      foreach (var id in handler.ActionId)
      {
        myIdToHandler.AddValue(id, handler);
      }
    }

    public void AddActionDescriptor(string actionId, string parentActionId, string title, string description, string ancor)
    {
      RegisterAction(new ActionDescriptor(actionId, parentActionId, ancor, description, title));
    }

    public ActionDescriptor RootAction
    {
      get { return myRootAction; }
    }

    public IEnumerable<IActionDescriptor> Children(IActionDescriptor action)
    {
      foreach (var child in myChildren.GetValues(action.ActionId))
      {
        yield return child;
      }
    }

    public IActionHandler Handler(IActionDescriptor action)
    {
      return new ActionHandlerProxy(action.ActionId, () => myIdToHandler.GetValues(action.ActionId));
    }

    private class ActionHandlerProxy : IActionHandler
    {
      private readonly string myId;
      private readonly Func<IEnumerable<IActionHandler>> myChain;

      public ActionHandlerProxy(string id, Func<IEnumerable<IActionHandler>> chain)
      {
        myChain = chain;
        myId = id;
      }

      public string[] ActionId
      {
        get { return new[]{myId}; }
      }

      public bool Do(Context ctx)
      {
        foreach (var handler in myChain())
        {
          if (handler.Enabled(ctx) && handler.Do(ctx))
            return true;
        }
        return false;
      }

      public bool Enabled(Context ctx)
      {
        foreach (var handler in myChain())
        {
          if (handler.Enabled(ctx))
            return true;
        }
        return false;
      }
    }
  }
}