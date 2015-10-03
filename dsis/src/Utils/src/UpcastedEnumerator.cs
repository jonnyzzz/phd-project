using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public sealed class UpcastedEnumerator<TEnu, T, TC> : IEnumerator<TC> where T : TC where TEnu : IEnumerator<T>
  {
    private readonly TEnu myEnumerable;

    public UpcastedEnumerator(TEnu enumerable)
    {
      myEnumerable = enumerable;
    }

    #region IEnumerator<TC> Members

    public object Current
    {
      get { return myEnumerable.Current; }
    }

    public void Dispose()
    {
      myEnumerable.Dispose();
    }

    TC IEnumerator<TC>.Current
    {
      get { return myEnumerable.Current; }
    }

    public bool MoveNext()
    {
      return myEnumerable.MoveNext();
    }

    public void Reset()
    {
      myEnumerable.Reset();
    }

    #endregion
  }
}