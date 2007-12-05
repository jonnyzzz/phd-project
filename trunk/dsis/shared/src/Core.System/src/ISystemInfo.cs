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
    
    [Obsolete("Only Dimension is allowed")]
    ISystemSpace SystemSpace { get; }
    string PresentableName { get; }
  }

  /// <summary>
  /// Represents descrete system's function of right hand
  /// </summary>
  public interface ISystemInfo : ISystemInfoBase
  {
    IFunction<T> GetFunction<T>(T[] precision);
    IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower);
    IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate);
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