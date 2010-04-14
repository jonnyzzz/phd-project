using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearchLimited<T,N> : GraphWeightSearchBase<T, N, GraphWeightSearchLimited<T, N>.VisitedCollection>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public GraphWeightSearchLimited(IReadonlyGraphStrongComponents<T,N> components, IStrongComponentInfo component) : base(components, component)
    {
    }

    protected override VisitedCollection CreateCollection()
    {
      return new VisitedCollection(NCOMPARER);
    }

    public sealed class VisitedCollection : VisitedCollectionBase<N>
    {
      private const int LIMIT = 1000;
      private int myCount;

      public VisitedCollection(IEqualityComparer<N> cmp) : base(cmp)
      {
      }

      public override SearchTreeNode<N> CreateQueuedNodeIfNoLoop(SearchTreeNode<N> parent, N to)
      {
        return new SearchTreeNode<N>(null, to, myCmp);
      }

      public override bool Contains(SearchTreeNode<N> node)
      {
        return myCount > LIMIT || base.Contains(node);
      }

      public override void Visited(SearchTreeNode<N> node)
      {
        myCount++;
        base.Visited(node);
      }

      public override void Clear()
      {
        myCount = 0;
        base.Clear();
      }
    }
  }
}