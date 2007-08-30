using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class GraphWeightSearch<T> : LoopIteratorFirst<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public GraphWeightSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(callback, components, component)
    {
    }

    private static bool IsUpperInTree(SearchTreeNode root, INode<T> node, ICollection<INode<T>> result)
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

    protected override void WidthSearch(long nodesCount, INode<T> anode)
    {
      Hashset<INode<T>> visited = new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());
      Queue<SearchTreeNode> queue = new Queue<SearchTreeNode>();

      IStrongComponentInfo[] infos = new IStrongComponentInfo[] { myComponent };

      queue.Enqueue(new SearchTreeNode(null, anode));
      while (queue.Count > 0)
      {
        SearchTreeNode node = queue.Dequeue();

        if (visited.Contains(node.Node))
          continue;

        visited.Add(node.Node);

        foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node.Node, infos))
        {          
          if (visited.Contains(edge))
          {
            List<INode<T>> loop = new List<INode<T>>();
            if (IsUpperInTree(node, edge, loop))
            {
              myCallback.OnLoopFound(loop);
            } else
            {
              queue.Enqueue(new SearchTreeNode(null, edge));
            }            
          }
          else
          {
            queue.Enqueue(new SearchTreeNode(node, edge));
          }
        }
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
        Hash = COMPARER.GetHashCode(node.Coordinate);
      }

      public bool IsNode(INode<T> node)
      {
        return COMPARER.Equals(Node.Coordinate, node.Coordinate);
      }
    }
  }
}