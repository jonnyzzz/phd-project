using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSIS.Utils
{
  public static class Util
  {
    public static T[] Attach<T>(this T[] data, T obj)
    {
      if (data == null) return new[] {obj};

      return data.Join(obj.Enum()).ToArray();
    }

    public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> enu, int chunkSize)
    {
      var list = new List<T>();
      foreach (var e in enu)
      {
        list.Add(e);

        if (list.Count >= chunkSize)
        {
          yield return list;
          list = new List<T>();
        }
      }
      if (list.Count > 0)
        yield return list;      
    }

    private static List<T> FetchN<T>(IEnumerator<T> enu, int count)
    {
      var list = new List<T>();
      while(--count >= 0 && enu.MoveNext())
      {
        list.Add(enu.Current);
      }
      return list;
    }



    public static void ForEach<T>(this IEnumerable<T> enu, Action<T> act)
    {
      foreach (var t in enu)
      {
        act(t);
      }
    }

    public static Q OfType<T, Q>(this object o, Q def, Func<T, Q> act)
    {
      if (o is T)
      {
        return act((T) o);
      }
      return def;
    }

    public static X With<X>(this X x, Action<X> a)
    {
      a(x);
      return x;
    }

    public static Q Safe<T, Q>(this T t, Q def, Converter<T, Q> conv)
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

    public static void SafeDispose(this IDisposable d)
    {
      if (d != null)
        d.Dispose();
    }

    public static string JoinSomeOf<T>(this IEnumerable<T> enu,
                                       double percent,
                                       Func<T, double> weight,
                                       Func<T, string> toString)
    {
      double sum = percent*enu.FoldLeft(0.0, (x, q) => q + weight(x));
      var data = new List<string>();
      double cn = 0;
      bool overflow = false;
      foreach (var e in enu.Sort((x, y) => -(weight(x).CompareTo(weight(y)))))
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