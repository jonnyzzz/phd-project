using System.Collections.Generic;

namespace DSIS.Utils
{
  public class IntEqualityComparer : IEqualityComparer<int>, IComparer<int>
  {
    public static readonly IntEqualityComparer INSTANCE = new IntEqualityComparer();

    public bool Equals(int x, int y)
    {
      return x == y;
    }

    public int GetHashCode(int obj)
    {
      return obj;
    }

    public int Compare(int x, int y)
    {
      return x - y;
    }
  }
}