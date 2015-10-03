using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates.Impl
{
  internal class IntegerCoordinateCellProjector<T, Q> : ICellCoordinateSystemProjector<Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private readonly T myFromSystem;
    private readonly T myToSystem;
    private readonly long[] myFactor;
    private readonly long[] myTmp;

    public IntegerCoordinateCellProjector(T fromSystem, T toSystem, long[] factor)
    {
      myFromSystem = fromSystem;
      myToSystem = toSystem;
      myFactor = factor;
      myTmp = new long[myFactor.Length];
    }

    public ICellCoordinateSystem<Q> FromSystem
    {
      get { return myFromSystem; }
    }

    public ICellCoordinateSystem<Q> ToSystem
    {
      get { return myToSystem; }
    }

    public Q Project(Q coordinate)
    {
      for(int i=0; i<myTmp.Length; i++)
      {
        myTmp[i] = coordinate.GetCoordinate(i)/myFactor[i];
      }
      return myToSystem.Create(myTmp);
    }
  }
}