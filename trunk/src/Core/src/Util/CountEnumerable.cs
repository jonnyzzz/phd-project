/*
 * Created by: 
 * Created: 5 февраля 2007 г.
 */

using System.Collections;
using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public struct CountEnumerable<T> : IEnumerable<T>
  {
    private readonly IEnumerable<T> myEnumerable;
    public readonly int Count;

    public CountEnumerable(IEnumerable<T> enumerable, int count)
    {
      myEnumerable = enumerable;
      Count = count;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }
  }
}