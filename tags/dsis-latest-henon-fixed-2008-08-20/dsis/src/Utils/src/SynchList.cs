using System.Collections.Generic;

namespace DSIS.Utils
{
  public class SynchList<T>
  {
    private readonly object LOCK = new object();
    private readonly List<T> myList = new List<T>();

    public void Add(T value)
    {
      lock (LOCK)
      {
        myList.Add(value);
      }
    }

    public void Remove(T value)
    {
      lock (LOCK)
      {
        myList.Remove(value);
      }
    }

    public IEnumerable<T> Elements
    {
      get
      {
        lock (LOCK)
        {
          return new List<T>(myList);
        }
      }
    }

    public T[] ToArray()
    {
      lock (LOCK)
      {
        return myList.ToArray();
      }
    }

    public int Count
    {
      get
      {
        lock (LOCK)
        {
          return myList.Count;
        }
      }
    }
  }
}