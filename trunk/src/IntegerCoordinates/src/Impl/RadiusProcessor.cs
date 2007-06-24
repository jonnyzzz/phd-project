using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  internal sealed class RadiusProcessor<T, Q> : RectProcessorBase<T, Q>, IRadiusProcessor<Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q> 
  {
    public RadiusProcessor(T coordinateSystem) : base(coordinateSystem)
    {
    }

    public IEnumerable<Q> ConnectCellToRadius(double[] point, double[] radius)
    {
      if (!mySystemSpace.Contains(point))
        return EmptyArray<Q>.Instance;

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