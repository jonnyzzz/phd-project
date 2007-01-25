/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.System
{
  /// <summary>
  /// /// Both <see cref="Input"/> and <see cref="Output"/> is not
  /// changed by the object implicitly
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IFunctionIO<T>
  {
    /// <summary>
    /// Input parameters reference
    /// Value is not changed by the object.
    /// </summary>
    T[] Input { get; set; }

    /// <summary>
    /// Output parameters reference.
    /// Value is not changed by the object.
    /// </summary>
    T[] Output { get; set; }

    /// <summary>
    /// Return Array of IFunctionIO&lt;T&gt; for derivates IO
    /// or null if derivates does not supported. 
    /// </summary>
    IFunctionIO<T>[] Derivates { get; } 
  }
}