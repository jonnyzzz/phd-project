using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public interface INodeState<T> where T : ICellCoordinate
  {
    INodeState<T> GetNextNode(IGraph<T> thisGraph, INode<T> startNode, INode<T> thisNode, out INode<T> result, IGraphDataHoler<INodeState<T>, INode<T>> holder);
  }
}