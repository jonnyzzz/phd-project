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

    public CountEnumerable(IEnumerable<T> enumerable, long count)
    {
      myEnumerable = enumerable;
      Count = (int) count;
    }

    #region IEnumerable<T> Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    #endregion
  }
}