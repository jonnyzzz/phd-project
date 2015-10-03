using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class ThisNodeState<T,TNode> : INodeState<T, TNode> 
    where T : ICellCoordinate 
    where TNode : class, INode<T>
  {
    public INodeState<T,TNode> GetNextNode(IReadonlyGraph<T,TNode> thisGraph, TNode startNode, TNode thisNode, out TNode result, IGraphDataHolder<INodeState<T,TNode>, TNode> holder)
    {
      INodeState<T,TNode> state = new IteratorState<T,TNode>(thisGraph.GetEdgesInternal(thisNode).GetEnumerator());
      return state.GetNextNode(thisGraph, startNode, thisNode, out result, holder);
    }
  }
}