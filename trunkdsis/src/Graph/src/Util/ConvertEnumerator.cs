using System.Collections;
using System.Collections.Generic;

namespace DSIS.Graph.Util
{
  public class ConvertEnumerator<TFrom, TTo> :
    IEnumerable<TTo>, IEnumerator<TTo>
  {
    private readonly IEnumerator<TFrom> myEnumberator;

    public ConvertEnumerator(IEnumerable<TFrom> enumberator)
    {
      myEnumberator = enumberator.GetEnumerator();
    }

    public ConvertEnumerator(IEnumerator<TFrom> enumberator)
    {
      myEnumberator = enumberator;
    }

    public IEnumerator GetEnumerator()
    {
      return this;
    }

    IEnumerator<TTo> IEnumerable<TTo>.GetEnumerator()
    {
      return this;
    }

    public void Dispose()
    {
      myEnumberator.Dispose();
    }

    object IEnumerator.Current
    {
      get { return myEnumberator.Current; }
    }

    TTo IEnumerator<TTo>.Current
    {
      get { return (TTo) (object) myEnumberator.Current; }
    }

    public bool MoveNext()
    {
      return myEnumberator.MoveNext();
    }

    public void Reset()
    {
      myEnumberator.Reset();
    }
  }
}