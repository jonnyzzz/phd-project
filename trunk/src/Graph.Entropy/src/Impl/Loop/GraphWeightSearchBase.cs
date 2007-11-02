using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public abstract class GraphWeightSearchBase<T> : LoopIteratorFirst<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public GraphWeightSearchBase(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                                 IStrongComponentInfo component) : base(callback, components, component)
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

    protected abstract IVisitedCollection CreateVisitedCollection();

    protected override void WidthSearch(long nodesCount, INode<T> anode)
    {
      IVisitedCollection visited = CreateVisitedCollection();
      Queue<SearchTreeNode> queue = new Queue<SearchTreeNode>();

      IStrongComponentInfo[] infos = new IStrongComponentInfo[] {myComponent};

      queue.Enqueue(new SearchTreeNode(null, anode));
      while (queue.Count > 0)
      {
        SearchTreeNode node = queue.Dequeue();

        if (visited.Contains(node))
          continue;

        visited.Visited(node);

        foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node.Node, infos))
        {
          if (visited.IsInTree(node, edge))
          {
            List<INode<T>> loop = new List<INode<T>>();
            if (IsUpperInTree(node, edge, loop))
            {
              myCallback.OnLoopFound(loop);
            }
            else
            {
              queue.Enqueue(new SearchTreeNode(null, edge));
//              queue.Enqueue(node.Child(edge));
            }            
          }
          else
          {
            queue.Enqueue(node.Child(edge));
          }
        }
      }
    }

    protected sealed class SearchTreeNode
    {
      public readonly SearchTreeNode Parent = null;
      public readonly INode<T> Node;
      public readonly int Hash;


      public SearchTreeNode(SearchTreeNode parent, INode<T> node, int hash)
      {
        Node = node;
        Parent = parent;
        Hash = hash;
      }

      public SearchTreeNode(SearchTreeNode parent, INode<T> node)
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

      public SearchTreeNode Child(INode<T> node)
      {
        return new SearchTreeNode(this, node);
      }

      public SearchTreeNode Root()
      {
        SearchTreeNode node = this;
        while (node.Parent != null)
          node = node.Parent;
        return node;        
      }
    }

    protected interface IVisitedCollection
    {
      bool Contains(SearchTreeNode node);
      bool IsInTree(SearchTreeNode from, INode<T> to);
      void Visited(SearchTreeNode node);
    }
  }
}