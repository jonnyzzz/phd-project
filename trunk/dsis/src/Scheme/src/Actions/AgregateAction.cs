using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;
using System.Linq;

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

    private AgregateAction(AgregateAction source)
    {
      myGraph = source.myGraph.Clone();
      myStart = myGraph.NodesOfType<StartAction>().Single();
      myEnd = myGraph.NodesOfType<EndAction>().Single();
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

    public IAction Clone()
    {
      return new AgregateAction(this);
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

      public IAction Clone()
      {
        return new EndAction();
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
        //TODO: Some action may show part of context the is resolved inside
        //TODO: that action, but there is no way to guess what requirements
        //TODO: are to be omitted here. Thus all checks would be made dynamical
        return EmptyArray<ContextMissmatch>.Instance;
      }

      public Context Apply(Context _)
      {
        return myContext;
      }

      public IAction Clone()
      {
        return new StartAction();
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