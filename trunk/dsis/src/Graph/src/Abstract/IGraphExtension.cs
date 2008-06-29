using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface IGraphNodeFactory<TNode, TCell>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {
    TNode CreateNode(TCell coordinate);
  }

  public interface IGraphExtension<TNode, TCell> : IGraphNodeFactory<TNode,TCell>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {        
    void NodeAdded(TNode node);
    void EdgeAdded(TNode from, TNode to);    
  }
}