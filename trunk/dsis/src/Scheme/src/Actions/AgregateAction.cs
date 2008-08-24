using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class AgregateAction : DebugableAction, IAction, IActionGraphPartBuilder
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

    public ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return myStart.CompatibleExternal(ctx);
    }

    public Context Apply(Context ctx)
    {
      myStart.SetContext(ctx);
      myGraph.Execute();
      var list = myEnd.Result;

      if (list.Count == 0)
        throw new Exception("End is unreacheble");

      var result = list.FoldLeft(
        new Context(),
        (x, r) =>
          {
            myGraph.AddAllNewAndCheck(r, x, () => "");
            return r;
          });

      myGraph.Clear();
      return result;
    }

    protected IActionGraphPartBuilder Builder
    {
      get { return this; }
    }

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

    public override string ToString()
    {
      return "AgragateAction:\r\n" + myGraph;
    }

    private class EndAction : IAction
    {
      private readonly List<Context> myResult = new List<Context>();

      public List<Context> Result
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
        myResult.Add(ctx);
        return ctx;
      }

      #endregion
    }

    private class StartAction : IAction
    {
      private readonly List<IAction> myChidren = new List<IAction>();
      private Context myContext;

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public ICollection<ContextMissmatch> CompatibleExternal(Context ctx)
      {
        var list = new List<ContextMissmatch>();
        foreach (IAction action in myChidren)
        {
          list.AddRange(action.Compatible(ctx));
        }
        return list;
      }

      public Context Apply(Context _)
      {
        return myContext;
      }

      public void AddChild(IAction child)
      {
        myChidren.Add(child);
      }

      public void SetContext(Context cx)
      {
        myContext = cx;
      }
    }
  }
}