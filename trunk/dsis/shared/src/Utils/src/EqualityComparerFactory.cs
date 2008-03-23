using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Utils
{
  public class EqualityComparerFactory<T> : AttributeUtil<T>
  {
    private static IEqualityComparer<T> myComparer = null;

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
        myComparer = (IEqualityComparer<T>) converter.GetField("INSTANCE", BindingFlags.Public | BindingFlags.Static).GetValue(null);        
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
      if (myComparer == null)
        throw new Exception("Failed to create comparer for type " + typeof (T).FullName);

      return myComparer;
    }

    public static IEqualityComparer<T> GetReferenceComparer()      
    {
      return new ReferenceEqualityComparer<T>();
    }
  }
}