using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete("Have to be tested")]
  public class AllEngesOnALoopGraphSearch<T> : LoopIteratorBase<T> 
    where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IStrongComponentInfo[] myComp;
        
    public AllEngesOnALoopGraphSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(callback, components, component)
    {
      if (myComponent == null)
        throw new ArgumentNullException("component");
      myComp = new[] { component };
    }

    public override void WidthSearch()
    {      
      var visited = new Hashset<INode<T>>();

      foreach (INode<T> node in myComponents.GetNodes(myComp))
      {
        if (visited.Contains(node))
          continue;

        foreach (var to in GetNodes(node))
        {
          if (visited.Contains(to))
            continue;

          var loop = new List<INode<T>> {node};

          for(var path = FindShortestLoop(node, to); path != null; path = path.Parent)
          {
            loop.Add(path.Node);
          }
          visited.AddRange(loop);
          
          myCallback.OnLoopFound(loop, loop.Count);
        }
      }
    }

    private IEnumerable<INode<T>> GetNodes(INode<T> node)
    {
      return myComponents.GetEdgesWithFilteredEdges(node, myComp);
    }

    private SearchNode FindShortestLoop(INode<T> toNode, INode<T> fromNode)
    {      
      var queue = new Queue<SearchNode>();
      queue.Enqueue(new SearchNode(fromNode));
      
      while (queue.Count > 0)
      {
        SearchNode node = queue.Dequeue();
        foreach (INode<T> to in GetNodes(node.Node))
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
      public readonly INode<T> Node;
      public readonly SearchNode Parent;

      public SearchNode(INode<T> node)
      {
        Node = node;
      }

      public SearchNode(INode<T> node, SearchNode parent)
      {
        Node = node;
        Parent = parent;
      }
    }
  }
}