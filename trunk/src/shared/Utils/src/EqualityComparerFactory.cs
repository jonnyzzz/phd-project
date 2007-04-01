using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Utils
{
  public static class EqualityComparerFactory<T>
  {
    private static IEqualityComparer<T> myComparer = null;

    private static TA GetAttributeInstance<TA>() where TA : Attribute
    {
      Type type = typeof (T);
      object[] os = type.GetCustomAttributes(typeof (TA), true);
      return os.Length > 0 ? (TA) os[0] : default(TA);
    }

    //todo: Append attribute search login to find exact type.
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
        myComparer = (IEqualityComparer<T>) DoubleEqualityComparer.INSTANCE;
      }
      else
      {
        EqualityComparerAttribute at = GetAttributeInstance<EqualityComparerAttribute>();
        if (at != null)
        {
          Type comparer;
          if (at.Comparer.IsGenericTypeDefinition && typeof(T).IsGenericType)
          {            
            comparer = at.Comparer.MakeGenericType(typeof(T).GetGenericArguments());
          } else
          {
            comparer = at.Comparer;
          }
          myComparer = (IEqualityComparer<T>) Activator.CreateInstance(comparer);
        }
        else
        {
          myComparer = EqualityComparer<T>.Default;
        }
      }

      return myComparer;
    }
  }
}