using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class SimpleGraph<TCellCoordinate, TValue> :
    AbstractGraph<TCellCoordinate, SimpleNode<TCellCoordinate, TValue>, TValue>
    where TCellCoordinate : ICellCoordinate<TCellCoordinate>
  {
    public SimpleGraph(ICellCoordinateSystem<TCellCoordinate> coordinateSystem) : base(coordinateSystem)
    {
    }

    protected override SimpleNode<TCellCoordinate, TValue> CreateNode(TCellCoordinate coordinate)
    {
      return new SimpleNode<TCellCoordinate, TValue>(coordinate, default(TValue));
    }
  }

  public class SimpleNode<TCell, TValue> : Node<SimpleNode<TCell, TValue>, TCell, TValue> 
    where TCell : ICellCoordinate<TCell>
  {
    public SimpleNode(TCell coordinate, TValue value) : base(coordinate, value)
    {
    }
  }
}