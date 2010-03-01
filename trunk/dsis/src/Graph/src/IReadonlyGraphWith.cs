using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph
{
  public interface IReadonlyGraphWith
  {
    void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph)
      where TCell : ICellCoordinate
      where TNode : Node<TNode, TCell>;
  }

  public interface IReadonlyGraphWith<TCell>
    where TCell : ICellCoordinate
  {
    void With<TNode>(IReadonlyGraph<TCell, TNode> graph)
      where TNode : Node<TNode, TCell>;
  }
}