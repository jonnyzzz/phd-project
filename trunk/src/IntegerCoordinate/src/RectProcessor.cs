using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.IntegerCoordinates
{
  public sealed class RectProcessor : RectProcessorBase
  {
    private readonly double[] myEps;

    public RectProcessor(IntegerCoordinateSystem coordinateSystem, double[] eps) : base(coordinateSystem)
    {
      myEps = eps;
    }

    public IEnumerable<IntegerCoordinate> ConnectCellToRect(double[] left, double[] right)
    {
      if (!mySystemSpace.ContainsRect(left, right))
        return EmptyArray<IntegerCoordinate>.Instance;

      for (int i = 0; i < myDim; i++)
      {
        double e = myEps[i];

        myLeft[i] = myCoordinateSystem.ToInternal(left[i] - e, i);
        if (myLeft[i] < 0)
          myLeft[i] = 0;

        myRight[i] = myCoordinateSystem.ToInternal(right[i] + e, i);
        if (myRight[i] > myCoordinateSystem.Subdivision[i])
          myRight[i] = myCoordinateSystem.Subdivision[i] - 1;

        myPoint[i] = myLeft[i];
      }

      return Enumerate();
    }
  }
}