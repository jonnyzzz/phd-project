using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class AgregateAction : IAction, IActionGraphPartBuilder
  {
    private readonly EndAction myEnd = new EndAction();
    private readonly ActionGraph myGraph = new ActionGraph();
    private readonly StartAction myStart = new StartAction();

    #region IAction Members

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myStart.Compatible(ctx);
    }

    public Context Apply(Context ctx)
    {
      myGraph.Execute();
      Context result = myEnd.Result;
      if (result == null)
        throw new Exception("End is unreacheble");

      return result;
    }

    public IActionGraphPartBuilder Builder
    {
      get { return this; }
    }

    #endregion

    #region IActionGraphPartBuilder Members

    IAction IActionGraphPartBuilder.Start
    {
      get { return myStart; }
    }

    IAction IActionGraphPartBuilder.End
    {
      get { return myEnd; }
    }

    void IActionGraphBuilder.AddEdge(IAction a, IAction b)
    {
      if (Equals(a, myStart))
        myStart.AddChild(b);

      myGraph.AddEdge(a, b);
    }

    #endregion

    #region Nested type: EndAction

    private class EndAction : IAction
    {
      private Context myResult;

      public Context Result
      {
        get { return myResult; }
      }

      #region IAction Members

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public Context Apply(Context ctx)
      {
        myResult = ctx;
        return ctx;
      }

      #endregion
    }

    #endregion

    #region Nested type: StartAction

    private class StartAction : IAction
    {
      private readonly List<IAction> myChidren = new List<IAction>();

      #region IAction Members

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        List<ContextMissmatch> list = new List<ContextMissmatch>();
        foreach (IAction action in myChidren)
        {
          list.AddRange(action.Compatible(ctx));
        }
        return list;
      }

      public Context Apply(Context ctx)
      {
        return ctx;
      }

      #endregion

      public void AddChild(IAction child)
      {
        myChidren.Add(child);
      }
    }

    #endregion
  }
}