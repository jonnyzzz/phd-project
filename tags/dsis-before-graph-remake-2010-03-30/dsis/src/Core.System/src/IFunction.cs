/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

namespace DSIS.Core.System
{
  public interface IFunctionBase
  {
    /// <summary>
    /// Retrive the dimension of the IFunction object
    /// </summary>
    int Dimension { get; }
  }

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
  }

  /// <summary>
  /// Represents a right hand of differential equation i.e.
  /// dx/dt = F(x,t), where x is vector of IFunctionBase<T>.Dimension size
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IFunctionWithTime<T> : IFunctionIO<T>
  {
    /// <summary>
    /// Evaluates function on <b>Input"</b> and stores 
    /// result to <b>"Output"</b>.
    /// Both <b>Input"<b/> and <b>"Output"</b> is not
    /// changed.
    /// </summary>
    void Evaluate(T time);
  }

  public interface IDetDiffFunction<T> : IFunctionBase
  {
    T Evaluate(T[] data);
  }
}