using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Utils
{
  public class MultiHashDictionary<TK, TV> : Dictionary<TK, Hashset<TV>>
  {
    public new Hashset<TV> this[TK k]
    {
      get
      {
        Hashset<TV> tvs = base[k];
        if (tvs.Count == 0)
        {
          Remove(k);
          throw new KeyNotFoundException("Key was empty list. Thus it was auto removed");
        }
        return tvs;
      }
      set
      {
        if (value.Count > 0)
          base[k] = value;
        else Remove(k);
      }
    }

    public void Add(TK k, TV v)
    {
      Hashset<TV> l;
      if (TryGetValue(k, out l))
      {
        l.Add(v);
      }
      else
      {
        l = new Hashset<TV>();
        l.Add(v);
        this[k] = l;
      }
    }

    public bool ContainsPair(TK key, TV value)
    {
      Hashset<TV> set;
      return TryGetValue(key, out set) && set.Contains(value);
    }
  }
}