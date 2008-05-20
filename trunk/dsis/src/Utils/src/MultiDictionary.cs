using System.Collections.Generic;

namespace DSIS.Utils
{
  public class MultiDictionary<TK, TV> : Dictionary<TK, List<TV>>
  {
    public MultiDictionary(IEqualityComparer<TK> comparer) : base(comparer)
    {
    }

    public new List<TV> this[TK k]
    {
      get
      {
        List<TV> tvs = base[k];
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

    public List<TV> GetValues(TK k)
    {
      List<TV> list;
      return TryGetValue(k, out list) ? list : new List<TV>();
    }

    public void AddValue(TK k, TV v)
    {
      List<TV> l;
      if (TryGetValue(k, out l))
      {
        l.Add(v);
      }
      else
      {
        l = new List<TV>(2) {v};
        base[k] = l;
      }
    }
  }
}