/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;
using DSIS.Core.System.Tree;

namespace DSIS.Core.System
{
  public interface ISystemInfo
  {
    IFunction<T> GetFunction<T>();
    IFunction<T> GetDerivateFunction<T>(int derivatePower);
    IFunction<T> GetDerivateFunction<T>(int[] unsimmetricDerivate);
    
    Type[] SupportedFunctionTypes { get; }

    ISystemSpace SystemSpace { get; }
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