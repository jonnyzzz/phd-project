using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public abstract class GraphWeightSearchBase<T> : IGraphWeightSearch<T> where T : ICellCoordinate<T>
  {
    private readonly IGraphStrongComponents<T> myComponents;
    private readonly IStrongComponentInfo myComponent;
    private readonly IStrongComponentInfo[] myComponentInfos;
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public GraphWeightSearchBase(IGraphStrongComponents<T> components,
                                 IStrongComponentInfo component)
    {
      myComponents = components;
      myComponent = component;
      myComponentInfos = new IStrongComponentInfo[]{myComponent};
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

    public void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode)
    {
      IVisitedCollection visited = CreateVisitedCollection();
      Queue<SearchTreeNode> queue = new Queue<SearchTreeNode>();

      queue.Enqueue(new SearchTreeNode(null, anode));
      while (queue.Count > 0)
      {
        SearchTreeNode node = queue.Dequeue();

        if (visited.Contains(node))
          continue;

        visited.Visited(node);

        foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node.Node, myComponentInfos))
        {
          if (visited.IsInTree(node, edge))
          {
            List<INode<T>> loop = new List<INode<T>>();
            if (IsUpperInTree(node, edge, loop))
            {
              callback.OnLoopFound(loop);
            }
            else
            {
              queue.Enqueue(visited.CreateQueuedNodeIfNoLoop(node, edge));
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


    //todo: One instance per object!
    protected interface IVisitedCollection
    {
      bool Contains(SearchTreeNode node);
      bool IsInTree(SearchTreeNode from, INode<T> to);
      SearchTreeNode CreateQueuedNodeIfNoLoop(SearchTreeNode parent, INode<T> to);
      void Visited(SearchTreeNode node);
    }

    protected abstract class VisitedCollectionBase : IVisitedCollection
    {
      private readonly Hashset<INode<T>> myVisited =
        new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

      public bool Contains(SearchTreeNode node)
      {
        return myVisited.Contains(node.Node);
      }

      public abstract SearchTreeNode CreateQueuedNodeIfNoLoop(SearchTreeNode parent, INode<T> to);

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
}