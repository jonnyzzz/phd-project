using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class GraphWeightSearch<T> : GraphWeightSearchBase<T> where T : ICellCoordinate<T>
  {
    public GraphWeightSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                             IStrongComponentInfo component) : base(callback, components, component)
    {
    }

    protected override IVisitedCollection CreateVisitedCollection()
    {
      return new VisitedCollection();
    }

    private class VisitedCollection : IVisitedCollection
    {
      private readonly Hashset<INode<T>> myVisited =
        new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

      public bool Contains(SearchTreeNode node)
      {
        return myVisited.Contains(node.Node);
      }

      public bool IsInTree(SearchTreeNode from, INode<T> to)
      {
        return myVisited.Contains(to);
      }

      public void Visited(SearchTreeNode node)
      {
        myVisited.Add(node.Node);
      }
    }
  }
}