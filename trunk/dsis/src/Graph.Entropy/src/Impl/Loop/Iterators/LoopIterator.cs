using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIterator<T, N> : ContextBase<T, N>, IGraphWeightSearch<T, N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();
    private readonly HashSet<N> myVisitedNodes;

    private SearchTreeNode mySearchRoot;

    public LoopIterator(IReadonlyGraphStrongComponents<T, N> components, IStrongComponentInfo component)
      : base(components, component)
    {
      myVisitedNodes = new HashSet<N>(COMPARER);
    }

    private bool IsUpperInTree(SearchTreeNode root, N node, List<N> result)
    {
      long hash = COMPARER.GetHashCode(node);
      while (root != null)
      {
        result.Add(root.Node);
        if (hash == root.Hash && root.IsNode(node, COMPARER))
        {
          return true;
        }
        root = root.Parent;
      }
      return false;
    }

    private void WidthSearch(ILoopIteratorCallback<T, N> callback, SearchTreeNode node)
    {
      myVisitedNodes.Add(node.Node);

      foreach (N edge in myAccessor.GetEdges(node.Node))
      {
        var loop = new List<N>();
        if (myVisitedNodes.Contains(node.Node) && IsUpperInTree(node, edge, loop))
        {
          IEnumerable<N> enumerable = loop;
          callback.OnLoopFound(enumerable, loop.Count);
        }
        else
        {
          myNodes.Enqueue(new SearchTreeNode(node, edge, COMPARER));
        }
      }
    }

    public void WidthSearch(ILoopIteratorCallback<T, N> callback, N node)
    {
      mySearchRoot = new SearchTreeNode(null, node, COMPARER);

      myNodes.Enqueue(mySearchRoot);

      while (myNodes.Count > 0)
      {
        WidthSearch(callback, myNodes.Dequeue());
      }
    }

    private sealed class SearchTreeNode
    {
      public readonly SearchTreeNode Parent;
      public readonly N Node;
      public readonly int Hash;

      public SearchTreeNode(SearchTreeNode parent, N node, IEqualityComparer<N> cmp)
      {
        Parent = parent;
        Node = node;
        Hash = cmp.GetHashCode(node);
      }

      public bool IsNode(N node, IEqualityComparer<N> cmp)
      {
        return cmp.Equals(Node, node);
      }
    }
  }
}