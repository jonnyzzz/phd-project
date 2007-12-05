using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIteratorFirst<T> : LoopIteratorBase<T>
    where T : ICellCoordinate<T>
  {
    private readonly IGraphWeightSearch<T> mySearcher;

    public LoopIteratorFirst(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                             IStrongComponentInfo component, IGraphWeightSearch<T> searcher) : base(callback, components, component)
    {
      mySearcher = searcher;
    }

    private static Q GetFirst<Q>(IEnumerable<Q> t)
    {
      foreach (Q t1 in t)
      {
        return t1;
      }
      return default(Q);
    }

    public override sealed void WidthSearch()
    {
      if (myComponent == null)
        return;

      INode<T> first = GetFirst(myComponents.GetNodes(new IStrongComponentInfo[] {myComponent}));
      if (first == null)
        return;

      mySearcher.WidthSearch(myCallback, first);
    }
  }
}