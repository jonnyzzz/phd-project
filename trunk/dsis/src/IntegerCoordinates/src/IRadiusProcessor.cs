using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public interface IRadiusProcessor<T> where T : IIntegerCoordinate
  {
    IEnumerable<T> ConnectCellToRadius(double[] point, double[] radius);
  }
}