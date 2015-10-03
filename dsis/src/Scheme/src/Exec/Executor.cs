using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Exec
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

    public void Execute()
    {
      SetInitialActionsContext();
      while (DoAction()) { }

      if (myActions.Count != myDoneActions.Count)
        throw new ActionGraphException("Failed to evaluate graph. Loops or components?");
    }

    public void Clear()
    {
      myDoneActions.Clear();
      myPendingContexts.Clear();
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

          ICollection<ContextMissmatch> compatible = wrapper.Action.Compatible(cx);
          if (compatible.Count != 0)
          {
            throw new ContextMissmatchException(compatible, wrapper.Action, cx);
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
      ActionWrapper bW = new ActionWrapper(Simplify(b));
      ActionWrapper bA = new ActionWrapper(Simplify(a));

      myActions.Add(bW);
      myActions.Add(bA);
      myBackEdges.AddValue(bW, bA);
      myStraitEdges.AddValue(bA, bW);
    }

    private ISimpleAction Simplify(IAction sb)
    {
      return (ISimpleAction) sb;
    }


  }
}