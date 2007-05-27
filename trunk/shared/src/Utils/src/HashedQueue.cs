using System.Collections.Generic;

namespace DSIS.Utils
{
  public class HashedQueue<T>
  {
    private readonly Hashset<T> myHash;
    private readonly Queue<T> myQueue = new Queue<T>();

    public HashedQueue()
    {
      myHash = new Hashset<T>();
    }

    public HashedQueue(IEqualityComparer<T> comparer)
    {
      myHash = new Hashset<T>(comparer);
    }

    public T Dequeue()
    {
      T t = myQueue.Dequeue();
      myHash.Remove(t);
      return t;
    }

    public void Enqueue(T t)
    {
      if (myHash.AddIfNotReplace(ref t))
      {
        myQueue.Enqueue(t);
      }
    }

    public void Clear()
    {
      myQueue.Clear();
      myHash.Clear();
    }

    public bool IsEmpty
    {
      get { return myQueue.Count == 0; }
    }

    public override string ToString()
    {
      return string.Format("HashedQueue[ Count = {0} ]", myQueue.Count);
    }
  }
}