using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public interface IRadiusProcessor
  {
    IEnumerable<IntegerCoordinate> ConnectCellToRadius(double[] point, double[] radius);
  }
}