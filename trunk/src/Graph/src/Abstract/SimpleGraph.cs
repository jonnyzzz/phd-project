using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class SimpleGraph<TCellCoordinate> :
    AbstractGraph<TCellCoordinate, SimpleNode<TCellCoordinate>>
    where TCellCoordinate : ICellCoordinate<TCellCoordinate>
  {
    public SimpleGraph(ICellCoordinateSystem<TCellCoordinate> coordinateSystem) : base(coordinateSystem)
    {
    }

    protected override SimpleNode<TCellCoordinate> CreateNode(TCellCoordinate coordinate)
    {
      return new SimpleNode<TCellCoordinate>(coordinate);
    }
  }

  public class SimpleNode<TCell> : Node<SimpleNode<TCell>, TCell> 
    where TCell : ICellCoordinate<TCell>
  {
    public SimpleNode(TCell coordinate) : base(coordinate)
    {
    }
  }
}