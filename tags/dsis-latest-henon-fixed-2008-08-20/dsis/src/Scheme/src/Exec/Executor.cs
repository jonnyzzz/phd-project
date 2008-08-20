using System.Collections.Generic;
using System.Text;
using DSIS.Scheme.Ctx;
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
        throw new ActionGraphException("Failed to evaluate graph. Loops of components?");
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

        List<ActionWrapper> deps = myBackEdges.GetValues(wrapper);
        if (myDoneActions.ContainsRange(deps))
        {
          var cx = new Context();
          foreach (ActionWrapper dep in deps)
          {
            cx.AddAll(myPendingContexts[dep]);
          }

          var compatible = wrapper.Action.Compatible(cx);
          if (compatible.Count != 0)
          {
            throw new ContextMissmatchException(compatible, wrapper.Action, cx);
          }

          Context result = wrapper.Action.Apply(cx);
          myPendingContexts[wrapper] = result;

          myDoneActions.Add(wrapper);

          foreach (ActionWrapper act in new List<ActionWrapper>(myPendingContexts.Keys))
          {
            if (myDoneActions.ContainsRange(myStraitEdges.GetValues(act)))
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
      var bW = new ActionWrapper(Simplify(b));
      var bA = new ActionWrapper(Simplify(a));

      myActions.Add(bW);
      myActions.Add(bA);
      myBackEdges.AddValue(bW, bA);
      myStraitEdges.AddValue(bA, bW);
    }

    private static IAction Simplify(IAction sb)
    {
      return sb;
    }

    private static IEnumerable<ActionWrapper> SortActions(IEnumerable<ActionWrapper> actions)
    {
      var list = new List<ActionWrapper>(actions);
      list.Sort((x,y) => (x.ToString().CompareTo(y.ToString())));

      return list;      
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      foreach (var actionWrapper in SortActions(myActions))
      {
        string str = string.Format("{0} => ", actionWrapper);
        sb.AppendLine(str);
        foreach (var wrapper in SortActions(myStraitEdges.GetValues(actionWrapper)))
        {
          sb
            .Append(' ', 4)
            .AppendLine(wrapper.ToString());
        }
      }

      return sb.ToString();
    }
  }
}