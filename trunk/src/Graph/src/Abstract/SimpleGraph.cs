using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class SimpleGraph<TCellCoordinate> :
    AbstractGraph<SimpleGraph<TCellCoordinate>, TCellCoordinate, SimpleNode<TCellCoordinate>>,
    IGraphExtension<SimpleNode<TCellCoordinate>, TCellCoordinate>
    where TCellCoordinate : ICellCoordinate<TCellCoordinate>
  {
    public SimpleGraph(ICellCoordinateSystem<TCellCoordinate> coordinateSystem) : base(coordinateSystem)
    {
    }

    #region IGraphExtension<SimpleNode<TCellCoordinate>,TCellCoordinate> Members

    public void EdgeAdded(SimpleNode<TCellCoordinate> from, SimpleNode<TCellCoordinate> to)
    {
    }

    SimpleNode<TCellCoordinate> IGraphExtension<SimpleNode<TCellCoordinate>, TCellCoordinate>.CreateNode(
      TCellCoordinate coordinate)
    {
      return new SimpleNode<TCellCoordinate>(coordinate);
    }

    public void NodeAdded(SimpleNode<TCellCoordinate> node)
    {
    }

    #endregion
  }

  public class SimpleNode<TCell> : Node<SimpleNode<TCell>, TCell>
    where TCell : ICellCoordinate<TCell>
  {
    public SimpleNode(TCell coordinate) : base(coordinate)
    {
    }
  }
}