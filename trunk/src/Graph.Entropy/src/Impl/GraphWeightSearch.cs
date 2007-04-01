using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class GraphWeightSearch<T, C> where T : ICellCoordinate<T> where C : IGraphWeightSearchCallback<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;
    private readonly IStrongComponentInfo myComponent;
    private readonly Hashset<INode<T>> myVisited;
    private readonly C myCallback;

    private SearchTreeNode mySearchRoot;
    private Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();

    public GraphWeightSearch(C callback, IGraph<T> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component)
    {
      myGraph = graph;
      myComponents = components;
      myComponent = component;
      myCallback = callback;

      myVisited = new Hashset<INode<T>>();
    }

    private static bool IsUpperInTree(SearchTreeNode root, INode<T> node, List<INode<T>> result)
    {
      long hash = COMPARER.GetHashCode(node.Coordinate);
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
      if (myVisited.Contains(node.Node))
        return;

      myVisited.Add(node.Node);

      foreach (INode<T> edge in myGraph.GetEdges(node.Node))
      {
        if (myComponent != myComponents.GetNodeComponent(edge))
          continue;

        List<INode<T>> loop = new List<INode<T>>();
        if (myVisited.Contains(edge) && IsUpperInTree(node, edge, loop))
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
      while (myNodes.Count > 0 )
      {
        info.Tick(1.0);
        WidthSearch(myNodes.Dequeue());
      }
    }

    private sealed class SearchTreeNode
    {
      public SearchTreeNode Parent = null;
      public readonly INode<T> Node;
      public readonly int Hash;

      public SearchTreeNode(SearchTreeNode parent, INode<T> node)
      {
        Parent = parent;
        Node = node;
        Hash = COMPARER.GetHashCode(node.Coordinate);
      }

      public bool IsNode(INode<T> node)
      {
        return COMPARER.Equals(Node.Coordinate, node.Coordinate);
      }
    }
  }
}