using System.Collections.Generic;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  internal struct PointEqualityComparer : IEqualityComparer<Point>
  {
    public static PointEqualityComparer INSTANCE = new PointEqualityComparer();

    #region IEqualityComparer<Point> Members

    public bool Equals(Point x, Point y)
    {
      return x.EqualsInternal(y);
    }

    public int GetHashCode(Point obj)
    {
      return obj.GetHashCodeInternal();
    }

    #endregion
  }
}