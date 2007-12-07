using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public sealed class SearchTreeNode<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public readonly SearchTreeNode<T> Parent = null;
    public readonly INode<T> Node;
    public readonly int Hash;

    public SearchTreeNode(SearchTreeNode<T> parent, INode<T> node, int hash)
    {
      Node = node;
      Parent = parent;
      Hash = hash;
    }

    public SearchTreeNode(SearchTreeNode<T> parent, INode<T> node)
      : this(parent, node, COMPARER.GetHashCode(node.Coordinate))
    {
    }

    public bool IsNode(INode<T> node)
    {
      return COMPARER.Equals(Node.Coordinate, node.Coordinate);
    }

    public override string ToString()
    {
      return Node.ToString();
    }

    public SearchTreeNode<T> Child(INode<T> node)
    {
      return new SearchTreeNode<T>(this, node);
    }
  }
}