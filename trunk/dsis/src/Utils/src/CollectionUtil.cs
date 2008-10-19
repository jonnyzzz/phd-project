using System;
using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class CollectionUtil
  {
    public delegate Q Fold<T, Q>(T t, Q q);

    public static IEnumerable<Q> Safe<Q>(this IEnumerable<Q> enu)
    {
      return enu ?? EmptyArray<Q>.Instance;
    }

    public static bool Empty<T>(this IEnumerable<T> enu)
    {
      foreach (var t in enu)
      {
        return false;
      }
      return true;
    }

    public static void Each<Q>(this IEnumerable<Q> enu, Action<Q> action)
    {
      foreach (Q q in enu)
      {
        action(q);
      }
    }

    public static bool IsEmpty<Q>(this IEnumerable<Q> enu)
    {
      foreach (var q in enu)
        return false;
      return true;
    }

    public static IEnumerable<T> Copy<T>(this IEnumerable<T> enu)
    {
      return new List<T>(enu);
    }

    public static IEnumerable<Q> Filter<Q>(this IEnumerable<Q> enu, Predicate<Q> pred)
    {
      foreach (var q in enu)
      {
        if (pred(q))
          yield return q;
      }
    }

    public static IEnumerable<P> Convert<Q,P>(this IEnumerable<Q> enu, Converter<Q,P> conv)
    {
      foreach (var q in enu)
      {
        yield return conv(q);
      }
    }

    public static Q FoldLeft<T,Q>(this IEnumerable<T> enu, Q start, Fold<T,Q> fold)
    {
      Q q = start;
      foreach (var t in enu)
      {
        q = fold(t, q);
      }
      return q;
    }

    public static List<T> ToList<T>(this IEnumerable<T> enu)
    {
      if (enu is List<T>)
        return (List<T>) enu;

      return new List<T>(enu);
    }

    public static T[] ToArray<T>(this IEnumerable<T> enu)
    {
      if (enu is List<T>)
      {
        return ((List<T>) enu).ToArray();
      }
      return new List<T>(enu).ToArray();
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

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> enu, int t)
    {
      foreach (var o in enu)
      {
        if (t == 0)
        {
          yield return o;
        } else
        {
          t--;
        }
      }
    }

    public static T Singleton<T>(this IEnumerable<T> enu)
    {
      T t = default(T);
      bool reached = false;
      foreach (T q in enu)
      {
        t = q;
        if (reached)
          throw new ArgumentException("Collection is expected to be singleton, too much elements");
        reached = true;
      }
      if (!reached)
        throw new ArgumentException("Collection is expected to be singleton, but not empty");
      return t;
    }

    public static T GetFirst<T>(this IEnumerable<T> enu)
    {
      foreach (T t in enu)
      {
        return t;
      }
      return default(T);
    }
    
    public static IEnumerable<T> First<T>(this IEnumerable<T> enu, int count)
    {
      int i = 0;
      foreach (T t in enu)
      {
        if (i++ < count)
          yield return t;
      }
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
      return And((IEnumerable<IEnumerable<T>>)enums);
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

    public static Dictionary<T,P> MapValues<T,P,Q>(this Dictionary<T,Q> dic, Converter<Q,P> conv)
    {
      var result = new Dictionary<T, P>(dic.Comparer);
      foreach (var pair in dic)
      {
        result.Add(pair.Key, conv(pair.Value));
      }
      return result;
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

    public static IEnumerable<R> Merge<T,Q,R>(IEnumerable<T> ts, IEnumerable<Q> qs, Merge<T,Q,R> zip)
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

    public static IEnumerable<TU> Upcast<TEnu, TU,TC>(this TEnu enu) 
      where TC : TU
      where TEnu : IEnumerable<TC>
    {
      return new UpcastedEnumerable<TEnu, TC, TU>(enu);
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

    public static IEnumerable<T> Cast<T>(this IEnumerable enu)
    {
      foreach (T t in enu)
      {
        yield return t;
      }
    }
  }
}