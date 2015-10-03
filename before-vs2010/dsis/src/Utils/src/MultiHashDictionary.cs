using System.Collections.Generic;

namespace DSIS.Utils
{
  public class MultiHashDictionary<TK, TV> : Dictionary<TK, HashSet<TV>>
  {
    public HashSet<TV> GetValues(TK k)
    {
      HashSet<TV> set;
      if (TryGetValue(k, out set))
        return set;
      return new HashSet<TV>();
    }

    public new HashSet<TV> this[TK k]
    {
      get
      {
        HashSet<TV> tvs = base[k];
        if (tvs.Count == 0)
        {
          Remove(k);
          throw new KeyNotFoundException("Key was empty list. Thus it was auto removed");
        }
        return tvs;
      }
    }

    public void AddValues(TK k, IEnumerable<TV> vs)
    {
      HashSet<TV> l;
      if (TryGetValue(k, out l))
      {
        l.UnionWith(vs);
      }
      else
      {
        l = new HashSet<TV>(vs);
        base[k] = l;
      }
    }

    public void AddValue(TK k, TV v)
    {
      HashSet<TV> l;
      if (TryGetValue(k, out l))
      {
        l.Add(v);
      }
      else
      {
        l = new HashSet<TV> {v};
        base[k] = l;
      }
    }

    public void RemoveValue(TK k, TV v)
    {
      HashSet<TV> l;
      if (TryGetValue(k, out l))
      {
        l.Remove(v);
      }      
    }

    public bool ContainsPair(TK key, TV value)
    {
      HashSet<TV> set;
      return TryGetValue(key, out set) && set.Contains(value);
    }
  }
}