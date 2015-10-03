using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSIS.Utils
{
  public class Hashset<T> : IEnumerable<T>
  {
    private readonly Dictionary<T, T> mySet;

    public Hashset()
      : this(EqualityComparerFactory<T>.GetComparer())
    {
    }

    public Hashset(IEqualityComparer<T> comparer)
    {
      mySet = new Dictionary<T, T>(comparer);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return Values.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return Values.GetEnumerator();
    }

    public bool Contains(T t)
    {
      return mySet.ContainsKey(t);
    }

    public bool ContainsRange<Q>(IEnumerable<Q> enu) where Q:T
    {
      foreach (Q q in enu)
      {
        if (!Contains(q))
          return false;
      }
      return true;
    }

    public void Add(T t)
    {
      mySet[t] = t;
    }

    public void Clear()
    {
      mySet.Clear();
    }

    public void AddRange<P>(IEnumerable<P> enums) where P : T
    {
      foreach (P t in enums)
      {
        Add(t);
      }
    }

    public void Remove(T t)
    {
      mySet.Remove(t);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    /// <returns>
    /// true is object was added
    /// if false is returned than t will contain reference to stored object
    /// </returns>
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

    public static IEnumerable<T> Intersect(Hashset<T> h1, Hashset<T> h2)
    {
      if (h1.Count > h2.Count)
      {
        Hashset<T> t = h1;
        h1 = h2;
        h2 = t;
      }

      foreach (T node1 in h1)
      {
        if (h2.Contains(node1))
          yield return node1;
      }
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

    public T[] ToArray()
    {
      T[] result = new T[Count];
      int index = 0;
      foreach (T t in this)
      {
        result[index++] = t;
      }
      return result;
    }
  }

  public class Hashset<T, TC> : Hashset<T> where T : TC
  {
    public IEnumerable<TC> ValuesUpcasted
    {
      get { return new UpcastedEnumerable<IEnumerable<T>, T, TC>(Values); }
    }
  }
}