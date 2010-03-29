using System.Collections.Generic;

namespace DSIS.Utils
{
  public class DoubleEqualityComparer : IEqualityComparer<double>
  {
    public static readonly DoubleEqualityComparer INSTANCE = new DoubleEqualityComparer();

    public bool Equals(double x, double y)
    {
      return x == y;
    }

    public int GetHashCode(double obj)
    {
      return obj.GetHashCode();
    }
  }
}