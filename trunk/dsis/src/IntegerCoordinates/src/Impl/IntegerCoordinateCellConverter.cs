using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates.Impl
{
  internal class IntegerCoordinateCellConverter<T, Q> : ICellCoordinateSystemMultiplyConverter<Q> 
    where T : IIntegerCoordinateSystem<Q> 
    where Q : IIntegerCoordinate<Q>
  {
    private readonly T myFromSystem;
    private readonly T myToSystem;
    private readonly LongLBoxFixedDimentionMulIterator myBoxIterator;
    private readonly long[] myDivision;
    private readonly long[] myV;
    private readonly int myDim;

    public IntegerCoordinateCellConverter(T fromSystem,
                                          T toSystem, 
                                          long[] division)
    {
      myFromSystem = fromSystem;
      myToSystem = toSystem;
      myDivision = division;
      myDim = fromSystem.Dimension;
      myV = new long[myDim];
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
      for (int i = 0; i < myDim; i++)
      {
        myV[i] = coordinate.GetCoordinate(i);
      } 

      foreach (long[] longs in myBoxIterator.Iterate(myV, myDivision))
      {
        yield return myToSystem.Create(longs);
      }
    }

    public ICellCoordinateSystemConverter<Q, Q> Clone()
    {
      return new IntegerCoordinateCellConverter<T, Q>(myFromSystem, myToSystem, myDivision);
    }

    public ICellCoordinateSystem<Q> ToSystem
    {
      get { return myToSystem; }
    }
  }
}