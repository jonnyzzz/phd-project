using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  [EqualityComparer(typeof(NodeEqualityComparer<>))]
  public interface INode<TCoordinate> where TCoordinate : ICellCoordinate
  {
    TCoordinate Coordinate { get; }
  }
}