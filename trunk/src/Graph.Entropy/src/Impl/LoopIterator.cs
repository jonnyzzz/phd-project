using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class LoopIterator<T, C> where T : ICellCoordinate<T> where C : ILoopIteratorCallback<T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = NodeReferenceEqualityComparer<T>.INSTANCE;

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;
    private readonly IStrongComponentInfo myComponent;
    private readonly C myCallback;

    private SearchTreeNode mySearchRoot;
    private readonly Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();
    private readonly Hashset<INode<T>> myVisitedNodes = new Hashset<INode<T>>();

    public LoopIterator(C callback, IGraph<T> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component)
    {
      myGraph = graph;
      myComponents = components;
      myComponent = component;
      myCallback = callback;
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

    public void WidthSearch(IProgressInfo info, long nodesCount, INode<T> node)
    {
      mySearchRoot = new SearchTreeNode(null, node);

      myNodes.Enqueue(mySearchRoot);

      info.Minimum = 0;
      info.Minimum = 1;
      while (myNodes.Count > 0)
      {
        info.Tick(1.0);
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
//    private sealed class SearchTreeNodeEqualityComparer : IEqualityComparer<SearchTreeNode>
//    {
//      public static readonly IEqualityComparer<SearchTreeNode> INSTANCE 
//        = new SearchTreeNodeEqualityComparer();
//
//      public bool Equals(SearchTreeNode x, SearchTreeNode y)
//      {
//        return x.Hash == y.Hash && x.Parent == y.Parent && COMPARER.Equals(x.Node, y.Node);
//      }
//
//      public int GetHashCode(SearchTreeNode obj)
//      {
//        return COMPARER.GetHashCode(obj.Node) | (obj.Parent != null ? COMPARER.GetHashCode(obj.Parent.Node) : 0);
//      }
//    }
  }
}