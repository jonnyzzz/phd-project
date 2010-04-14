using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public static class DelegateComparer
  {
    public static IComparer<T> AsIComparer<T>(this Comparison<T> cmp)
    {
      return new DelegateComparer<T>(cmp);
    }
  }

  public class DelegateComparer<T> : IComparer<T>
  {
    private readonly Comparison<T> myComparer;

    public DelegateComparer(Comparison<T> comparer)
    {
      myComparer = comparer;
    }

    public int Compare(T x, T y)
    {
      return myComparer(x, y);
    }
  }
}