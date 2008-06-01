using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete("Have to be tested")]
  public class AllNodesOnALoopGraphSearch<T> : LoopIteratorBase<T>
    where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IStrongComponentInfo[] myComp;

    public AllNodesOnALoopGraphSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components, IStrongComponentInfo component)
      : base(callback, components, component)
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

        var loop = new List<INode<T>>();
        for (SearchNode path = FindShortestLoop(node); path != null; path = path.Parent)
        {
          loop.Add(path.Node);
        }
        visited.AddRange(loop);

        myCallback.OnLoopFound(loop, loop.Count);
      }
    }

    private IEnumerable<INode<T>> GetNodes(INode<T> node)
    {
      return myComponents.GetEdgesWithFilteredEdges(node, myComp);
    }

    private SearchNode FindShortestLoop(INode<T> fromNode)
    {
      var queue = new Queue<SearchNode>();
      queue.Enqueue(new SearchNode(fromNode));

      while (queue.Count > 0)
      {
        SearchNode node = queue.Dequeue();
        foreach (INode<T> to in GetNodes(node.Node))
        {
          if (COMPARER.Equals(to, fromNode))
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