using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class WeakDictionary<TK, TV>
  {
    private readonly Dictionary<TK, WeakReference> myDictionary = new Dictionary<TK, WeakReference>(EqualityComparerFactory<TK>.GetComparer());

    public void Add(TK key, TV value)
    {
      myDictionary.Add(key, new WeakReference(value));
    }
    public bool TryGetValue(TK key, out TV value)
    {
      WeakReference wr;
      if (!myDictionary.TryGetValue(key, out wr))
      {
        value = default(TV);
        return false;
      }

      if (!wr.IsAlive)
      {
        value = default(TV);
        myDictionary.Remove(key);
        return false;
      }

      value = (TV) wr.Target;
      return true;
    }

    public void Remove(TK key)
    {
      myDictionary.Remove(key);
    }
  }
}