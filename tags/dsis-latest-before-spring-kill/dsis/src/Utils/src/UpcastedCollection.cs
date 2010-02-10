using System;
using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class UpcastedCollection<TNew, TOld> : ICollection<TNew>
    where TOld : class, TNew
    where TNew : class
  {
    private readonly ICollection<TOld> myCollection;

    private static void Throw()
    {
      throw new NotSupportedException("Operation is not supported");
    }

    public UpcastedCollection(ICollection<TOld> collection)
    {
      myCollection = collection;
    }

    public void Add(TNew item)
    {
      Throw();
    }

    public void Clear()
    {
      Throw();
    }

    public bool Contains(TNew item)
    {
      Throw();
      return false;
    }
    
    public void CopyTo(TNew[] array, int arrayIndex)
    {
      TOld[] tmp = new TOld[Count];
      myCollection.CopyTo(tmp, arrayIndex);
      for(int i = arrayIndex; i < Count; i++)
      {
        array[i] = tmp[i];
      }
    }

    public bool Remove(TNew item)
    {
      Throw();
      return false;
    }

    public int Count
    {
      get { return myCollection.Count; }
    }

    public bool IsReadOnly
    {
      get { return true; }
    }

    public IEnumerator<TNew> GetEnumerator()
    {
      return new UpcastedEnumerator<IEnumerator<TOld>, TOld, TNew>(myCollection.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myCollection.GetEnumerator();
    }
  }
}