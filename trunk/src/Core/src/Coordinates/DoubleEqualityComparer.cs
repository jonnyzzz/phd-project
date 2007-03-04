using System.Collections.Generic;

namespace DSIS.Core.Coordinates
{
  public class DoubleEqualityComparer : IEqualityComparer<double>
  {
    public static readonly IEqualityComparer<double> INSTANCE = new DoubleEqualityComparer();

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