using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
{
  public sealed class PointProcessor<T, Q> : IPointProcessor<Q>
    where T : IIntegerCoordinateSystem<Q> 
    where Q : IIntegerCoordinate<Q>
  {
    private readonly T myIcs;

    public PointProcessor(T ics)
    {
      myIcs = ics;
    }

    public IEnumerable<Q> AddPoint(double[] value)
    {
      Q q = myIcs.FromPoint(value);
      if (q != null)
        return new Q[] {q};
      else
        return EmptyArray<Q>.Instance;
    }
  }
}