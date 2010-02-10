using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class CollectionUtil
  {
    public static bool ContainsAny<Q,T>(this HashSet<Q> set, IEnumerable<T> enu)
      where T : Q
    {
      foreach (var t in enu)
      {
        if (set.Contains(t))
          return true;
      }
      return false;
    }

    public static bool ContainsAll<Q,T>(this HashSet<Q> set, IEnumerable<T> enu)
      where T : Q
    {
      foreach (var t in enu)
      {
        if (!set.Contains(t))
          return false;
      }
      return true;
    }

    public static IEnumerable<Q> Safe<Q>(this IEnumerable<Q> enu)
    {
      return enu ?? EmptyArray<Q>.Instance;
    }

    public static IEnumerable<T> Enum<T>(this T t)
    {
      return new[] {t};
    }

    public static List<T> Sort<T>(this IEnumerable<T> enu, Comparison<T> cmp)
    {
      var l = new List<T>(enu);
      l.Sort(cmp);
      return l;
    }

    public static bool IsEmpty<Q>(this IEnumerable<Q> enu)
    {
      foreach (var _ in enu)
        return false;
      return true;
    }

    public delegate Q Fold<T, Q>(T t, Q q);
    public static Q FoldLeft<T,Q>(this IEnumerable<T> enu, Q start, Fold<T,Q> fold)
    {
      Q q = start;
      foreach (var t in enu)
      {
        q = fold(t, q);
      }
      return q;
    }

    public static bool ContainsKeyRange<T,Q>(this Dictionary<T,Q> dic, IEnumerable<T> enu)
    {
      foreach (var t in enu)
      {
        if (!dic.ContainsKey(t))
          return false;
      }
      return true;
    }
    
    public static T Find<T>(this IEnumerable<T> enu, T def, Predicate<T> pred)
    {    
      foreach (var t in enu)
      {
        if (pred(t))
        {
          return t;
        }
      }
      return def;
    }

    public static IEnumerable<T> Merge<T>(IEnumerable<IEnumerable<T>> cs)
    {
      return Merge<T, T>(cs);
    }

    public static IEnumerable<TZ> Merge<TZ,T>(IEnumerable<IEnumerable<T>> cs) 
      where T : TZ
    {
      foreach (IEnumerable<T> c in cs)
      {
        foreach (T t in c)
        {
          yield return t;
        }
      }
    }

    public static ICollection<TZ> Merge<T1, T2, TZ>(IEnumerable<T1> c1, IEnumerable<T2> c2)
      where T1 : TZ
      where T2 : TZ
    {
      var list = new List<TZ>();
      foreach (T1 t1 in c1)
      {
        list.Add(t1);
      }
      foreach (T2 t2 in c2)
      {
        list.Add(t2);
      }
      return list.AsReadOnly();
    }

    public static IEnumerable<T> And<T>(IEnumerable<IEnumerable<T>> enums)
    {
      foreach (IEnumerable<T> enumerable in enums)
      {
        foreach (T t in enumerable)
        {
          yield return t;
        }
      }
    }

    public static T[] Fill<T>(this T data, int count)
    {
      var t = new T[count];
      for (int i = 0; i < t.Length; i++)
      {
        t[i] = data;
      }
      return t;
    }

    public static IEnumerable<int> Each(this int n)
    {
      for (int i = 0; i < n; i++) yield return i;
    }

    /// <summary>
    /// Enumerates integer range [from, to)
    /// </summary>
    public static IEnumerable<int> To(this int from, int to)
    {
      for (int i = from; i < to; i++) yield return i;
    }

    public static IEnumerable<T> Map<T, Q>(this IEnumerable<Q> en, Converter<Q, T> conv)
    {
      foreach (var q in en)
      {
        yield return conv(q);
      }
    }

    public static IEnumerable<T> Maps<T,Q>(this IEnumerable<Q> en, Converter<Q, IEnumerable<T>> conv)
    {
      foreach (var q in en)
      {
        foreach (var t in conv(q))
        {
          yield return t;
        }
      }
    }

    public static IEnumerable<T> MapNotNull<T, Q>(this IEnumerable<Q> en, Converter<Q, T> conv)
      where T : class
    {
      foreach (var q in en)
      {
        var notNull = conv(q);
        if (notNull != null)
          yield return notNull;
      }
    }

    public static void Zip<T,Q>(IEnumerable<T> ts, IEnumerable<Q> qs, Zip<T,Q> zip)
    {
      var te = ts.GetEnumerator();
      var qe = qs.GetEnumerator();

      TDelegate<bool> hasMore = delegate
                                        {
                                          var tb = te.MoveNext();
                                          var qb = qe.MoveNext();

                                          if (tb != qb)
                                            throw new ArgumentException("collections should be the same length");

                                          return tb & qb;
                                        };

      while (hasMore())
      {
        zip(te.Current, qe.Current);
      }
    }

    public static IEnumerable<R> Merge<T,Q,R>(IEnumerable<T> ts, IEnumerable<Q> qs, Func<T,Q,R> zip)
    {
      var te = ts.GetEnumerator();
      var qe = qs.GetEnumerator();

      TDelegate<bool> hasMore = delegate
                                        {
                                          var tb = te.MoveNext();
                                          var qb = qe.MoveNext();

                                          if (tb != qb)
                                            throw new ArgumentException("collections should be the same length");

                                          return tb & qb;
                                        };

      while (hasMore())
      {
        yield return zip(te.Current, qe.Current);
      }
    }

    public static IEnumerable<Q> Join<Q,T>(this IEnumerable<Q> enu, params T[] ex)
      where T : Q
    {
      return Join(enu, (IEnumerable<T>) ex);
    }

    public static IEnumerable<Q> Join<Q,T>(this IEnumerable<Q> enu, IEnumerable<T> ex)
      where T : Q
    {
      foreach (var q in enu)
      {
        yield return q;
      }
      foreach (var t in ex)
      {
        yield return t;
      }
    }

    public static IEnumerable<Q> En<Q>(this Q q)
    {
      yield return q;
    }
  }
}