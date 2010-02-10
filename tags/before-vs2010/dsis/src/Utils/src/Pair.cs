/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class Pair
  {
    public static Pair<A,B> Of<A,B>(A a, B b)
    {
      return Create(a, b);
    }

    [Obsolete("Use Pair.Of")]
    public static Pair<A,B> Create<A,B>(A a, B b)
    {
      return new Pair<A, B>(a,b);
    }
  }

  public struct Pair<TK, TV> : IEquatable<Pair<TK, TV>>
  {
    private static readonly IEqualityComparer<TK> ComparerK = EqualityComparerFactory<TK>.GetComparer();
    private static readonly IEqualityComparer<TV> ComparerV = EqualityComparerFactory<TV>.GetComparer();

    public readonly TK First;
    public readonly TV Second;

    public Pair(TK first, TV second)
    {
      First = first;
      Second = second;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Pair<TK, TV>)) return false;
      var pair = (Pair<TK, TV>) obj;
      return Equals(pair);      
    }

    public override int GetHashCode()
    {
      return (First != null ? ComparerK.GetHashCode(First) : 0) +
             29*(Second != null ? ComparerV.GetHashCode(Second) : 11);
    }

    private static string SafeToString<T>(T t)
    {
      if (t != null)
      {
        return t.ToString();
      }
      return "[Null]";
    }

    public override string ToString()
    {
      return "Pair" + "First: " + SafeToString(First) + " Second: " + SafeToString(Second);
    }

    public bool Equals(Pair<TK, TV> pair)
    {
      return ComparerK.Equals(First, pair.First) && ComparerV.Equals(Second, pair.Second);
    }
  }
}