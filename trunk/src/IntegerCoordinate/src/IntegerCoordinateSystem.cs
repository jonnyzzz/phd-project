using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates
{
  public class IntegerCoordinateSystem : IIntegerCoordinateSystem
  {
    private readonly ISystemSpace mySystemSpace;
    private readonly double[] myCellSize;
    private readonly double[] myCellSizeHalf;
    private readonly long[] mySubdivision;
    private readonly int myDimension;

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
    }

    public IntegerCoordinateSystem(ISystemSpace systemSpace) : this(systemSpace, systemSpace.InitialSubdivision)
    {
    }

    private static long Ceil(double v)
    {
      return (long)(v);
    }

    public IntegerCoordinate FromPoint(double[] point)
    {
      if (!SystemSpace.Contains(point))
        return null;

      return FromPointNoCheck(point);
    }

    internal IntegerCoordinate FromPointNoCheck(double[] point)
    {
      long[] coordinate = new long[Dimension];
      for (int i = Dimension - 1; i >= 0; i--)
      {
        coordinate[i] = ToInternal(point[i], i);
      }
      return new IntegerCoordinate(coordinate);      
    }

    internal long ToInternal(double point, int i)
    {
      return Ceil( (point - mySystemSpace.AreaLeftPoint[i])/CellSize[i]);
    }

    public void TopLeftPoint(IntegerCoordinate point, double[] output)
    {
      IntegerCoordinate coordinate = point;
      for (int i = 0; i < Dimension; i++)
      {
        output[i] = mySystemSpace.AreaLeftPoint[i] + CellSize[i]*coordinate.Coordinate[i];
      }
    }

    public IIntegerCoordinateCellImageBuilderAdapter CreateAdapter(ICellConnectionBuilder<IntegerCoordinate> builder)
    {
      return new IntegerCoordinateCellImageBuilderAdapter(builder, this);
    }

    private IntegerCoordinateSystem SubdividedCoordinateSystem(long[] division)
    {
      long[] div = new long[division.Length];
      for (int i = 0; i < div.Length; i++ )
      {
        div[i] = Subdivision[i]*division[i];
      }
      return new IntegerCoordinateSystem(SystemSpace, div);      
    }

    public ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> Subdivide(long[] division)
    {
      return new IntegerCoordinateCellConverter(this, SubdividedCoordinateSystem(division), division);
    }

    public IEnumerable<IntegerCoordinate> InitialSebdivision
    {
      get
      {
        long[] array = new long[Dimension];
        for (int i = 0; i < Dimension; i++)
        {
          array[i] = 0;
        }
        while (array[Dimension - 1] < Subdivision[Dimension - 1])
        {
          yield return new IntegerCoordinate((long[]) array.Clone());
          array[0]++;
          for (int i = 0; i < Dimension - 1; i++)
          {
            if (array[i] >= Subdivision[i])
            {
              array[i] = 0;
              array[i + 1]++;
            }
          }
        }
      }
    }

    public long InitialCellsCount
    {
      get { 
        long cnt = 1;
        foreach (long l in mySubdivision)
        {
          cnt *= l;
        }
        return cnt;
      }
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public double[] CellSize
    {
      get { return myCellSize; }
    }

    public double[] CellSizeHalf
    {
      get { return myCellSizeHalf; }
    }

    public long[] Subdivision
    {
      get { return mySubdivision; }
    }

    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }
  }
}