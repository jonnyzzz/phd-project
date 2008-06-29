using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph
{
  public interface IDataHolder
  {
    bool HasData<T>();
    void SetData<T>(T data);
    T GetData<T>(Lazy<T> def);
  }

  [EqualityComparer(typeof(NodeEqualityComparer<>))]
  public interface INode<TCoordinate>
    where TCoordinate : ICellCoordinate
  {
    TCoordinate Coordinate { get; }

    uint ComponentId { get; }
  }
}