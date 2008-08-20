using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    public TarjanNode(TCell coordinate) : base(coordinate)
    {
    }
  }  
}