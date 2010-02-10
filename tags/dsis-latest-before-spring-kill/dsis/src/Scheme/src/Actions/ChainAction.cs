using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ChainAction : AgregateAction
  {
    public ChainAction(params IAction[] chain) : this((IEnumerable<IAction>)chain)
    {     
    }

    public ChainAction(IEnumerable<IAction> chain)
    {
      IAction prev = Builder.Start;
      foreach (IAction action in chain)
      {
        Builder.AddEdge(prev, action);
        prev = action;
      }
      Builder.AddEdge(prev, Builder.End);
    }
  }
}