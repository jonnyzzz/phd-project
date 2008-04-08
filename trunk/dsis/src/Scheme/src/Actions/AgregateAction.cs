using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class AgregateAction : DebugableAction, IAction, IActionGraphPartBuilder, ISimpleAction
  {
    private readonly EndAction myEnd = new EndAction();
    private readonly ActionGraph myGraph = new ActionGraph();
    private readonly StartAction myStart = new StartAction();

    public delegate void ConstructGraph(IActionGraphPartBuilder bld);

    protected AgregateAction()
    {
    }

    public AgregateAction(ConstructGraph construct)
    {
      construct(Builder);
    }

    #region IAction Members

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myStart.CompatibleExternal(ctx);
    }

    public Context Apply(Context ctx)
    {
      myStart.SetContext(ctx);
      myGraph.Execute();
      Context result = myEnd.Result;
      if (result == null)
        throw new Exception("End is unreacheble");

      myGraph.Clear();
      return result;
    }

    protected IActionGraphPartBuilder Builder
    {
      get { return this; }
    }

    #endregion

    #region IActionGraphPartBuilder Members

    ISimpleAction IActionGraphPartBuilder.Start
    {
      get { return myStart; }
    }

    ISimpleAction IActionGraphPartBuilder.End
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

    private class EndAction : ISimpleAction
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

    private class StartAction : ISimpleAction
    {
      private readonly List<IAction> myChidren = new List<IAction>();
      private Context myContext;

      #region IAction Members

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {        
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public ICollection<ContextMissmatch> CompatibleExternal(Context ctx)
      {
        List<ContextMissmatch> list = new List<ContextMissmatch>();
        foreach (ISimpleAction action in myChidren)
        {
          list.AddRange(action.Compatible(ctx));
        }
        return list;
      }

      public Context Apply(Context _)
      {
        return myContext;
      }

      #endregion

      public void AddChild(IAction child)
      {
        myChidren.Add(child);
      }

      public void SetContext(Context cx)
      {
        myContext = cx;
      }
    }

    #endregion
  }
}