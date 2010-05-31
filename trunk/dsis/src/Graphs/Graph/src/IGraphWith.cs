using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IGraphWith
  {
    void With<TCell, TNode>(IGraph<TCell, TNode> graph)
      where TCell : ICellCoordinate
      where TNode : Node<TNode, TCell>;
  }

  public interface IGraphWith<TCell>
    where TCell : ICellCoordinate
  {
    void With<TNode>(IGraph<TCell, TNode> graph)
      where TNode : Node<TNode, TCell>;
  }

}