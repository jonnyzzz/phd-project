using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IPointProcessor<T> where T : ICellCoordinate
  {
    IEnumerable<T> AddPoint(double[] value);
  }
}