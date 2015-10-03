using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse.Adapter
{
  public class GraphBasedNodesMap<Q,N, ANode> : IMorseEvaluatorNodesMap<N, ANode>
    where Q : ICellCoordinate
    where N : class, INode<Q>
  {
    private readonly IReadonlyGraph<Q, N> myGraph;
    private readonly IGraphDataHolder<ANode, N> myHolder;

    public GraphBasedNodesMap(IReadonlyGraph<Q, N> graph)
    {
      myGraph = graph;
      myHolder = myGraph.CreateDataHolder(x=>default(ANode));
    }

    public void Dispose()
    {
      myHolder.Dispose();
    }

    public ANode Find(N node)
    {
      return myHolder.GetData(node);
    }

    public void Put(N node, ANode value)
    {
      myHolder.SetData(node, value);
    }

    public IEnumerable<ANode> Nodes
    {
      get { return myGraph.NodesInternal.Select(n => myHolder.GetData(n)); }
    }

    public long Count
    {
      get { return myGraph.NodesCount; }
    }
  }
}