using System;
using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.Util;

namespace DSIS.IntegerCoordinates
{
  public class IntegerCoordinateSystem : IIntegerCoordinateSystem
  {
    private readonly ISystemSpace mySystemSpace;
    private readonly double[] myCellSize;
    private readonly double[] myCellSizeHalf;
    private readonly long[] mySubdivision;
    private readonly int myDimension;

    //from ISystemSpace. Optimization
    private readonly double[] myAreaLeftPoint;

    public IntegerCoordinateSystem(ISystemSpace systemSpace, long[] subdivision)
    {
      mySystemSpace = systemSpace;
      mySubdivision = subdivision;
      myDimension = subdivision.Length;

      if (mySystemSpace.Dimension != mySubdivision.Length)
        throw new ArgumentException("Incorrect dimention and length", "subdivision");

      myCellSize = new double[mySubdivision.Length];
      myCellSizeHalf = new double[mySubdivision.Length];

      for (int i = mySubdivision.Length - 1; i >= 0; i--)
      {
        myCellSize[i] = (mySystemSpace.AreaRightPoint[i] - mySystemSpace.AreaLeftPoint[i])/subdivision[i];
        myCellSizeHalf[i] = myCellSize[i]/2;
      }

      myAreaLeftPoint = mySystemSpace.AreaLeftPoint;
    }

    public IntegerCoordinateSystem(ISystemSpace systemSpace) : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    public double[] CellSize
    {
      get { return myCellSize; }
    }

    public double[] CellSizeHalf
    {
      get { return myCellSizeHalf; }
    }

    public IIntegerCoordinateCellImageBuilderAdapter CreateAdapter(ICellConnectionBuilder<IntegerCoordinate> builder)
    {
      return new IntegerCoordinateCellImageBuilderAdapter(builder, this);
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

      return FromPointNoCheck(point);
    }

    public long InitialCellsCount
    {
      get
      {
        long cnt = 1;
        foreach (long l in mySubdivision)
        {
          cnt *= l;
        }
        return cnt;
      }
    }

    public CountEnumerable<IntegerCoordinate> InitialSubdivision
    {
      get { return new CountEnumerable<IntegerCoordinate>(GetInitialSubdivision(), InitialCellsCount); }
    }

    public ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> Subdivide(long[] division)
    {
      return new IntegerCoordinateCellConverter(this, SubdividedCoordinateSystem(division), division);
    }

    public long[] Subdivision
    {
      get { return mySubdivision; }
    }

    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }

    public void TopLeftPoint(IntegerCoordinate point, double[] output)
    {
      IntegerCoordinate coordinate = point;
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(coordinate.Coordinate[i], i);
      }
    }

    private static long Ceil(double v)
    {
      return (long) (v);
    }

    internal IntegerCoordinate FromPointNoCheck(double[] point)
    {
      long[] coordinate = new long[myDimension];
      for (int i = myDimension - 1; i >= 0; i--)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return new IntegerCoordinate(coordinate);
    }

    public bool Intersects(long l, int axis)
    {
      return l >= 0 && l < mySubdivision[axis];
    }

    public long ToInternal(double point, int i)
    {
      return Ceil((point - myAreaLeftPoint[i])/myCellSize[i]);
    }

    public double ToExternal(long pt, int i)
    {
      return myAreaLeftPoint[i] + myCellSize[i]*pt;
    }

    public void CenterPoint(IntegerCoordinate point, double[] output)
    {
      long[] coordinate = point.Coordinate;
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(coordinate[i], i) + myCellSizeHalf[i];
      }
    }

    private IntegerCoordinateSystem SubdividedCoordinateSystem(long[] division)
    {
      long[] div = new long[myDimension];
      for (int i = 0; i < div.Length; i++)
      {
        div[i] = mySubdivision[i]*division[i];
      }
      return new IntegerCoordinateSystem(SystemSpace, div);
    }

    private IEnumerable<IntegerCoordinate> GetInitialSubdivision()
    {
      long[] array = new long[myDimension];
      for (int i = 0; i < myDimension; i++)
      {
        array[i] = 0;
      }

      long limit = mySubdivision[myDimension - 1];
      while (array[myDimension - 1] < limit)
      {
        yield return new IntegerCoordinate((long[]) array.Clone());
        array[0]++;
        for (int i = 0; i < myDimension - 1; i++)
        {
          if (array[i] >= mySubdivision[i])
          {
            array[i] = 0;
            array[i + 1]++;
          }
        }
      }
    }

    public int Dimension
    {
      get { return myDimension; }
    }
  }
}