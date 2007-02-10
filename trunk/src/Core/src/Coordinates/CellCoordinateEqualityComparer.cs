using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Core.Coordinates
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class EqualityComparerAttribute : Attribute
  {
    public readonly Type Comparer;

    public EqualityComparerAttribute(Type comparer)
    {
      Comparer = comparer;
    }
  }

  public static class EqualityComparerFactory<TCell>
  {
    private static IEqualityComparer<TCell> myComparer = null;

    public static IEqualityComparer<TCell> GetComparer()
    {
      if (myComparer != null)
        return myComparer;

      object[] attrs = typeof (TCell).GetCustomAttributes(typeof (EqualityComparerAttribute), false);
      if (attrs.Length == 0)
      {
        myComparer = EqualityComparer<TCell>.Default;
      } else
      {
        EqualityComparerAttribute at = (EqualityComparerAttribute) attrs[0];
        myComparer = (IEqualityComparer<TCell>) Activator.CreateInstance(at.Comparer);
      }

      return myComparer;
    }
  }
}
