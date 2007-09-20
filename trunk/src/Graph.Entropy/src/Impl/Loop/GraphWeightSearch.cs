using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Util;
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
            }
          }
          else
          {
            queue.Enqueue(new SearchTreeNode(node, edge));
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

  public class GraphWeightSearch<T> : GraphWeightSearchBase<T> where T : ICellCoordinate<T>
  {
    public GraphWeightSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                             IStrongComponentInfo component) : base(callback, components, component)
    {
    }

    protected override IVisitedCollection CreateVisitedCollection()
    {
      return new VisitedCollection();
    }

    private class VisitedCollection : IVisitedCollection
    {
      private readonly Hashset<INode<T>> myVisited =
        new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

      public bool Contains(SearchTreeNode node)
      {
        return myVisited.Contains(node.Node);
      }

      public bool IsInTree(SearchTreeNode from, INode<T> to)
      {
        return myVisited.Contains(to);
      }

      public void Visited(SearchTreeNode node)
      {
        myVisited.Add(node.Node);
      }
    }
  }

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