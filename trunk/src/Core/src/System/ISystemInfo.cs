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

    Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor);

    Type[] SupportedFunctionTypes { get;}

    ISystemSpace SystemSpace { get;}
  }
}