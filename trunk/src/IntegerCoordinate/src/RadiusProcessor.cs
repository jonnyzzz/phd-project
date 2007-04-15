using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.IntegerCoordinates
{
  public sealed class RadiusProcessor : RectProcessorBase, IRadiusProcessor
  {
    public RadiusProcessor(IntegerCoordinateSystem coordinateSystem) : base(coordinateSystem)
    {
    }

    public IEnumerable<IntegerCoordinate> ConnectCellToRadius(double[] point, double[] radius)
    {
      if (!mySystemSpace.Contains(point))
        return EmptyArray<IntegerCoordinate>.Instance;

      for (int i = 0; i < myDim; i++)
      {
        myLeft[i] = myCoordinateSystem.ToInternal(point[i] - radius[i], i);
        if (myLeft[i] < 0)
          myLeft[i] = 0;

        myRight[i] = myCoordinateSystem.ToInternal(point[i] + radius[i], i);
        if (myRight[i] > myCoordinateSystem.Subdivision[i])
          myRight[i] = myCoordinateSystem.Subdivision[i] - 1;

        myPoint[i] = myLeft[i];
      }

      return Enumerate();
    }
  }
}