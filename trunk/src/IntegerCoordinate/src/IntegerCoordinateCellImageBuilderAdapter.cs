using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

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

    internal IntegerCoordinateCellImageBuilderAdapter(ICellConnectionBuilder<IntegerCoordinate> builder,
                                                      IntegerCoordinateSystem coordinateSystem)
    {
      myBuilder = builder;
      myCoordinateSystem = coordinateSystem;

      myLeft = new long[myCoordinateSystem.Dimension + 1];
      myRight = new long[myCoordinateSystem.Dimension + 1];
      myPoint = new long[myCoordinateSystem.Dimension];
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
        double e = eps[i]*myCoordinateSystem.CellSize[i];

        myLeft[i] = myCoordinateSystem.ToInternal(left[i] - e, i);
        if (myLeft[i] < 0)
          myLeft[i] = 0;

        myRight[i] = myCoordinateSystem.ToInternal(right[i] + e, i);
        if (myRight[i] > myCoordinateSystem.Subdivision[i])
          myRight[i] = myCoordinateSystem.Subdivision[i]-1;

        myPoint[i] = myLeft[i];
      }

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