using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  [EqualityComparer(typeof(NodeEqualityComparer<>))]
  public interface INode<out TCoordinate>
    where TCoordinate : ICellCoordinate
  {
    TCoordinate Coordinate { get; }

    uint ComponentId { get; }

    //TODO: Move it somewhere!
    void SetComponentId(uint id);
  }
}