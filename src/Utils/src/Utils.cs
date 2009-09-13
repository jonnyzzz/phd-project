using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EugenePetrenko.Shared.Utils
{
  public static class StringUtils
  {
    public static string JoinSomeOf<T>(this IEnumerable<T> enu,
                                       double percent,
                                       Func<T, double> weight,
                                       Func<T, string> toString)
    {
      double sum = percent*enu.Select(weight).Sum();
      var data = new List<string>();
      double cn = 0;
      bool overflow = false;
      foreach (var e in enu.OrderBy(weight).Reverse())
      {
        if (overflow)
        {
          data.Add("\u2026");
          break;
        }
        data.Add(toString(e));

        cn += weight(e);
        overflow = cn > sum;
      }
      return data.JoinString(", ");
    }

    public static string JoinString<T>(this IEnumerable<T> enu, string separator)
    {
      return enu.JoinString(x => x.ToString(), separator);
    }

    public static string JoinString<T>(this IEnumerable<T> enu, Func<T, string> toString, string separator)
    {
      var sb = new StringBuilder();
      sb.JoinString(enu, toString, separator);
      return sb.ToString();
    }

    public static StringBuilder JoinString<T>(this StringBuilder sb, IEnumerable<T> enu, Func<T, string> toString,
                                              string separator)
    {
      return JoinString(sb, enu, (sb2, t) => sb2.Append(toString(t)), separator);
    }

    public static StringBuilder JoinString<T>(this StringBuilder sb, IEnumerable<T> enu, Action<StringBuilder, T> append,
                                              string separator)
    {
      bool isFirst = true;
      foreach (var t in enu)
      {
        if (!isFirst)
        {
          sb.Append(separator);
        }
        else
        {
          isFirst = false;
        }
        append(sb, t);
      }
      return sb;
    }
  }
}