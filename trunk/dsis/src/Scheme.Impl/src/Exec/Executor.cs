using System;
using System.Collections.Generic;
using DSIS.Graph.Util;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Exec
{
  public class ActionGraph : IActionGraphBuilder
  {
    private readonly MultiDictionary<ActionWrapper, ActionWrapper> myBackEdges =
      new MultiDictionary<ActionWrapper, ActionWrapper>(EqualityComparer<ActionWrapper>.Default);

    private readonly MultiDictionary<ActionWrapper, ActionWrapper> myStraitEdges =
      new MultiDictionary<ActionWrapper, ActionWrapper>(EqualityComparer<ActionWrapper>.Default);

    private readonly Hashset<ActionWrapper> myDoneActions = new Hashset<ActionWrapper>();
    private readonly Hashset<ActionWrapper> myActions = new Hashset<ActionWrapper>();
    private readonly Dictionary<ActionWrapper, Context> myPendingContexts = new Dictionary<ActionWrapper, Context>();

    public void Execite()
    {
      SetInitialActionsContext();
      while (DoAction()) ;
    }

    private void SetInitialActionsContext()
    {
      foreach (ActionWrapper key in myStraitEdges.Keys)
      {
        if (!myBackEdges.ContainsKey(key))
        {
          myPendingContexts[key] = new Context();
        }
      }
    }

    private bool DoAction()
    {
      foreach (ActionWrapper wrapper in myActions)
      {
        if (myDoneActions.Contains(wrapper))
          continue;

        List<ActionWrapper> deps = myBackEdges.GetValue(wrapper);
        if (myDoneActions.ContainsRange(deps))
        {
          Context cx = new Context();
          foreach (ActionWrapper dep in deps)
          {
            cx.AddAll(myPendingContexts[dep]);
          }

          if (wrapper.Action.Compatible(cx).Count != 0)
          {
            throw new Exception("Incompatible action!");
          }

          Context result = wrapper.Action.Apply(cx);
          myPendingContexts[wrapper] = result;

          myDoneActions.Add(wrapper);

          foreach (ActionWrapper act in new List<ActionWrapper>(myPendingContexts.Keys))
          {
            if (myDoneActions.ContainsRange(myStraitEdges.GetValue(act)))
            {
              myPendingContexts.Remove(act);
            }
          }
          return true;
        }
      }
      return false;
    }

    public void AddEdge(IAction a, IAction b)
    {
      ActionWrapper bW = new ActionWrapper(b);
      ActionWrapper bA = new ActionWrapper(a);

      myActions.Add(bW);
      myActions.Add(bA);
      myBackEdges.AddValue(bW, bA);
      myStraitEdges.AddValue(bA, bW);
    }
  }
}