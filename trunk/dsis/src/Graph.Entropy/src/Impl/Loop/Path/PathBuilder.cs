using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Path
{ 
  public class PathBuilder<T> where T : ICellCoordinate
  {
    private readonly IGraphStrongComponents<T> myComps;

    protected readonly Vector<NodePair<T>> myValues = new Vector<NodePair<T>>();
    private int myNorm = 0;
        
    public PathBuilder(IGraphStrongComponents<T> comps)
    {
      myComps = comps;
    }

    public void BuildPath()
    {
      foreach (IStrongComponentInfo info in myComps.Components)
      {
        IGraph<T> graph = myComps.AsGraph(new IStrongComponentInfo[] {info});
        BuildPath(graph, CollectionUtil.GetFirst(graph.Nodes));
      }      
    }

    private void BuildPath(IGraph<T> graph, INode<T> startNode)
    {
      INode<T> start = startNode;

      while(!ReferenceEquals(start, startNode) || myValues.Count != graph.EdgesCount)
      {
        INode<T> next = GetNextNode(graph, start);

        myValues.Add(new NodePair<T>(start.Coordinate, next.Coordinate), 1);
        myNorm++;

        start = next;
      }      
    }
    
    private static INode<T> GetNextNode(IGraph<T> graph, INode<T> from)
    {
      InfiniteEnumerator<INode<T>> outs = from.GetUserData<InfiniteEnumerator<INode<T>>>();

      if (outs == null)
        from.SetUserData(outs = new InfiniteEnumerator<INode<T>>(graph.GetEdges(from).GetEnumerator()));

      outs.MoveNext();
      return outs.Current;
    }

    public IGraphMeasure<T> Entropy()
    {
      return new GraphMeasure<T, NodePair<T>>(myValues.Dictionary, EqualityComparerFactory<T>.GetReferenceComparer(), myNorm);
    }    
  }   
}