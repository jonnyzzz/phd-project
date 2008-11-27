/*
 * Created by: 
 * Created: 5 февраля 2007 г.
 */

using System.Collections;
using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public class CountEnumerable<T> : ICountEnumerable<T>
  {
    private readonly IEnumerable<T> myEnumerable;
    public readonly int Count;

    public CountEnumerable(IEnumerable<T> enumerable, long count)
    {
      myEnumerable = enumerable;
      Count = (int) count;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    int ICountEnumerable<T>.Count
    {
      get { return Count; }
    }
  }
}