using System;
using System.Collections;
using System.Collections.Generic;

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

    public static IEnumerable Safe(System.Collections.IEnumerable coll)
    {
      return coll ?? EmptyArray<object>.Instance;
    }
  }  
}