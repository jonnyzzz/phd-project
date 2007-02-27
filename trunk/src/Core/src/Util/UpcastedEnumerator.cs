using System.Collections;
using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public sealed class UpcastedEnumerator<T, TC> : IEnumerator<TC> where T: TC
  {
    private readonly IEnumerator<T> myEnumerable;

    public UpcastedEnumerator(IEnumerator<T> enumerable)
    {
      myEnumerable = enumerable;
    }
    
    TC IEnumerator<TC>.Current
    {
      get { return myEnumerable.Current; }
    }

    public void Dispose()
    {
      myEnumerable.Dispose();
    }

    public bool MoveNext()
    {
      return myEnumerable.MoveNext();
    }

    public void Reset()
    {
      myEnumerable.Reset();
    }

    public object Current
    {
      get { return myEnumerable.Current; }
    }
  }

  public class UpcastedEnumerable<T, TC> : IEnumerable<TC> where T: TC
  {
    private readonly IEnumerable<T> myEnumerable;

    public UpcastedEnumerable(IEnumerable<T> enumerable)
    {
      myEnumerable = enumerable;
    }

    IEnumerator<TC> IEnumerable<TC>.GetEnumerator()
    {
      return new UpcastedEnumerator<T, TC>(myEnumerable.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }
  }
}