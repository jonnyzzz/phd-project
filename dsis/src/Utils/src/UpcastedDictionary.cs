using System;
using System.Collections;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class UpcastedDictionary<TKey, TOldValue, TNewValue> : IDictionary<TKey, TNewValue>
    where TOldValue : class, TNewValue
    where TNewValue : class 
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

    public void Add(TKey key, TNewValue value)
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
        return new UpcastedCollection<TNewValue, TOldValue>(myDictionary.Values);
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

    public bool Remove(KeyValuePair<TKey, TNewValue> item)
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
      foreach (KeyValuePair<TKey, TOldValue> pair in myDictionary)
      {
        yield return new KeyValuePair<TKey, TNewValue>(pair.Key, pair.Value);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return myDictionary.GetEnumerator();
    }
  }
}