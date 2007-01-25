using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public interface INode<TCoordinate, TNodeValue> where TCoordinate : ICellCoordinate<TCoordinate>
  {
    TCoordinate Coordinate { get;}
    TNodeValue Value { get; set; }
  }
}