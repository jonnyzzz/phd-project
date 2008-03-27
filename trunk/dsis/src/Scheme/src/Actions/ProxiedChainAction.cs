using System.Collections.Generic;

namespace DSIS.Scheme.Actions
{
  public class ProxiedChainAction : AgregateAction
  {
    public ProxiedChainAction(params IAction[] chain)
      : this((IEnumerable<ISimpleAction>)chain)
    {
    }

    public ProxiedChainAction(IEnumerable<ISimpleAction> chain)
    {
      ProxyAction pa = new ProxyAction();
      Builder.AddEdge(Builder.Start, pa);
      ISimpleAction prev = Builder.Start; //todo: pa?
      foreach (ISimpleAction action in chain)
      {
        Builder.AddEdge(pa, action);
        Builder.AddEdge(prev, action);
        prev = action;
      }
      Builder.AddEdge(prev, Builder.End);

    }
  }
}