using System.Collections.Generic;

namespace DSIS.LineIterator
{
  public class PointList<T> : IPointList<T>, IStackEnumerator<T>
  {
    private readonly LinkedList<T> myList;

    public PointList()
    {
      myList = new LinkedList<T>();
    }

    public void AddLast(T pt)
    {
      myList.AddLast(pt);
    }

    public T First
    {
      get { return myList.First.Value; }
    }

    public T Last
    {
      get { return myList.Last.Value; }
    }

    public int Count
    {
      get { return myList.Count; }
    }

    public void AddAll(IPointList<T> points)
    {
      foreach (var value in points.Values)
      {
        myList.AddLast(value);
      }
    }

    public IStackEnumerator<T> StackEnumerator()
    {
      return this;
    }

    public IEnumerable<T> Values
    {
      get { return myList; }
    }

    public bool IsEmpty
    {
      get { return myList.Count == 0; }
    }

    public T Peek()
    {
      return First;
    }

    public void Pop()
    {
      myList.RemoveFirst();
    }

    public void Push(T value)
    {
      myList.AddFirst(value);
    }
  }
}