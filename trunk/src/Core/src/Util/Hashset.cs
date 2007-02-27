using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSIS.Core.Util
{
  public class Hashset<T> : IEnumerable<T>
  {
    private Dictionary<T, T> mySet;

    public Hashset()
    {
      mySet = new Dictionary<T, T>();
    }

    public Hashset(IEqualityComparer<T> comparer)
    {
      mySet = new Dictionary<T, T>(comparer);
    }

    public bool Contains(T t)
    {
      return mySet.ContainsKey(t);
    }

    public void Add(T t)
    {
      mySet[t] = t;
    }

    public void Clear()
    {
      mySet.Clear();
    }

    public void AddRange(IEnumerable<T> enums)
    {
      foreach (T t in enums)
      {
        Add(t);
      }
    }

    public void Remove(T t)
    {
      mySet.Remove(t);
    }

    public bool AddIfNotReplace(ref T t)
    {
      T obj;
      if (mySet.TryGetValue(t, out obj))
      {
        t = obj;
        return false;
      }
      else
      {
        Add(t);
        return true;
      }
    }

    public IEnumerable<T> Values
    {
      get { return mySet.Keys; }
    }

    public int Count
    {
      get { return mySet.Count; }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return Values.GetEnumerator();
    }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("{{Hashset: Count = {0} \r\n", Count);
      foreach (T t in Values)
      {
        sb.AppendFormat("{0}, ", t);
      }
      return sb + "\r\n}";
    }
  }

  public class Hashset<T, TC> : Hashset<T> where T : TC
  {
    public Hashset()
    {
    }

    public Hashset(IEqualityComparer<T> comparer) : base(comparer)
    {
    }

    public IEnumerable<TC> ValuesUpcasted
    {
      get {
        foreach (T t in Values)
        {
          yield return t;
        } 
      }
    }

    public void AddRange(Hashset<T, TC> h)
    {
      foreach (T t in h)
      {
        Add(t);
      }
    }
  }
}