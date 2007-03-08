using System.Collections.Generic;

namespace DSIS.Utils
{
  public class LongEqualityComparer : IEqualityComparer<long>
  {
    public static readonly IEqualityComparer<long> INSTANCE = new LongEqualityComparer();

    public bool Equals(long x, long y)
    {
      return x == y;
    }

    public int GetHashCode(long obj)
    {
      return (int)obj | (int)(obj >> 32);
    }
  }
}