using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.Util;

namespace DSIS.IntegerCoordinates
{
  public class IntegerCoordinateSystem : IntegerCoordinateSystemBase<IntegerCoordinate>, IIntegerCoordinateSystem<IntegerCoordinate>
  {
    public IntegerCoordinateSystem(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
    {
    }

    public IntegerCoordinateSystem(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    public CountEnumerable<IntegerCoordinate> InitialSubdivision
    {
      get { return new CountEnumerable<IntegerCoordinate>(GetInitialSubdivision(), GetInitialCellsCount()); }
    }

    public ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> Subdivide(long[] division)
    {
      return new IntegerCoordinateCellConverter(this, SubdividedCoordinateSystem(division), division);
    }

    public void TopLeftPoint(IntegerCoordinate point, double[] output)
    {
      IntegerCoordinate coordinate = point;
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(coordinate.GetCoordinate(i), i);
      }
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

      return FromPointNoCheck(point);
    }

    internal IntegerCoordinate FromPointNoCheck(double[] point)
    {
      long[] coordinate = new long[myDimension];
      for (int i = myDimension - 1; i >= 0; i--)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return Create(coordinate);
    }

    public IntegerCoordinate Create(params long[] param)
    {
      return new IntegerCoordinate(param);
    }

    public void CenterPoint(IntegerCoordinate point, double[] output)
    {
      for (int i = 0; i < myDimension; i++)
      {
        output[i] = ToExternal(point.GetCoordinate(i), i) + myCellSizeHalf[i];
      }
    }

    private IntegerCoordinateSystem SubdividedCoordinateSystem(long[] division)
    {
      return new IntegerCoordinateSystem(SystemSpace, GetSubdividedFactor(division));
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
        yield return Create((long[]) array.Clone());
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
  }
}