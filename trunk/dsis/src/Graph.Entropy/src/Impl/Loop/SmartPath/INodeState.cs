using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public interface INodeState<T, TNode> where T : ICellCoordinate where TNode : class, INode<T>
  {
    INodeState<T, TNode> GetNextNode(IReadonlyGraph<T,TNode> thisGraph, TNode startNode, TNode thisNode, out TNode result, IGraphDataHolder<INodeState<T,TNode>, TNode> holder);
  }
}