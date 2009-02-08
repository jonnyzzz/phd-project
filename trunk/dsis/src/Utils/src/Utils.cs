using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSIS.Utils
{
  public static class Util
  {
    public static void OfType<T>(this object o, Action<T> act)
    {
      if (o is T)
      {
        act((T) o);
      }
    }
    
    public static Q OfType<T,Q>(this object o, Q def, Func<T,Q> act)
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

    public static void SafeDispose(this IDisposable d)
    {
      if (d != null)
        d.Dispose();
    }

    public static string JoinString<T>(this IEnumerable<T> enu, string separator)
    {
      return enu.JoinString(x => x.ToString(), separator);
    }

    public static string JoinString<T>(this IEnumerable<T> enu, Func<T,string> toString, string separator)
    {
      var sb = new StringBuilder();
      sb.JoinString(enu, toString, separator);
      return sb.ToString();
    }

    public static StringBuilder JoinString<T>(this StringBuilder sb, IEnumerable<T> enu, Func<T,string> toString, string separator)
    {
      return JoinString(sb, enu, (sb2, t) => sb2.Append(toString(t)), separator);
    }

    public static StringBuilder JoinString<T>(this StringBuilder sb, IEnumerable<T> enu, Action<StringBuilder, T> append, string separator)
    {
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
        append(sb, t);
      }
      return sb;
    }
  }  
}