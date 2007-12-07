using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ProxiedChainAction : AgregateAction
  {
    public ProxiedChainAction(params IAction[] chain)
      : this((IEnumerable<IAction>)chain)
    {
    }

    public ProxiedChainAction(IEnumerable<IAction> chain)
    {
      ProxyAction pa = new ProxyAction();
      Builder.AddEdge(Builder.Start, pa);
      IAction prev = Builder.Start;
      foreach (IAction action in chain)
      {
        Builder.AddEdge(pa, action);
        Builder.AddEdge(prev, action);
        prev = action;
      }
      Builder.AddEdge(prev, Builder.End);

    }
  }
}