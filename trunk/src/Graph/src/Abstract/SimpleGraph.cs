using System;
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

    SimpleNode<TCellCoordinate> IGraphExtension<SimpleNode<TCellCoordinate>, TCellCoordinate>.CreateNode(
      TCellCoordinate coordinate)
    {
      return new SimpleNode<TCellCoordinate>(coordinate);
    }

    public void NodeAdded(SimpleNode<TCellCoordinate> node)
    {      
    }

    public void EdgeAdded(SimpleNode<TCellCoordinate> from, SimpleNode<TCellCoordinate> to)
    {     
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