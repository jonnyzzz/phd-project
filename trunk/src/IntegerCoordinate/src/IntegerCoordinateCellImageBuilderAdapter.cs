using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Util;

namespace DSIS.IntegerCoordinates
{
  /// <summary>
  /// This class is not thread-safe. To use it from several threads use 
  /// several instances
  /// </summary>
  public class IntegerCoordinateCellImageBuilderAdapter : IIntegerCoordinateCellImageBuilderAdapter
  {
    private readonly ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    private readonly IntegerCoordinateSystem myCoordinateSystem;

    private long[] myLeft;
    private long[] myRight;
    private long[] myPoint;
    private long[] myPoint2;
    private long[] myPoint3;

    private long[] myZeros;
    private long[] myOnes;

    private double[] myDLeft;
    private double[] myDRight;
    private double[] myZeroEps;
    private double[] myPercLeft;
    private double[] myPercRight;
    private BoxIterator<long> myIterator;

    internal IntegerCoordinateCellImageBuilderAdapter(ICellConnectionBuilder<IntegerCoordinate> builder,
                                                      IntegerCoordinateSystem coordinateSystem)
    {
      myBuilder = builder;
      myCoordinateSystem = coordinateSystem;

      myLeft = new long[myCoordinateSystem.Dimension + 1];
      myRight = new long[myCoordinateSystem.Dimension + 1];
      myPoint = new long[myCoordinateSystem.Dimension];
      myPoint2 = new long[myCoordinateSystem.Dimension];
      myPoint3 = new long[myCoordinateSystem.Dimension];

      myDLeft = new double[myCoordinateSystem.Dimension];
      myDRight = new double[myCoordinateSystem.Dimension];
      myZeroEps = new double[myCoordinateSystem.Dimension];
      myPercLeft = new double[myCoordinateSystem.Dimension];
      myPercRight = new double[myCoordinateSystem.Dimension];
      myIterator = new BoxIterator<long>(myCoordinateSystem.Dimension);
      
      myZeros = new long[myCoordinateSystem.Dimension];
      myOnes = new long[myCoordinateSystem.Dimension];

      for (int i = 0; i < myZeroEps.Length; i++)
      {
        myZeroEps[i] = 0;
        myZeros[i] = 0;
        myOnes[i] = 1;
      }
    }

    public void ConnectCellToRect(IntegerCoordinate from, double[] left, double[] right, double[] eps)
    {
      myBuilder.ConnectToMany(from, ConnectCellToRectInternal(left, right, eps));
    }

    private IEnumerable<IntegerCoordinate> ConnectCellToRectInternal(double[] left, double[] right, double[] eps)
    {
      if (!myCoordinateSystem.SystemSpace.ContainsRect(left, right))
        yield break;

      for (int i = 0; i < myCoordinateSystem.Dimension; i++)
      {
        double e = eps[i] * myCoordinateSystem.CellSize[i];

        myLeft[i] = myCoordinateSystem.ToInternal(left[i] - e, i);
        if (myLeft[i] < 0)
          myLeft[i] = 0;

        myRight[i] = myCoordinateSystem.ToInternal(right[i] + e, i);
        if (myRight[i] > myCoordinateSystem.Subdivision[i])
          myRight[i] = myCoordinateSystem.Subdivision[i] - 1;

        myPoint[i] = myLeft[i];
      }

      bool exit = false;
      while (!exit)
      {
        IntegerCoordinate coordinate = new IntegerCoordinate((long[])myPoint.Clone());
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

    public void ConnectCellToPointWithRadius(IntegerCoordinate cs, double[] point, double[] size)
    {
      {
        for (int i = 0; i < myCoordinateSystem.Dimension; i++)
        {
          myDLeft[i] = point[i] - size[i];
          myDRight[i] = point[i] + size[i];
        }

        ConnectCellToRect(cs, myDLeft, myDRight, myZeroEps);
      }
    }

    public void AddPointWithOverlappingPrepare(double[] percent, double[] lp, double[] rp)
    {
      for (int i = 0; i < myCoordinateSystem.Dimension; i++)
      {
        lp[i] = myCoordinateSystem.CellSize[i] * percent[i];
        rp[i] = myCoordinateSystem.CellSize[i] * (1 - percent[i]);
      }       
    }

    public void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percent)
    {
      AddPointWithOverlappingPrepare(percent, myPercLeft, myPercRight);
      myBuilder.ConnectToMany(cs, AddPointWithOverlappingInternal(point, myPercLeft, myPercRight));
    }

    public void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percentLeft, double[] percentRight)
    {
      myBuilder.ConnectToMany(cs, AddPointWithOverlappingInternal(point, percentLeft, percentRight));
    }


    private IEnumerable<IntegerCoordinate> AddPointWithOverlappingInternal(double[] value, double[] distL, double[] distR)
    {
      bool iter = false;
      for (int i = 0; i < myCoordinateSystem.Dimension; i++)
      {
        myPoint[i] = myCoordinateSystem.ToInternal(value[i], i);
        double tmp = myCoordinateSystem.ToExternal(myPoint[i], i);
        if (value[i] < tmp + distL[i])
        {
          myPoint2[i] = -1;
          iter = true;
        }
        else if (value[i] > tmp + distR[i])
        {
          myPoint2[i] = 1;
          iter = true;
        }
        else
          myPoint2[i] = 0;
      }

      if (!iter)
      {
        yield return new IntegerCoordinate((long[])myPoint.Clone());
      }
      else
      {
        bool isFirst = true;
        foreach (long[] ts in myIterator.EnumerateBox(myZeros, myOnes, myPoint3))
        {
          bool fl = false;
          bool ok = true;

          for (int i = 0; i < myCoordinateSystem.Dimension; i++)
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
  }
}