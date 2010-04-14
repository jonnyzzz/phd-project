using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface IReadonlyGraphWith
  {
    void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>;
  }

  public interface IReadonlyGraphWith<TCell>
    where TCell : ICellCoordinate
  {
    void With<TNode>(IReadonlyGraph<TCell, TNode> graph)
      where TNode : class, INode<TCell>;
  }
}