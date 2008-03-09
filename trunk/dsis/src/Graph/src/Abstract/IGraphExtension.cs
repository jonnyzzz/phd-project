using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface IGraphExtension<TNode, TCell>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {    
    TNode CreateNode(TCell coordinate);
    void NodeAdded(TNode node);
    void EdgeAdded(TNode from, TNode to);
  }
}