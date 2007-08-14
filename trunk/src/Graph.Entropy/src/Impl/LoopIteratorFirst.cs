using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  public abstract class LoopIteratorFirst<T> : LoopIteratorBase<T>
    where T : ICellCoordinate<T>
  {
    protected LoopIteratorFirst(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                               IStrongComponentInfo component) : base(callback, components, component)
    {
    }

    private static Q GetFirst<Q>(IEnumerable<Q> t)
    {
      foreach (Q t1 in t)
      {
        return t1;
      }
      return default(Q);
    }

    public override sealed void WidthSearch(IProgressInfo info)
    {
      if (myComponent == null)
        return;

      INode<T> first = GetFirst(myComponents.GetNodes(new IStrongComponentInfo[] {myComponent}));
      if (first == null)
        return;

      WidthSearch(info, myComponent.NodesCount, first);
    }

    protected abstract void WidthSearch(IProgressInfo info, long nodesCount, INode<T> node);
  }
}