using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
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
      Q q = myIcs.FromPoint(value);
      return q != null ? new Q[] {q} : EmptyArray<Q>.Instance;
    }
  }
}