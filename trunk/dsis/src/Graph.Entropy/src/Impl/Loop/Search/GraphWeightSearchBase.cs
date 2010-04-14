using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public abstract class GraphWeightSearchBase<T, TCollection> : IGraphWeightSearch<T> 
    where T : ICellCoordinate
    where TCollection : IVisitedCollection<T>, new()
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    private readonly IGraphStrongComponents<T> myComponents;
    private readonly IStrongComponentInfo myComponent;
    private readonly IStrongComponentInfo[] myComponentInfos;

    private readonly TCollection myCollection = new TCollection();

    protected GraphWeightSearchBase(IGraphStrongComponents<T> components,
                                 IStrongComponentInfo component)
    {
      myComponents = components;
      myComponent = component;
      myComponentInfos = new[]{myComponent};
    }

    private static bool IsUpperInTree(SearchTreeNode<T> root, INode<T> node, List<INode<T>> result)
    {
      long hash = COMPARER.GetHashCode(node.Coordinate);
      while (root != null)
      {
        result.Insert(0, root.Node);
        if (hash == root.Hash && root.IsNode(node))
        {
          return true;
        }
        root = root.Parent;
      }
      return false;
    }

    protected TCollection GetVisitedCollection()
    {
      return myCollection;
    }
    
    public virtual void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode)
    {
      myCollection.Clear();

      var queue = new Queue<SearchTreeNode<T>>();
      var loop = new List<INode<T>>();

      queue.Enqueue(new SearchTreeNode<T>(null, anode));
      while (queue.Count > 0)
      {
        SearchTreeNode<T> node = queue.Dequeue();

        if (myCollection.Contains(node))
          continue;

        myCollection.Visited(node);

        foreach (INode<T> edge in myComponents.GetEdgesWithFilteredEdges(node.Node, myComponentInfos))
        {          
          if (myCollection.IsInTree(node, edge))
          {
            loop.Clear();
            if (IsUpperInTree(node, edge, loop))
            {
              callback.OnLoopFound(loop, loop.Count);
            }
            else
            {
              queue.Enqueue(myCollection.CreateQueuedNodeIfNoLoop(node, edge));
            }
          }
          else
          {
            queue.Enqueue(node.Child(edge));
          }
        }
      }
    }

  }
}