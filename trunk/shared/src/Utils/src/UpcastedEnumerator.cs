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

  public class UpcastedEnumerable<TEnu, T, TC> : IEnumerable<TC> where T : TC where TEnu : IEnumerable<T>
  {
    private readonly TEnu myEnumerable;

    public UpcastedEnumerable(TEnu enumerable)
    {
      myEnumerable = enumerable;
    }

    #region IEnumerable<TC> Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator<TC> IEnumerable<TC>.GetEnumerator()
    {
      return new UpcastedEnumerator<IEnumerator<T>, T, TC>(myEnumerable.GetEnumerator());
    }

    #endregion
  }
}