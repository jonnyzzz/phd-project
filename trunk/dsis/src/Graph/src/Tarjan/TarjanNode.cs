using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Tarjan
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    public TarjanNode(TCell coordinate) : base(coordinate)
    {
    }
  }  
}