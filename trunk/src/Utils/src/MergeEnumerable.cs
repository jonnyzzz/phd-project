using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public static class MergeEnumerable<T>
  {
    public static IEnumerable<T> Merge(IEnumerable<IEnumerable<T>> elements)
    {
      foreach (IEnumerable<T> element in elements)
      {
        foreach (T t in element)
        {
          yield return t;
        }
      }
    }
  }
}