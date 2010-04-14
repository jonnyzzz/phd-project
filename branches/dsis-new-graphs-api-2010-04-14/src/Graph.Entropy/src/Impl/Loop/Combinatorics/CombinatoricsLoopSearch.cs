using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;

namespace DSIS.Graph.Entropy.Impl.Loop.Combinatorics
{
  //todo: can be easyly parallelized
  public class CombinatoricsLoopSearch<T,N> : ILoopIterator
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly IEqualityComparer<N> COMPARER;
    
    private readonly ILoopIteratorCallback<T,N> myCallback;
    private readonly IReadonlyGraph<T, N> myGraph;
    private readonly Queue<SearchNode> myNodes;
    private int myQueueLength;
    
    public CombinatoricsLoopSearch(ILoopIteratorCallback<T,N> callback, IReadonlyGraph<T,N> graph, int queueLength)
    {
      COMPARER = graph.Comparer;
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
      public bool Contains(N node, IEqualityComparer<N> cmp)
      {
        for(var it = Last;it != null; it = it.Parent)
        {
          if (cmp.Equals(node, it.FinishNode))
            return true;
        }
        return false;
      }
    }

    private void OnLoopFound(SearchItem item)
    {
      var nodes = new List<N>();
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
          if (myQueueLength-- > 0 && !node.Contains(edge, COMPARER) && lastValue < holder.GetData(edge))
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