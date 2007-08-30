using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class LoopIterator<T> : LoopIteratorFirst<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IGraph<T> myGraph;

    private SearchTreeNode mySearchRoot;
    private readonly Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();
    private readonly Hashset<INode<T>> myVisitedNodes = new Hashset<INode<T>>();


    public LoopIterator(ILoopIteratorCallback<T> callback, IGraph<T> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(callback, components, component)
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

    private void WidthSearch(SearchTreeNode node)
    {
      myVisitedNodes.Add(node.Node);

      foreach (INode<T> edge in myGraph.GetEdges(node.Node))
      {
        if (myComponent != myComponents.GetNodeComponent(edge))
          continue;

        List<INode<T>> loop = new List<INode<T>>();
        if (myVisitedNodes.Contains(node.Node) && IsUpperInTree(node, edge, loop))
        {
          myCallback.OnLoopFound(loop);          
        }
        else
        {
          myNodes.Enqueue(new SearchTreeNode(node, edge));
        }
      }
    }

    protected override void WidthSearch(long nodesCount, INode<T> node)
    {
      mySearchRoot = new SearchTreeNode(null, node);

      myNodes.Enqueue(mySearchRoot);

      while (myNodes.Count > 0)
      {
        WidthSearch(myNodes.Dequeue());
      }
    }

    private sealed class SearchTreeNode
    {
      public readonly SearchTreeNode Parent = null;
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