using System.Collections;
using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ChainAction : AgregateAction
  {
    public ChainAction(params IAction[] chain) : this((IEnumerable<ISimpleAction>)new ArrayList(chain).ToArray(typeof(ISimpleAction)))
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