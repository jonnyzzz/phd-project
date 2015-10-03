using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IRectProcessor<T> where T : ICellCoordinate
  {
    IEnumerable<T> ConnectCellToRect(double[] left, double[] right);
  }
}
