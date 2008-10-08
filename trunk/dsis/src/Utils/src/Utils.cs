using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSIS.Utils
{
  public static class Util
  {
    public static Q Safe<T,Q>(T t, Q def, Converter<T,Q> conv)
      where T : class
    {
      return t == null ? def : conv(t);
    }

    public static IEnumerable<T> Safe<T>(IEnumerable<T> coll)
    {
      return coll ?? EmptyArray<T>.Instance;
    }

    public static IEnumerable Safe(IEnumerable coll)
    {
      return coll ?? EmptyArray<object>.Instance;
    }

    public static string JoinString<T>(this IEnumerable<T> enu, string separator)
    {
      var sb = new StringBuilder();
      bool isFirst = true;
      foreach (var t in enu)
      {
        if (!isFirst)
        {
          sb.Append(separator);
        } else
        {
          isFirst = false;
        }
        sb.Append(t);
      }
      return sb.ToString();
    }
  }  
}