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
      bool build = false;
      foreach (ISimpleAction action in actions)
      {
        build = true;
        Builder.AddEdge(Builder.Start, action);
        Builder.AddEdge(action, Builder.End);
      }

      if (!build)
        Builder.AddEdge(Builder.Start, Builder.End);
    }
  }
}