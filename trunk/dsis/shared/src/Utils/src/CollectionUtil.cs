using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class CollectionUtil
  {
    public static T GetFirst<T>(IEnumerable<T> enu)
    {
      foreach (T t in enu)
      {
        return t;
      }
      return default(T);
    }
  }
}