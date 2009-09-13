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