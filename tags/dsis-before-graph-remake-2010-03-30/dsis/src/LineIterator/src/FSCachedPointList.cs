using System;
using System.Collections.Generic;
using DSIS.Persistance;

namespace DSIS.LineIterator
{
  public class FSCachedPointList<T> : IPointList<T>
  {
    private readonly IPersistance<T> myPersistance;
    private readonly IPersistanceFactory myReadWrite;

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

    public IPointListWriter<T> PointWriter()
    {
      throw new NotImplementedException();
    }

    public void AddAll(IPointList<T> points)
    {
      throw new NotImplementedException();
    }    
  }
}