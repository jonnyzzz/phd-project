using System;
using System.Collections.Generic;
using DSIS.Persistance;

namespace DSIS.LineIterator
{
  public class WritingPointList<T> : IPointList<T>
  {
    private readonly Action<T> myWritePoint;    
    private T myFirstPoint;
    private T mylastPoint;
    private int myCount;

    public WritingPointList(Action<T> writePoint)
    {
      myWritePoint = writePoint;
    }

    public void AddLast(T pt)
    {
      if (Count == 0)
      {
        myFirstPoint = pt;
      }
      myWritePoint(mylastPoint = pt);
      myCount++;
    }

    public T First
    {
      get { return myFirstPoint; }
    }

    public T Last
    {
      get { return mylastPoint; }
    }

    public int Count
    {
      get { return myCount; }
    }

    public IEnumerable<T> Values
    {
      get { throw new NotImplementedException(); }
    }

    public IStackEnumerator<T> StackEnumerator()
    {
      throw new NotImplementedException();
    }

    public void AddAll(IPointList<T> points)
    {
      foreach (var pt in points.Values)
      {
        AddLast(pt);
      }
    }
  }


  public class FSCachedPointList<T> : IPointList<T>
  {
    private readonly IPersistance<T> myPersistance;
    private readonly IPersistanceFactory myReadWrite;



    public void AddLast(T pt)
    {
      throw new NotImplementedException();
    }

    public T First
    {
      get { throw new NotImplementedException(); }
    }

    public T Last
    {
      get { throw new NotImplementedException(); }
    }

    public int Count
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<T> Values
    {
      get { throw new NotImplementedException(); }
    }

    public IStackEnumerator<T> StackEnumerator()
    {
      throw new NotImplementedException();
    }

    public void AddAll(IPointList<T> points)
    {
      throw new NotImplementedException();
    }    
  }
}