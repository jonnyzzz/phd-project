using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IRadiusProcessor<T> where T : ICellCoordinate
  {
    IEnumerable<T> ConnectCellToRadius(double[] point, double[] radius);
  }
}