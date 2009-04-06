using System;
using System.Collections.Generic;

namespace DSIS.LineIterator
{
  public interface IPointList<T>
  {
    void AddLast(T pt);
    
    T First { get; }
    
    T Last { get; }
    
    int Count { get; }
    
    IEnumerable<T> Values { get; }
    
    /// <summary>
    /// May change the state of the object.
    /// </summary>
    /// <returns></returns>
    IStackEnumerator<T> StackEnumerator();

    void AddAll(IPointList<T> points);
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