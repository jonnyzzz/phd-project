using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class AllEngesOnALoopGraphSearch<T> : LoopIteratorBase<T> 
    where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IStrongComponentInfo[] myComp;
        
    public AllEngesOnALoopGraphSearch(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(callback, components, component)
    {
      if (myComponent == null)
        throw new ArgumentNullException("component");
      myComp = new IStrongComponentInfo[] { component };
    }

    public override void WidthSearch()
    {      
      Hashset<INode<T>> visited = new Hashset<INode<T>>();

      foreach (INode<T> node in myComponents.GetNodes(myComp))
      {
        if (visited.Contains(node))
          continue;

        foreach (INode<T> to in GetNodes(node))
        {
          if (visited.Contains(to))
            continue;

          List<INode<T>> loop = new List<INode<T>>();
          loop.Add(node);

          for(SearchNode path = FindShortestLoop(node, to); path != null; path = path.Parent)
          {
            loop.Add(path.Node);
          }
          visited.AddRange(loop);
          
          myCallback.OnLoopFound(loop);
        }
      }
    }

    private IEnumerable<INode<T>> GetNodes(INode<T> node)
    {
      return myComponents.GetEdgesWithFilteredEdges(node, myComp);
    }

    private SearchNode FindShortestLoop(INode<T> toNode, INode<T> fromNode)
    {      
      Queue<SearchNode> queue = new Queue<SearchNode>();
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
      public readonly SearchNode Parent = null;

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