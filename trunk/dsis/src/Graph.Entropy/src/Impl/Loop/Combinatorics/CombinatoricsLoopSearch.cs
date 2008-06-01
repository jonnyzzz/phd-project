using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Combinatorics
{
  //todo: can be easyly parallelized
  public class CombinatoricsLoopSearch<T> : ILoopIterator
    where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER =
      EqualityComparerFactory<INode<T>>.GetReferenceComparer();


    private readonly ILoopIteratorCallback<T> myCallback;
    private readonly IGraph<T> myGraph;
    private readonly Queue<SearchNode> myNodes;
    private int myQueueLength;

    public CombinatoricsLoopSearch(ILoopIteratorCallback<T> callback, IGraph<T> graph, int queueLength)
    {
      myCallback = callback;
      myQueueLength = queueLength;
      myGraph = graph;
      myNodes = new Queue<SearchNode>(myGraph.EdgesCount + myGraph.NodesCount);
    }

    private class SearchItem
    {
      public readonly INode<T> FinishNode;
      public readonly SearchItem Parent;


      public SearchItem(INode<T> finishNode) : this(finishNode, null)
      {
      }

      private SearchItem(INode<T> finishNode, SearchItem parentItem)
      {
        FinishNode = finishNode;
        Parent = parentItem;
      }

      public SearchItem Next(INode<T> node)
      {
        return new SearchItem(node, this);
      }
    }

    private class SearchNode
    {
      public readonly INode<T> First;
      public readonly SearchItem Last;

      public SearchNode(INode<T> oneNode) : this(oneNode, new SearchItem(oneNode))
      {
      }

      private SearchNode(INode<T> first, SearchItem last)
      {
        First = first;
        Last = last;
      }

      public SearchNode Next(INode<T> node)
      {
        return new SearchNode(First, Last.Next(node));
      }

      //todo: To slow!
      public bool Contains(INode<T> node)
      {
        for(var it = Last;it != null; it = it.Parent)
        {
          if (COMPARER.Equals(node, it.FinishNode))
            return true;
        }
        return false;
      }
    }

    private void OnLoopFound(SearchItem item)
    {
      var nodes = new List<INode<T>>();
      for(; item != null; item = item.Parent)
      {
        nodes.Add(item.FinishNode);
      }
      nodes.Reverse();

      myCallback.OnLoopFound(nodes, nodes.Count);
    }

    private void BuildNextNodes(SearchNode node)
    {
      var first = node.First;
      var last = node.Last.FinishNode;
      Lazy<int> def = () => -1;
      int lastValue = first.GetUserData(def);

      foreach (var edge in myGraph.GetEdges(last))
      {
        if (ReferenceEquals(edge, first))
        {
          OnLoopFound(node.Last);
        } else
        {
          if (myQueueLength-- > 0 && !node.Contains(edge) && lastValue < edge.GetUserData(def))
          {
            myNodes.Enqueue(node.Next(edge));
          }
        }
      }
    }

    private void Init()
    {
      int i = 0;
      foreach (var node in myGraph.Nodes)
      {
        myNodes.Enqueue(new SearchNode(node));
        node.SetUserData(i++);
      }
    }

    private void Loop()
    {
      while(myNodes.Count > 0)
      {
        SearchNode node = myNodes.Dequeue();

        BuildNextNodes(node);
      }
    }

    public void WidthSearch()
    {
      Init();
      Loop();
    }
  }
}