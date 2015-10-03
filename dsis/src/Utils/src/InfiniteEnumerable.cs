using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class InfiniteEnumerable<T> : IEnumerable<T>
  {
    private readonly IEnumerable<T> myHost;

    public InfiniteEnumerable(IEnumerable<T> host)
    {
      myHost = host;
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new InfiniteEnumerator<T>(myHost.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable) myHost).GetEnumerator();
    }
  }

  public class InfiniteEnumerator<T> : IEnumerator<T>
  {
    private readonly IEnumerator<T> myEnumerator;

    public InfiniteEnumerator(IEnumerator<T> enumerator)
    {
      myEnumerator = enumerator;
    }

    public T Current
    {
      get { return myEnumerator.Current; }
    }

    public void Dispose()
    {
      myEnumerator.Dispose();
    }

    public bool MoveNext()
    {
      if (!myEnumerator.MoveNext())
      {
        myEnumerator.Reset();
        return myEnumerator.MoveNext();
      }
      return true;
    }

    public void Reset()
    {
      myEnumerator.Reset();
    }

    object IEnumerator.Current
    {
      get { return ((IEnumerator) myEnumerator).Current; }
    }
  }
}