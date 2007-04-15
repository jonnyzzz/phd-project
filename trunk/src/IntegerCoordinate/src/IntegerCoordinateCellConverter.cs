using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  internal class IntegerCoordinateCellConverter : ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate>
  {
    private ICellCoordinateSystem<IntegerCoordinate> myFromSystem;
    private ICellCoordinateSystem<IntegerCoordinate> myToSystem;
    private LongLBoxFixedDimentionMulIterator myBoxIterator;
    private long[] myDivision;
    private int myDim;

    public IntegerCoordinateCellConverter(ICellCoordinateSystem<IntegerCoordinate> fromSystem,
                                          ICellCoordinateSystem<IntegerCoordinate> toSystem, long[] division)
    {
      myFromSystem = fromSystem;
      myToSystem = toSystem;
      myDivision = division;
      myDim = fromSystem.SystemSpace.Dimension;
      myBoxIterator = new LongLBoxFixedDimentionMulIterator(myDim);
    }

    public long[] Division
    {
      get { return myDivision; }
    }

    public ICellCoordinateSystem<IntegerCoordinate> FromSystem
    {
      get { return myFromSystem; }
    }

    public IEnumerable<IntegerCoordinate> Subdivide(IntegerCoordinate coordinate)
    {
      long[] v =coordinate.myCoordinate;

      foreach (long[] longs in myBoxIterator.Iterate(v, myDivision))
      {
        yield return new IntegerCoordinate((long[]) longs.Clone());
      }
    }

    public ICellCoordinateSystem<IntegerCoordinate> ToSystem
    {
      get { return myToSystem; }
    }
  }
}