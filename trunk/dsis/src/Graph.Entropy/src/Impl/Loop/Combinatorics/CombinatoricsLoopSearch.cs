using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Combinatorics
{
  //todo: can be easyly parallelized
  public class CombinatoricsLoopSearch<T> : ILoopIterator
    where T : ICellCoordinate
  {
    private readonly int myQueueLength;
    private readonly ILoopIteratorCallback<T> myCallback;
    private readonly IGraph<T> myGraph;

    public CombinatoricsLoopSearch(ILoopIteratorCallback<T> callback, IGraph<T> graph, int queueLength)
    {
      myCallback = callback;
      myGraph = graph;
      myQueueLength = queueLength;

    }

    public void WidthSearch()
    {
      myGraph.DoGeneric(new With2(myQueueLength, myCallback));      
    }

    private class With2 : IGraphWith<T>
    {
      private readonly int myQueueLength;
      private readonly ILoopIteratorCallback<T> myCallback;

      public With2(int queueLength, ILoopIteratorCallback<T> callback)
      {
        myQueueLength = queueLength;
        myCallback = callback;
      }

      public void With<TNode>(IGraph<T, TNode> graph) 
        where TNode : Node<TNode, T>
      {
        new CombinatoricsLoopSearch<T, TNode>(myCallback, graph, myQueueLength).WidthSearch();
      }
    }
  }


  public class CombinatoricsLoopSearch<T, N> : ILoopIterator
    where T : ICellCoordinate
    where N : Node<N, T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();
    
    private readonly ILoopIteratorCallback<T> myCallback;
    private readonly IGraph<T, N> myGraph;
    private readonly Queue<SearchNode> myNodes;
    private int myQueueLength;
    
    public CombinatoricsLoopSearch(ILoopIteratorCallback<T> callback, IGraph<T,N> graph, int queueLength)
    {
      myCallback = callback;
      myQueueLength = queueLength;
      myGraph = graph;
      myNodes = new Queue<SearchNode>(myGraph.EdgesCount + myGraph.NodesCount);
    }
    
    private class SearchItem
    {
      public readonly N FinishNode;
      public readonly SearchItem Parent;


      public SearchItem(N finishNode) : this(finishNode, null)
      {
      }

      private SearchItem(N finishNode, SearchItem parentItem)
      {
        FinishNode = finishNode;
        Parent = parentItem;
      }

      public SearchItem Next(N node)
      {
        return new SearchItem(node, this);
      }
    }

    private class SearchNode
    {
      public readonly N First;
      public readonly SearchItem Last;

      public SearchNode(N oneNode) : this(oneNode, new SearchItem(oneNode))
      {
      }

      private SearchNode(N first, SearchItem last)
      {
        First = first;
        Last = last;
      }

      public SearchNode Next(N node)
      {
        return new SearchNode(First, Last.Next(node));
      }

      //todo: To slow!
      public bool Contains(N node)
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

    private void BuildNextNodes(SearchNode node, IGraphDataHolder<int, N> holder)
    {
      var first = node.First;
      var last = node.Last.FinishNode;
      int lastValue = holder.GetData(first);

      foreach (var edge in myGraph.GetEdgesInternal(last))
      {
        if (ReferenceEquals(edge, first))
        {
          OnLoopFound(node.Last);
        } else
        {
          if (myQueueLength-- > 0 && !node.Contains(edge) && lastValue < holder.GetData(edge))
          {
            myNodes.Enqueue(node.Next(edge));
          }
        }
      }
    }

    private void Init(IGraphDataHolder<int,N> holder)
    {
      int i = 0;
      foreach (var node in myGraph.NodesInternal)
      {
        myNodes.Enqueue(new SearchNode(node));
        holder.SetData(node, i++);
      }
    }

    private void Loop(IGraphDataHolder<int, N> holder)
    {
      while(myNodes.Count > 0)
      {
        SearchNode node = myNodes.Dequeue();

        BuildNextNodes(node, holder);
      }
    }

    public void WidthSearch()
    {
      using (var holder = myGraph.CreateDataHolder(_ => -1))
      {
        Init(holder);
        Loop(holder);
      }
    }
  }
}