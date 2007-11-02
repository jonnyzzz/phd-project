using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class GraphWeightSearch2<T> : GraphWeightSearchBase<T> where T : ICellCoordinate<T>
  {
    protected static IEqualityComparer<SearchTreeNode> COMPARER = new SearchTreeNodeComparer();

    public GraphWeightSearch2(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                              IStrongComponentInfo component) : base(callback, components, component)
    {
    }

    protected override IVisitedCollection CreateVisitedCollection()
    {
      return new VisitedCollection();
    }

    protected class VisitedCollection : IVisitedCollection
    {
      private readonly Hashset<SearchTreeNode> myVisited = new Hashset<SearchTreeNode>(COMPARER);
      private readonly MultiHashDictionary<T, T> myTree = new MultiHashDictionary<T, T>(); //node -> parent

      public bool Contains(SearchTreeNode node)
      {
        return myVisited.Contains(node);
      }

      public bool IsInTree(SearchTreeNode from, INode<T> to)
      {
        if (from == null)
          return true;
        return myTree.ContainsPair(to.Coordinate, from.Root().Node.Coordinate);        
      }

      public void Visited(SearchTreeNode node)
      {
        myVisited.Add(node);
        if (node.Parent != null)
          myTree.Add(node.Node.Coordinate, node.Root().Node.Coordinate);
      }
    }

    private class SearchTreeNodeComparer : IEqualityComparer<SearchTreeNode>
    {
      public bool Equals(SearchTreeNode x, SearchTreeNode y)
      {
        return ReferenceEquals(x.Node, y.Node) && ReferenceEquals(x.Parent, y.Parent);
      }

      public int GetHashCode(SearchTreeNode obj)
      {
        return obj.Hash;
      }
    }
  }
}