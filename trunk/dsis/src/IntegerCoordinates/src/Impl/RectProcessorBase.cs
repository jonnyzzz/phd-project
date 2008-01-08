using System.Collections.Generic;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates.Impl
{
  public class RectProcessorBase<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected readonly long[] myLeft;
    protected readonly long[] myRight;
    protected readonly long[] myPoint;
    protected readonly int myDim;
    protected readonly T myCoordinateSystem;
    protected readonly ISystemSpace mySystemSpace;

    public RectProcessorBase(T coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;
      mySystemSpace = myCoordinateSystem.SystemSpace;
      myDim = myCoordinateSystem.Dimension;

      myLeft = new long[myDim + 1];
      myRight = new long[myDim + 1];
      myPoint = new long[myDim];
    }

    protected IEnumerable<Q> Enumerate()
    {
      bool exit = false;
      while (!exit)
      {
        yield return myCoordinateSystem.Create(myPoint);

        myPoint[0]++;
        for (int i = 0; i < myDim; i++)
        {
          if (myPoint[i] > myRight[i])
          {
            myPoint[i] = myLeft[i];
            if (i + 1 < myDim)
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