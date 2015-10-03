using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanGraph<TCell> :
    AbstractGraph<TarjanGraph<TCell>, TCell, TarjanNode<TCell>>,
    IGraphExtension<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    public TarjanGraph(ICellCoordinateSystem<TCell> coordinateSystem) : base(coordinateSystem)
    {
    }

    protected override TarjanGraph<TCell> CreateGraph(ICellCoordinateSystem<TCell> system)
    {
      return new TarjanGraph<TCell>(system);
    }

    public TarjanNode<TCell> CreateNode(TCell coordinate)
    {
      return new TarjanNode<TCell>(coordinate);
    }

    public void NodeAdded(TarjanNode<TCell> node)
    {      
    }

    public void EdgeAdded(TarjanNode<TCell> from, TarjanNode<TCell> to)
    {     
    }
  }
}