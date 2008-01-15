using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public interface IPointProcessor<T> where T : IIntegerCoordinate
  {
    IEnumerable<T> AddPoint(double[] value);
  }
}