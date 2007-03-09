/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.System
{
  /// <summary>
  /// This interface introduces the <i>System Function Notion</i>
  /// Any method SHOULD take this interface as the abstraction to
  /// the system function.  
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IFunction<T> : IFunctionIO<T>
  {
    /// <summary>
    /// Evaluates function on <b>Input"</b> and stores 
    /// result to <b>"Output"</b>.
    /// Both <b>Input"<b/> and <b>"Output"</b> is not
    /// changed.
    /// </summary>
    void Evaluate();

    /// <summary>
    /// Retrive the dimension of the IFunction object
    /// </summary>
    int Dimension { get; }
  }
}