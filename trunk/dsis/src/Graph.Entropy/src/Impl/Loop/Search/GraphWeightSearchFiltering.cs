using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearchFiltering<T> : GraphWeightSearchBase<T, GraphWeightSearchFiltering<T>.VisitedCollection>
    where T : ICellCoordinate
  {
    public GraphWeightSearchFiltering(IGraphStrongComponents<T> components, IStrongComponentInfo component)
      : base(components, component)
    {
    }

    public override void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode)
    {
      base.WidthSearch(new LoopIteratorProxy(callback, GetVisitedCollection()), anode);
    }

    public sealed class VisitedCollection : VisitedCollectionBase<T>
    {
      private readonly Hashset<INode<T>> myVisited2 =
        new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

      public override SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to)
      {
        return new SearchTreeNode<T>(null, to);
      }

      public override bool Contains(SearchTreeNode<T> node)
      {
        return base.Contains(node) && !myVisited2.Contains(node.Node);
      }

      public void MarkVisited(IEnumerable<INode<T>> loop)
      {
        myVisited2.AddRange(loop);
      }
    }

    private class LoopIteratorProxy : ILoopIteratorCallback<T>
    {
      private readonly ILoopIteratorCallback<T> myIterator;
      private readonly VisitedCollection myCollection;

      public LoopIteratorProxy(ILoopIteratorCallback<T> iterator, VisitedCollection collection)
      {
        myIterator = iterator;
        myCollection = collection;
      }

      public void OnLoopFound(IEnumerable<INode<T>> loop, int length)
      {
        myCollection.MarkVisited(loop);
        myIterator.OnLoopFound(loop, length);
      }
    }
  }
}