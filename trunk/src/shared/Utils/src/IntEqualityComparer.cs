using System.Collections.Generic;

namespace DSIS.Utils
{
  public class IntEqualityComparer : IEqualityComparer<int>
  {
    public static readonly IEqualityComparer<int> INSTANCE = new IntEqualityComparer();

    public bool Equals(int x, int y)
    {
      return x == y;
    }

    public int GetHashCode(int obj)
    {
      return obj;
    }
  }
}