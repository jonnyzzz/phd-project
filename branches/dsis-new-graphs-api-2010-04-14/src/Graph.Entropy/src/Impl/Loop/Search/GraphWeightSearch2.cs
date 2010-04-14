using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearch2<T,N> : GraphWeightSearchBase<T, N, GraphWeightSearch2<T,N>.VisitedCollection> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public GraphWeightSearch2(IReadonlyGraphStrongComponents<T,N> components,
                              IStrongComponentInfo component) : base(components, component)
    {
    }

    protected override VisitedCollection CreateCollection()
    {
      return new VisitedCollection(NCOMPARER);
    }

    public sealed class VisitedCollection : VisitedCollectionBase<N>
    {
      public VisitedCollection(IEqualityComparer<N> cmp) : base(cmp)
      {
      }

      public override SearchTreeNode<N> CreateQueuedNodeIfNoLoop(SearchTreeNode<N> parent, N to)
      {
        return parent.Child(to, myCmp);
      }
    }    
  }
}