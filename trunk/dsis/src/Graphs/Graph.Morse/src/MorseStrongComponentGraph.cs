using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class MorseStrongComponentGraph<N,Q> : IMorseEvaluatorGraph<N> 
    where Q : ICellCoordinate 
    where N : class, INode<Q>
  {
    private readonly IReadonlyGraph<Q, N> myGraph;

    public MorseStrongComponentGraph(IReadonlyGraph<Q,N> graph)
    {
      myGraph = graph;
    }

    public IEnumerable<N> GetNodes(N node)
    {
      return myGraph.GetEdgesInternal(node);
    }

    public IEnumerable<N> GetNodes()
    {
      return myGraph.NodesInternal;
    }

    public IEqualityComparer<N> Comparer
    {
      get { return myGraph.Comparer; }
    }
  }
}