using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates.Impl
{
  internal class IntegerCoordinateCellConverter<T, Q> : ICellCoordinateSystemConverter<Q, Q> 
    where T : IIntegerCoordinateSystem<Q> 
    where Q : IIntegerCoordinate<Q>
  {
    private T myFromSystem;
    private T myToSystem;
    private LongLBoxFixedDimentionMulIterator myBoxIterator;
    private long[] myDivision;
    private int myDim;

    public IntegerCoordinateCellConverter(T fromSystem,
                                          T toSystem, 
                                          long[] division)
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

    public ICellCoordinateSystem<Q> FromSystem
    {
      get { return myFromSystem; }
    }

    public IEnumerable<Q> Subdivide(Q coordinate)
    {
      long[] v = new long[myDim];
      for (int i = 0; i < myDim; i++)
      {
        v[i] = coordinate.GetCoordinate(i);
      } 

      foreach (long[] longs in myBoxIterator.Iterate(v, myDivision))
      {
        yield return myToSystem.Create(longs);
      }
    }

    public ICellCoordinateSystem<Q> ToSystem
    {
      get { return myToSystem; }
    }
  }
}