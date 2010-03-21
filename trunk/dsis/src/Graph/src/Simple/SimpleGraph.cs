using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Simple
{
  public class SimpleGraph<TCellCoordinate> :
    AbstractGraph<SimpleGraph<TCellCoordinate>, TCellCoordinate, SimpleNode<TCellCoordinate>>,
    IGraphExtension<SimpleNode<TCellCoordinate>, TCellCoordinate>
    where TCellCoordinate : ICellCoordinate
  {
    public SimpleGraph(ICellCoordinateSystem<TCellCoordinate> coordinateSystem) : base(coordinateSystem)
    {
    }

    public void EdgeAdded(SimpleNode<TCellCoordinate> from, SimpleNode<TCellCoordinate> to)
    {
    }

    public override IEqualityComparer<SimpleNode<TCellCoordinate>> Comparer
    {
      get { return new NodeEqualityComparer<SimpleNode<TCellCoordinate>, TCellCoordinate>(); }
    }

    public bool HasArcToItself(SimpleNode<TCellCoordinate> node)
    {
      return GetEdgesInternal(node).Contains(node);
    }

    SimpleNode<TCellCoordinate> IGraphNodeFactory<SimpleNode<TCellCoordinate>, TCellCoordinate>.CreateNode(
      TCellCoordinate coordinate)
    {
      return new SimpleNode<TCellCoordinate>(coordinate);
    }

    public void NodeAdded(SimpleNode<TCellCoordinate> node)
    {
    }

    protected override SimpleGraph<TCellCoordinate> CreateGraph(ICellCoordinateSystem<TCellCoordinate> system)
    {
      return new SimpleGraph<TCellCoordinate>(system);
    }
  }

  public class SimpleNode<TCell> : Node<SimpleNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    public SimpleNode(TCell coordinate) : base(coordinate)
    {
    }
  }
}