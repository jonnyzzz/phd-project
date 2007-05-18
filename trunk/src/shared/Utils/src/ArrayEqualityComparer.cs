using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Util
{
  public class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
  {
    public static readonly ArrayEqualityComparer<T> INSTANCE = new ArrayEqualityComparer<T>();
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public bool Equals(T[] x, T[] y)
    {
      for (int i = 0; i < y.Length; i++)
      {
        if (!COMPARER.Equals(x[i],y[i]))
          return false;
      }
      return true;
    }

    public int GetHashCode(T[] obj)
    {
      int v = 0;
      unchecked
      {
        for (int i = 0; i < obj.Length; i++)
        {
          v += obj[i].GetHashCode() * Primes.ByIndex(i);
        }
      }
      return v;
    }
  }
}