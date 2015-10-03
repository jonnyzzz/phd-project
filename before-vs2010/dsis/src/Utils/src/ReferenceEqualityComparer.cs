using System.Collections.Generic;

namespace DSIS.Utils
{
  public class ReferenceEqualityComparer<T> : IEqualityComparer<T> 
  {
    public bool Equals(T x, T y)
    {
      return ReferenceEquals(x, y);
    }

    public int GetHashCode(T obj)
    {
      return 0;
    }
  }
}