using System.Collections;
using System.Collections.Generic;

namespace DSIS.Graph.Util
{
  public class ConvertEnumerator<TFrom, TTo> : 
    IEnumerable<TTo>, IEnumerator<TTo>  
  {
    private IEnumerator<TFrom> myEnumberator;

    public ConvertEnumerator(IEnumerable<TFrom> enumberator)
    {
      myEnumberator = enumberator.GetEnumerator();
    }

    public ConvertEnumerator(IEnumerator<TFrom> enumberator)
    {
      myEnumberator = enumberator;
    }

    TTo IEnumerator<TTo>.Current
    {
      get { return (TTo)(object)myEnumberator.Current; }
    }

    public void Dispose()
    {
      myEnumberator.Dispose();
    }

    public bool MoveNext()
    {
      return myEnumberator.MoveNext();
    }

    public void Reset()
    {
      myEnumberator.Reset();
    }

    IEnumerator<TTo> IEnumerable<TTo>.GetEnumerator()
    {
      return this;
    }

    public IEnumerator GetEnumerator()
    {
      return this;
    }

    object IEnumerator.Current
    {
      get { return myEnumberator.Current; }
    }
  }
}