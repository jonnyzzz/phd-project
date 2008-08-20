using DSIS.Core.Util;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateCollection<T> : ICountEnumerable<T>
    where T : ICellCoordinate
  {
    ICellCoordinateSystem<T> System { get; }
  }
}