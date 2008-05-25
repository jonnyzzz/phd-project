using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class CollectionUtil
  {
    public static T GetFirst<T>(this IEnumerable<T> enu)
    {
      foreach (T t in enu)
      {
        return t;
      }
      return default(T);
    }
    
    public static T GetLast<T>(this IEnumerable<T> enu)
    {
      T v = default(T);
      foreach (T t in enu)
      {
        v = t;
      }
      return v;
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

    public static IEnumerable<T> And<T,Q1,Q2>(IEnumerable<Q1> enu1, IEnumerable<Q2> enu2)
      where Q1 : T
      where Q2 : T
    {
      foreach (Q1 q1 in enu1)
      {
        yield return q1;
      }

      foreach (Q2 q2 in enu2)
      {
        yield return q2;
      }
    }

    public static IEnumerable<T> And<T>(params IEnumerable<T>[] enums)
    {
      foreach (IEnumerable<T> enumerable in enums)
      {
        foreach (T t in enumerable)
        {
          yield return t;
        }
      }
    }

    public static bool Contains<T>(IEnumerable<T> collection, T check)
    {
      IEqualityComparer<T> comparer = EqualityComparerFactory<T>.GetComparer();
      foreach (T item in collection)
      {
        if (comparer.Equals(item, check))
        {
          return true;
        }
      }
      return false;
    }

    public static int Count<T>(this IEnumerable<T> collection)
    {
      int count = 0;
      foreach (T t in collection)
      {
        count++;
      }
      return count;
    }

    public static T[] Fill<T>(int count, T data)
    {
      T[] t = new T[count];
      for (int i = 0; i < t.Length; i++)
      {
        t[i] = data;
      }
      return t;
    }

    public static List<T> AsList<T>(params T[] ts)
    {
      return new List<T>(ts);
    }

    public static IEnumerable<T> Map<T, Q>(this IEnumerable<Q> en, Converter<Q, T> conv)
    {
      foreach (var q in en)
      {
        yield return conv(q);
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

    private static bool AndEval(bool b1, bool b2)
    {
      return b1 && b2;
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
  }
}