using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public interface IRectProcessor<T> where T : IIntegerCoordinate
  {
    IEnumerable<T> ConnectCellToRect(double[] left, double[] right);
  }
}
