using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearchFiltering<T, N> : GraphWeightSearchBase<T, N, GraphWeightSearchFiltering<T,N>.VisitedCollection>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public GraphWeightSearchFiltering(IReadonlyGraphStrongComponents<T,N> components, IStrongComponentInfo component)
      : base(components, component)
    {
    }

    public override void WidthSearch(ILoopIteratorCallback<T,N> callback, N anode)
    {
      base.WidthSearch(new LoopIteratorProxy(callback, GetVisitedCollection()), anode);
    }

    protected override VisitedCollection CreateCollection()
    {
      return new VisitedCollection(NCOMPARER);
    }

    public sealed class VisitedCollection : VisitedCollectionBase<N>
    {
      private readonly HashSet<N> myVisited2;

      public VisitedCollection(IEqualityComparer<N> cmp) : base(cmp)
      {
        myVisited2 = new HashSet<N>(cmp);
      }

      public override SearchTreeNode<N> CreateQueuedNodeIfNoLoop(SearchTreeNode<N> parent, N to)
      {
        return new SearchTreeNode<N>(null, to, myCmp);
      }

      public override bool Contains(SearchTreeNode<N> node)
      {
        return base.Contains(node) && !myVisited2.Contains(node.Node);
      }

      public void MarkVisited(IEnumerable<N> loop)
      {
        myVisited2.UnionWith(loop);
      }
    }

    private class LoopIteratorProxy : ILoopIteratorCallback<T,N>
    {
      private readonly ILoopIteratorCallback<T,N> myIterator;
      private readonly VisitedCollection myCollection;

      public LoopIteratorProxy(ILoopIteratorCallback<T,N> iterator, VisitedCollection collection)
      {
        myIterator = iterator;
        myCollection = collection;
      }

      public void OnLoopFound(IEnumerable<N> loop, int length)
      {
        myCollection.MarkVisited(loop);
        myIterator.OnLoopFound(loop, length);
      }
    }
  }
}