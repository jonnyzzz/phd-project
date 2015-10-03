using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class OrderedList<T> where T : IComparable<T>
  {
    private readonly List<T> myList = new List<T>();

    public bool Contains(T t)
    {
      int index = myList.BinarySearch(t);
      return (index >= 0);
    }

    public void Remove(T t)
    {
      myList.Remove(t);
    }

    public IEnumerable<T> Find(T t)
    {
      int index = myList.BinarySearch(t);
      if (index < 0)
      {
        index = ~index;
        if (index >= myList.Count)
          index = myList.Count - 1;
      }
      return EnumerateFromBeginning(index);
    }

    public bool IsLess(T t)
    {
      return myList.Count <= 0 || t.CompareTo(myList[0]) < 0;
    }

    public void Add(T t)
    {
      int index = myList.BinarySearch(t);
      if (index < 0)
      {
        index = ~index;
        myList.Insert(index, t);
      }
    }

    private IEnumerable<T> EnumerateFromBeginning(int index)
    {
      for (int i = 0; i <= index; i++)
      {
        yield return myList[i];
      }
    }

    public IList<T> Elements
    {
      get { return myList; }
    }
  }
}