using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ChainAction : AgregateAction
  {
    public ChainAction(params IAction[] chain) : this((IEnumerable<ISimpleAction>)chain)
    {     
    }

    public ChainAction(IEnumerable<ISimpleAction> chain)
    {
      ISimpleAction prev = Builder.Start;
      foreach (ISimpleAction action in chain)
      {
        Builder.AddEdge(prev, action);
        prev = action;
      }
      Builder.AddEdge(prev, Builder.End);
    }
  }
}