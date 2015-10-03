using System.Collections.Generic;

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
      Q q = myIcs.FromPoint(value);
      if (myIcs.IsNull(q))
        yield break;
      else
        yield return q;
    }
  }
}