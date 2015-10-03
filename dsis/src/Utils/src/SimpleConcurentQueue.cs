using System;
using System.Collections.Generic;

namespace DSIS.Utils
{
  public class SimpleConcurentQueue<T>
  {
    private readonly Queue<T> myQueue = new Queue<T>();

    public int Count
    {
      get
      {
        lock (myQueue)
        {
          return myQueue.Count;
        }
      }
    }

    public void Enqueue(T elem)
    {
      lock (myQueue)
      {
        myQueue.Enqueue(elem);
      }
    }

    public T DequeueOrDefault()
    {
      lock (myQueue)
      {
        if (myQueue.Count > 0)
        {
          return myQueue.Dequeue();
        }
        return default(T);
      }
    }

    public void Clear()
    {
      lock(myQueue)
      {
        myQueue.Clear();
      }
    }

    public void ForEach(Action<T> action)
    {
      T[] array;
      lock(myQueue)
      {
        array = myQueue.ToArray();
      }
      foreach (var q in array)
      {
        action(q);
      }
    }
  }
}