using System;
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

    private readonly HashSet<ActionWrapper> myDoneActions = new HashSet<ActionWrapper>();
    private readonly HashSet<ActionWrapper> myActions = new HashSet<ActionWrapper>();
    private readonly Dictionary<ActionWrapper, Context> myPendingContexts = new Dictionary<ActionWrapper, Context>();

    public ActionGraph()
    {
    }


    private class GraphClone
    {
      private readonly Dictionary<IAction, IAction> myClonedCache = new Dictionary<IAction, IAction>();

      private IAction Clone(IAction action)
      {
        IAction clone;
        if (myClonedCache.TryGetValue(action, out clone))
          return clone;
        return myClonedCache[action] = action.Clone();        
      }

      public ActionWrapper Clone(ActionWrapper aw)
      {
        return new ActionWrapper(Clone(aw.Action));
      }

      public IEnumerable<ActionWrapper> Clone(IEnumerable<ActionWrapper> enu)
      {
        return enu.Map(x => Clone(x));
      }      
    }

    private ActionGraph(ActionGraph source)
    {
      var clone = new GraphClone();

      foreach (KeyValuePair<ActionWrapper, List<ActionWrapper>> pair in source.myBackEdges)
        myBackEdges.AddValues(clone.Clone(pair.Key), clone.Clone(pair.Value));
      foreach (KeyValuePair<ActionWrapper, List<ActionWrapper>> pair in source.myStraitEdges)
        myStraitEdges.AddValues(clone.Clone(pair.Key), clone.Clone(pair.Value));
      foreach (ActionWrapper action in source.myDoneActions)
        myDoneActions.Add(clone.Clone(action));
      foreach (ActionWrapper action in source.myActions)
        myActions.Add(clone.Clone(action));
      foreach (KeyValuePair<ActionWrapper, Context> pair in source.myPendingContexts)
        myPendingContexts.Add(clone.Clone(pair.Key), pair.Value.Clone());
    }

    public void Execute()
    {
      SetInitialActionsContext();
      while (DoAction())
      {
      }

      if (myActions.Count != myDoneActions.Count)
        throw new ActionGraphException("Failed to evaluate graph. Loops of components?");
    }

    public void Clear()
    {
      myDoneActions.Clear();
      myPendingContexts.Clear();
    }

    public ActionGraph Clone()
    {
      return new ActionGraph(this);
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

    //todo: Visit graph with minimal context cached.
    private bool DoAction()
    {
      foreach (ActionWrapper wrapper in myActions)
      {
        if (myDoneActions.Contains(wrapper))
          continue;

        List<ActionWrapper> deps = myBackEdges.GetValues(wrapper);
        if (!myDoneActions.IsSupersetOf(deps))
          continue;

        Context cx = BuildActionExecutionContext(wrapper, deps);

        var compatible = wrapper.Action.Compatible(cx);
        if (compatible.Count != 0)
          throw new ContextMissmatchException(compatible, wrapper.Action, cx);

        Context result = wrapper.Action.Apply(cx);
        myPendingContexts[wrapper] = result;

        myDoneActions.Add(wrapper);

        foreach (ActionWrapper act in new List<ActionWrapper>(myPendingContexts.Keys))
        {
          if (myDoneActions.IsSupersetOf(myStraitEdges.GetValues(act)))
          {
            myPendingContexts.Remove(act);
          }
        }
        return true;
      }
      return false;
    }

    private Context BuildActionExecutionContext(ActionWrapper node, IEnumerable<ActionWrapper> deps)
    {
      var cx = new Context();
      foreach (ActionWrapper _dep in deps)
      {
        ActionWrapper dep = _dep;
        var source = myPendingContexts[dep];
        AddAllNewAndCheck(
          cx,
          source,
          delegate
            {
              Converter<ActionWrapper, string> stack1 =
                x1 =>
                  {
                    var
                      args1 = x1.Action as IActionDebug;
                    return args1 != null ? args1.Creation.ToString() : string.Empty;
                  };

              return string.Format("for node {0} {1} and node {2} {3}", node,
                                   stack1(node),
                                   dep,
                                   stack1(dep));
            });        
      }
      return cx;
    }

    public void AddAllNewAndCheck(Context dest, Context source, Lazy<string> errorMessage)
    {
      dest.AddAllNew(
        source,
        (key, oldV, newV) =>
          {
            throw new ActionGraphException(
              string.Format( 
                "Context clashed for key '{0}' {1}",
                key.Name, errorMessage()));
          });
    }

    private ActionWrapper ForIAction(IAction a)
    {
      foreach (var action in myActions)
      {
        if (Equals(action.Action, a))
          return action;
      }
      return new ActionWrapper(a);
    }

    public void AddEdge(IAction a, IAction b)
    {
      var bW = ForIAction(b);
      var bA = ForIAction(a);

      myActions.Add(bW);
      myActions.Add(bA);
      myBackEdges.AddValue(bW, bA);
      myStraitEdges.AddValue(bA, bW);
    }

    private static IEnumerable<ActionWrapper> SortActions(IEnumerable<ActionWrapper> actions)
    {
      var list = new List<ActionWrapper>(actions);
      list.Sort((x, y) => (x.ToString().CompareTo(y.ToString())));

      return list;
    }

    public IEnumerable<T> NodesOfType<T>() where T : IAction
    {
      return myActions.Map(x=>x.Action).Filter(x => x is T).Cast<T>();
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