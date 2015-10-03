using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class ThisNodeState<T> : INodeState<T> 
    where T : ICellCoordinate 
  {
    public INodeState<T> GetNextNode(IGraph<T> thisGraph, INode<T> startNode, INode<T> thisNode, out INode<T> result)
    {
      INodeState<T> state = new IteratorState<T>(thisGraph.GetEdges(thisNode).GetEnumerator());
      return state.GetNextNode(thisGraph, startNode, thisNode, out result);
    }
  }
}