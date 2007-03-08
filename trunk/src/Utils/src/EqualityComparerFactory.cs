using System;
using System.Collections.Generic;

namespace DSIS.Core.Coordinates
{
  public static class EqualityComparerFactory<T>
  {
    private static IEqualityComparer<T> myComparer = null;

    public static IEqualityComparer<T> GetComparer()
    {
      if (myComparer != null)
        return myComparer;

      if (typeof(long) == typeof(T))
      {
        myComparer = (IEqualityComparer<T>) LongEqualityComparer.INSTANCE;
      }
      else if (typeof(double) == typeof(T))
      {
        myComparer = (IEqualityComparer<T>)DoubleEqualityComparer.INSTANCE;
      }
      else
      {       
        object[] attrs = typeof (T).GetCustomAttributes(typeof (EqualityComparerAttribute), false);
        if (attrs.Length == 0)
        {
          myComparer = EqualityComparer<T>.Default;
        }
        else
        {
          EqualityComparerAttribute at = (EqualityComparerAttribute) attrs[0];
          myComparer = (IEqualityComparer<T>) Activator.CreateInstance(at.Comparer);
        }
      }

      return myComparer;
    }
  }
}