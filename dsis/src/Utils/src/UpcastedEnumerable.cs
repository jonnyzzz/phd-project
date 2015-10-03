using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  
  public class UpcastedEnumerable<TEnu, T, TC> : IEnumerable<TC> where T : TC where TEnu : IEnumerable<T>
  {
    private readonly TEnu myEnumerable;

    public UpcastedEnumerable(TEnu enumerable)
    {
      myEnumerable = enumerable;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator<TC> IEnumerable<TC>.GetEnumerator()
    {
      return new UpcastedEnumerator<IEnumerator<T>, T, TC>(myEnumerable.GetEnumerator());
    }
  }
}