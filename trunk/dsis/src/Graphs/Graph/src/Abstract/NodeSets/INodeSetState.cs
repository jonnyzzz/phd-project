using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract.NodeSets
{
  public interface INodeSetState<TNode, TCell> : INodeCollection<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    INodeSetState<TNode, TCell> AddIfNotReplace(TNode t, out bool wasAdded);    
  }
}