using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.BoxIterators.Generator;

namespace DSIS.IntegerCoordinates.Impl
{
  internal sealed class OverlappingProcessor<T, Q> : IPointProcessor<Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private readonly T myCoordinateSystem;
    private readonly long[] myPoint;
    private readonly long[] myPoint2;
    private readonly long[] myPoint3;
    private readonly long[] myPoint4;
    private readonly long[] myZeros;
    private readonly long[] myOnes;
    private readonly double[] myOLeft;
    private readonly double[] myORight;
    private readonly int myDim;

    private readonly IBoxIterator<long> myIterator;

    public OverlappingProcessor(T coordinateSystem, double[] percent)
    {
      myCoordinateSystem = coordinateSystem;

      myDim = myCoordinateSystem.Dimension;
      myPoint = new long[myDim];
      myPoint2 = new long[myDim];
      myPoint3 = new long[myDim];
      myPoint4 = new long[myDim];

      myIterator = BoxIteratorGenerator<long>.GenerateIterator(myDim);

      myZeros = new long[myDim];
      myOnes = new long[myDim];

      myOLeft = new double[myDim];
      myORight = new double[myDim];

      for (int i = 0; i < myDim; i++)
      {
        myZeros[i] = 0;
        myOnes[i] = 1;
        myOLeft[i] = myCoordinateSystem.CellSize[i] * percent[i];
        myORight[i] = myCoordinateSystem.CellSize[i] * (1 - percent[i]);
      }
    }

    public IEnumerable<Q> AddPoint(double[] value)
    {
      bool iter = false;
      for (int i = 0; i < myDim; i++)
      {
        myPoint[i] = myCoordinateSystem.ToInternal(value[i], i);
        double tmp = value[i] - myCoordinateSystem.ToExternal(myPoint[i], i);
        if (tmp <  + myOLeft[i])
        {
          myPoint2[i] = -1;
          iter = true;
        }
        else if (tmp > myORight[i])
        {
          myPoint2[i] = 1;
          iter = true;
        }
        else
          myPoint2[i] = 0;
      }

      if (!iter)
      {
        yield return myCoordinateSystem.Create(myPoint);
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
            myPoint4[i] = myPoint[i] + t;

            ok &= myCoordinateSystem.Intersects(myPoint4[i], i);
          }
          if (ok && (isFirst || fl))
            yield return myCoordinateSystem.Create(myPoint4);

          isFirst = false;
        }
      }
    }
  }
}