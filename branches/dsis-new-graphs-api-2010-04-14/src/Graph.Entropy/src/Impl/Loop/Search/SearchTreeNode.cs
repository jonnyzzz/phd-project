using System.Collections.Generic;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public sealed class SearchTreeNode<N> 
  {
    public readonly SearchTreeNode<N> Parent = null;
    public readonly N Node;
    public readonly int Hash;

    public SearchTreeNode(SearchTreeNode<N> parent, N node, int hash)
    {
      Node = node;
      Parent = parent;
      Hash = hash;
    }

    public SearchTreeNode(SearchTreeNode<N> parent, N node, IEqualityComparer<N> comparer)
      : this(parent, node, comparer.GetHashCode(node))
    {
    }

    public bool IsNode(N node, IEqualityComparer<N> comparer)
    {
      return comparer.Equals(Node, node);
    }

    public override string ToString()
    {
      return Node.ToString();
    }

    public SearchTreeNode<N> Child(N node, IEqualityComparer<N> comparer)
    {
      return new SearchTreeNode<N>(this, node, comparer);
    }
  }
}