using System;
using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class EqualityComparerFactory<T> : AttributeUtil<T>
  {
    private static IEqualityComparer<T> myComparer = null;


    public static IEqualityComparer GetOldComparer()
    {
      return new EqualityComparerProxy<T>(GetComparer());
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
      else if (typeof(int) == typeof(T))
      {
        myComparer = (IEqualityComparer<T>) IntEqualityComparer.INSTANCE;
      }
      else if (typeof(T).IsArray)
      {
        Type array = typeof (T).GetElementType();
        Type converter = typeof (ArrayEqualityComparer<>).MakeGenericType(array);
        myComparer = (IEqualityComparer<T>) Activator.CreateInstance(converter);
      }
      else
      {
        var at = GetAttributeInstance<EqualityComparerAttribute>();
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
      if (myComparer == null)
        throw new Exception("Failed to create comparer for type " + typeof (T).FullName);

      return myComparer;
    }

    public static IEqualityComparer<T> GetReferenceComparer()      
    {
      return new ReferenceEqualityComparer<T>();
    }
  }

  public class EqualityComparerProxy<T> : IEqualityComparer
  {
    private readonly IEqualityComparer<T> myImpl;

    public EqualityComparerProxy(IEqualityComparer<T> impl)
    {
      myImpl = impl;
    }

    bool IEqualityComparer.Equals(object x, object y)
    {
      if (x is T && y is T)
        return myImpl.Equals((T) x, (T) y);
      return false;
    }

    int IEqualityComparer.GetHashCode(object obj)
    {
      return myImpl.GetHashCode((T) obj);
    }
  }
}