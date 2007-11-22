using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public sealed class PointEqualityComparer : IEqualityComparer<Point>
  {
    public static PointEqualityComparer INSTANCE = new PointEqualityComparer();

    public bool Equals(Point x, Point y)
    {
      return x.EqualsInternal(y);
    }

    public int GetHashCode(Point obj)
    {
      return obj.GetHashCodeInternal();
    }
  }
}