using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface INode<TCoordinate> where TCoordinate : ICellCoordinate<TCoordinate>
  {
    TCoordinate Coordinate { get;}
  }
}