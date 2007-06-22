/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;
using DSIS.Core.System.Tree;

namespace DSIS.Core.System
{
  public interface ISystemInfoBase
  {
    Type[] SupportedFunctionTypes { get; }
    ISystemSpace SystemSpace { get; }
    string PresentableName { get; }
  }

  /// <summary>
  /// Represents descrete system's function of right hand
  /// </summary>
  public interface IDiscreteSystemInfo : ISystemInfoBase
  {
    IFunction<T> GetFunction<T>();
    IFunction<T> GetDerivateFunction<T>(int derivatePower);
    IFunction<T> GetDerivateFunction<T>(int[] unsimmetricDerivate);
  }

  /// <summary>
  /// Represents continious system's 
  /// and right hand function of the
  /// dx/dt = F(x,t)
  /// where x is sent throung IFunctionIO&lt;T&gt;,
  /// but t is put to the IFunctionWithTime&lt;T&gt;.Evaluate
  /// method.
  /// </summary>
  public interface IContiniousSystemInfo : ISystemInfoBase
  {
    IFunctionWithTime<T> GetFunction<T>();
    IFunctionWithTime<T> GetDerivateFunction<T>(int derivatePower);
    IFunctionWithTime<T> GetDerivateFunction<T>(int[] unsimmetricDerivate);    
  }

  /// <summary>
  /// Extension to get access to FunctionTree. 
  /// </summary>
  [Obsolete("Please contact developers before use")]
  public interface ISystemInfoCodeTree
  {
    Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor);
  }
}