using System.Collections.Generic;

namespace DSIS.Utils
{
  public class BiDictionary<TK,TV>
  {
    private readonly Dictionary<TK, TV> myInput = new Dictionary<TK, TV>(EqualityComparerFactory<TK>.GetComparer());
    private readonly Dictionary<TV, TK> myOutput = new Dictionary<TV, TK>(EqualityComparerFactory<TV>.GetComparer());

    public void Add(TK key, TV value)
    {
      myInput[key] = value;
      myOutput[value] = key;
    }

    public bool GetKey(TK key, out TV value)
    {
      return myInput.TryGetValue(key, out value);
    }

    public bool GetValue(TV value, out TK key)
    {
      return myOutput.TryGetValue(value, out key);
    }

    public IEnumerable<TK> Keys()
    {
      return myInput.Keys;
    }

    public IEnumerable<TV> Values()
    {
      return myOutput.Keys;
    }
  }
}