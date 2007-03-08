using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.Core.Util;

namespace DSIS.IntegerCoordinates
{
  public sealed class OverlappingProcessor
  {
    private readonly IIntegerCoordinateSystem myCoordinateSystem;
    private readonly long[] myPoint;
    private readonly long[] myPoint2;
    private readonly long[] myPoint3;
    private readonly long[] myZeros;
    private readonly long[] myOnes;
    private readonly int myDim;

    private BoxIterator<long> myIterator;


    public OverlappingProcessor(IIntegerCoordinateSystem coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;

      myDim = myCoordinateSystem.SystemSpace.Dimension;
      myPoint = new long[myDim];
      myPoint2 = new long[myDim];
      myPoint3 = new long[myDim];

      myIterator = new BoxIterator<long>(myDim);

      myZeros = new long[myDim];
      myOnes = new long[myDim];

      for (int i = 0; i < myDim; i++)
      {
        myZeros[i] = 0;
        myOnes[i] = 1;
      }
    }


    public IEnumerable<IntegerCoordinate> AddPointWithOverlappingInternal(double[] value, double[] oLeft,
                                                                          double[] oRight)
    {
      bool iter = false;
      for (int i = 0; i < myDim; i++)
      {
        myPoint[i] = myCoordinateSystem.ToInternal(value[i], i);
        double tmp = value[i] - myCoordinateSystem.ToExternal(myPoint[i], i);
        if (tmp <  + oLeft[i])
        {
          myPoint2[i] = -1;
          iter = true;
        }
        else if (tmp > oRight[i])
        {
          myPoint2[i] = 1;
          iter = true;
        }
        else
          myPoint2[i] = 0;
      }

      if (!iter)
      {
        yield return new IntegerCoordinate((long[]) myPoint.Clone());
      }
      else
      {
        bool isFirst = true;
        foreach (long[] ts in myIterator.EnumerateBox(myZeros, myOnes, myPoint3))
        {
          bool fl = false;
          bool ok = true;

          for (int i = 0; i < myDim; i++)
          {
            long t = ts[i]*myPoint2[i];
            fl |= t != 0;
            ts[i] = myPoint[i] + t;

            ok &= myCoordinateSystem.Intersects(ts[i], i);
          }
          if (ok && (isFirst || fl))
            yield return new IntegerCoordinate((long[]) ts.Clone());

          isFirst = false;
        }
      }
    }

    public void AddPointWithOverlappingPrepare(double[] percent, double[] lp, double[] rp)
    {
      for (int i = 0; i < myDim; i++)
      {
        lp[i] = myCoordinateSystem.CellSize[i]*percent[i];
        rp[i] = myCoordinateSystem.CellSize[i]*(1 - percent[i]);
      }
    }
  }
}