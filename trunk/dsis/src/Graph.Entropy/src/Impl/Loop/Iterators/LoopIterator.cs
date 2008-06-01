using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIterator<T> : ContextBase<T>, IGraphWeightSearch<T> where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IGraph<T> myGraph;

    private SearchTreeNode mySearchRoot;
    private readonly Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();
    private readonly Hashset<INode<T>> myVisitedNodes = new Hashset<INode<T>>();

    public LoopIterator(IGraph<T> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(components, component)
    {
      myGraph = graph;
    }

    private static bool IsUpperInTree(SearchTreeNode root, INode<T> node, List<INode<T>> result)
    {
      long hash = COMPARER.GetHashCode(node);
      while (root != null)
      {
        result.Add(root.Node);
        if (hash == root.Hash && root.IsNode(node))
        {
          return true;
        }
        root = root.Parent;
      }
      return false;
    }

    private void WidthSearch(ILoopIteratorCallback<T> callback, SearchTreeNode node)
    {
      myVisitedNodes.Add(node.Node);

      foreach (INode<T> edge in myGraph.GetEdges(node.Node))
      {
        if (myComponent != myComponents.GetNodeComponent(edge))
          continue;

        var loop = new List<INode<T>>();
        if (myVisitedNodes.Contains(node.Node) && IsUpperInTree(node, edge, loop))
        {
          callback.OnLoopFound(loop, loop.Count);          
        }
        else
        {
          myNodes.Enqueue(new SearchTreeNode(node, edge));
        }
      }
    }

    public void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> node)
    {
      mySearchRoot = new SearchTreeNode(null, node);

      myNodes.Enqueue(mySearchRoot);

      while (myNodes.Count > 0)
      {
        WidthSearch(callback, myNodes.Dequeue());
      }
    }

    private sealed class SearchTreeNode
    {
      public readonly SearchTreeNode Parent;
      public readonly INode<T> Node;
      public readonly int Hash;

      public SearchTreeNode(SearchTreeNode parent, INode<T> node)
      {
        Parent = parent;
        Node = node;
        Hash = COMPARER.GetHashCode(node);
      }

      public bool IsNode(INode<T> node)
      {
        return COMPARER.Equals(Node, node);
      }
    }
  }
}