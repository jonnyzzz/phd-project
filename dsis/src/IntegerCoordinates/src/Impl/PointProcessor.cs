using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  public sealed class PointProcessor<T, Q> : IPointProcessor<Q>
    where T : IIntegerCoordinateSystem<Q> 
    where Q : IIntegerCoordinate
  {
    private readonly T myIcs;

    public PointProcessor(T ics)
    {
      myIcs = ics;
    }

    public IEnumerable<Q> AddPoint(double[] value)
    {
      var q = myIcs.FromPoint(value);
      return myIcs.IsNull(q) ? EmptyArray<Q>.Instance : new[]{q};
    }
  }
}