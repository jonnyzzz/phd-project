using System.Collections.Generic;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public class RectProcessorBase
  {
    protected readonly long[] myLeft;
    protected readonly long[] myRight;
    protected readonly long[] myPoint;
    protected readonly int myDim;
    protected readonly IntegerCoordinateSystem myCoordinateSystem;
    protected readonly ISystemSpace mySystemSpace;

    public RectProcessorBase(IntegerCoordinateSystem coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;
      mySystemSpace = myCoordinateSystem.SystemSpace;
      myDim = myCoordinateSystem.SystemSpace.Dimension;

      myLeft = new long[myDim + 1];
      myRight = new long[myDim + 1];
      myPoint = new long[myDim];
    }

    protected IEnumerable<IntegerCoordinate> Enumerate()
    {
      bool exit = false;
      while (!exit)
      {
        IntegerCoordinate coordinate = new IntegerCoordinate((long[]) myPoint.Clone());
        yield return coordinate;

        myPoint[0]++;
        for (int i = 0; i < myCoordinateSystem.Dimension; i++)
        {
          if (myPoint[i] > myRight[i])
          {
            myPoint[i] = myLeft[i];
            if (i + 1 < myCoordinateSystem.Dimension)
              myPoint[i + 1]++;
            else
              exit = true;
          }
          else break;
        }
      }
    }
  }
}