using System;
using System.Collections.Generic;

namespace DSIS.LineIterator
{
  public interface IPointList<T>
  {
    T First { get; }
    
    T Last { get; }
    
    int Count { get; }
    
    IEnumerable<T> Values { get; }
    
    /// <summary>
    /// May change the state of the object.
    /// </summary>
    /// <returns></returns>
    IStackEnumerator<T> StackEnumerator();

    IPointListWriter<T> PointWriter();

    void AddAll(IPointList<T> points);
  }

  public interface IPointListWriter<T> : IDisposable
  {
    void AddPoint(T pt);
  }

  public interface IStackEnumerator<T> : IDisposable
  {
    bool IsEmpty { get; }

    T Peek();

    void Pop();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    void Push(T value);
  }
}