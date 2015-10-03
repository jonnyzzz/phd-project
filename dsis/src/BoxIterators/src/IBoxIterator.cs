using System.Collections.Generic;

namespace DSIS.BoxIterators
{
  public interface IBoxIterator<T>
  {
    /// <summary>
    /// Every time outs array is returned. But values differs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="outs"></param>
    /// <returns></returns>
    IEnumerable<T[]> EnumerateBox(T[] left, T[] right, T[] outs);
  }

  public interface ICheckedBoxIterator<T>
  {
    /// <summary>
    /// Every time outs array is returned. But values differs
    /// left and right is checked if it may contain the same elements,
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="outs"></param>
    /// <returns></returns>
    IEnumerable<T[]> EnumerateBox(T[] left, T[] right, T[] outs);    
  }
}