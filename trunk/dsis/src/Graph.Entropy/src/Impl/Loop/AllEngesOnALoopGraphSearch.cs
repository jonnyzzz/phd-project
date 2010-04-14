using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete("Have to be tested")]
  public class AllEngesOnALoopGraphSearch<T, N> : LoopIteratorBase<T, N> 
    where T : ICellCoordinate 
    where N : class, INode<T>
  {
    public AllEngesOnALoopGraphSearch(ILoopIteratorCallback<T, N> callback, IReadonlyGraphStrongComponents<T,N> components, IStrongComponentInfo component) 
      : base(callback, components, component)
    {
    }

    public override void WidthSearch()
    {      
      var visited = new HashSet<N>(COMPARER);

      foreach (N node in myAccessor.GetNodes())
      {
        if (visited.Contains(node))
          continue;

        foreach (var to in GetNodes(node))
        {
          if (visited.Contains(to))
            continue;

          var loop = new List<N> {node};

          for(var path = FindShortestLoop(node, to); path != null; path = path.Parent)
          {
            loop.Add(path.Node);
          }
          visited.UnionWith(loop);
          
          myCallback.OnLoopFound(loop, loop.Count);
        }
      }
    }

    private IEnumerable<N> GetNodes(N node)
    {
      return myAccessor.GetEdges(node);
    }

    private SearchNode FindShortestLoop(N toNode, N fromNode)
    {      
      var queue = new Queue<SearchNode>();
      queue.Enqueue(new SearchNode(fromNode));
      
      while (queue.Count > 0)
      {
        SearchNode node = queue.Dequeue();
        foreach (N to in GetNodes(node.Node))
        {
          if (COMPARER.Equals(to, toNode))
            return node;
          queue.Enqueue(new SearchNode(to, node));
        }
      }
      //can hardly imagine how it could happen for strong component.
      return null;
    }


    private class SearchNode
    {
      public readonly N Node;
      public readonly SearchNode Parent;

      public SearchNode(N node)
      {
        Node = node;
      }

      public SearchNode(N node, SearchNode parent)
      {
        Node = node;
        Parent = parent;
      }
    }
  }
}