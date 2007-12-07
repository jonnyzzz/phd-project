using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ParallelAction : AgregateAction
  {
    public ParallelAction(params IAction[] chain)
      : this((IEnumerable<IAction>)chain)
    {     
    }

    public ParallelAction(IEnumerable<IAction> actions)
    {
      foreach (IAction action in actions)
      {
        Builder.AddEdge(Builder.Start, action);
        Builder.AddEdge(action, Builder.End);
      }
    }
  }
}