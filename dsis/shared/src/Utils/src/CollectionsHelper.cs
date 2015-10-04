using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EugenePetrenko.Shared.Utils
{
  public static class CollectionsHelper
  {
    public static bool IsEmpty(this IEnumerable e)
    {
      foreach (var _ in e)
      {
        return false;
      }
      return true;
    }

    public static IEnumerable<T> Enum<T>(this T t)
    {
      return new[] {t};
    }

    public static IEnumerable<T> Merge<T>(this IEnumerable<T> collection, IEnumerable<T> other)
    {
      foreach (var t in collection)
      {
        yield return t;
      }
      foreach (var t in other)
      {
        yield return t;
      }
    }
    
    public static IList<T> Sort<T>(this IEnumerable<T> collection, IComparer<T> cmp)
    {
      var list = collection.ToList();
      list.Sort(cmp);
      return list;
    }

    public static void ForEach<T>(this IEnumerable<T> enu, Action<T> act)
    {
      foreach (var t in enu)
      {
        act(t);
      }
    }
  }
}