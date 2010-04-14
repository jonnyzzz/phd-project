using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public abstract class GraphWeightSearchBase<T, N, TCollection> : IGraphWeightSearch<T,N> 
    where T : ICellCoordinate
    where N : class, INode<T>
    where TCollection : IVisitedCollection<N>
  {
    protected readonly IEqualityComparer<N> NCOMPARER;
    private readonly IReadonlyGraphStrongComponentsAccessor<T, N> myAccessor;

    private readonly TCollection myCollection;

    protected GraphWeightSearchBase(IReadonlyGraphStrongComponents<T,N> components,
                                 IStrongComponentInfo component)
    {
      NCOMPARER = components.UnderlyingGraph.Comparer;
      myAccessor = components.Accessor(component.Enum());

      myCollection = CreateCollection();
    }

    protected abstract TCollection CreateCollection();

    private bool IsUpperInTree(SearchTreeNode<N> root, N node, List<N> result)
    {
      long hash = NCOMPARER.GetHashCode(node);
      while (root != null)
      {
        result.Insert(0, root.Node);
        if (hash == root.Hash && root.IsNode(node, NCOMPARER))
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
    
    public virtual void WidthSearch(ILoopIteratorCallback<T,N> callback, N anode)
    {
      myCollection.Clear();

      var queue = new Queue<SearchTreeNode<N>>();
      var loop = new List<N>();

      queue.Enqueue(new SearchTreeNode<N>(null, anode, NCOMPARER));
      while (queue.Count > 0)
      {
        SearchTreeNode<N> node = queue.Dequeue();

        if (myCollection.Contains(node))
          continue;

        myCollection.Visited(node);

        foreach (N edge in myAccessor.GetEdges(node.Node))
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
            queue.Enqueue(node.Child(edge, NCOMPARER));
          }
        }
      }
    }

  }
}