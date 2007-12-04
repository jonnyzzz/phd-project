using System;
using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class UpcastedEnumerable<TEnu, T, TC> : IEnumerable<TC> where T : TC where TEnu : IEnumerable<T>
  {
    private readonly TEnu myEnumerable;

    public UpcastedEnumerable(TEnu enumerable)
    {
      myEnumerable = enumerable;
    }

    #region IEnumerable<TC> Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myEnumerable.GetEnumerator();
    }

    IEnumerator<TC> IEnumerable<TC>.GetEnumerator()
    {
      return new UpcastedEnumerator<IEnumerator<T>, T, TC>(myEnumerable.GetEnumerator());
    }

    #endregion
  }

  public class UpcastedDictionary<TKey, TOldValue, TNewValue> /*: IDictionary<TKey, TNewValue>*/
    where TOldValue : TNewValue
  {
    private readonly IDictionary<TKey, TOldValue> myDictionary;

    public UpcastedDictionary(IDictionary<TKey, TOldValue> dictionary)
    {
      myDictionary = dictionary;
    }

    public bool ContainsKey(TKey key)
    {
      return myDictionary.ContainsKey(key);
    }

    public void Add(TKey key, TOldValue value)
    {
      Throw();
    }

    public bool Remove(TKey key)
    {
      Throw();
      return false;
    }

    public bool TryGetValue(TKey key, out TNewValue val)
    {
      TOldValue value;
      if (myDictionary.TryGetValue(key, out value))
      {
        val = value;
        return true;
      }
      else
      {
        val = default(TNewValue);
        return false;
      }
    }

    public TNewValue this[TKey key]
    {
      get { return myDictionary[key]; }
      set { Throw(); }
    }

    private static void Throw()
    {
      throw new NotSupportedException("Add not supported");
    }

    public ICollection<TKey> Keys
    {
      get { return myDictionary.Keys; }
    }

    public ICollection<TNewValue> Values
    {
      get {
        return null;// myDictionary.Values; 
      }
    }

    public void Add(KeyValuePair<TKey, TNewValue> item)
    {
      Throw();
    }

    public void Clear()
    {
      Throw();      
    }

    public bool Contains(KeyValuePair<TKey, TNewValue> item)
    {
      Throw();
      return false;
    }

    public void CopyTo(KeyValuePair<TKey, TNewValue>[] array, int arrayIndex)
    {
      Throw();
    }

    public bool Remove(KeyValuePair<TKey, TOldValue> item)
    {
      Throw();
      return false;
    }

    public int Count
    {
      get { return myDictionary.Count; }
    }

    public bool IsReadOnly
    {
      get { return true; }
    }

    public IEnumerator<KeyValuePair<TKey, TNewValue>> GetEnumerator()
    {
      return null;
    }

    /*IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable) myDictionary).GetEnumerator();
    }*/
  }
}