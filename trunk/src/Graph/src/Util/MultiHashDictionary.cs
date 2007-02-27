using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Util;

namespace DSIS.Graph.Util
{
  public class MultiHashDictionary<TK, TV> : Dictionary<TK, Hashset<TV>>
  {
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
  }
}