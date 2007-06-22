using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleContiniousSystemInfoBase : SystemInfoDecoratorBase, IContiniousSystemInfo
  {
    public DoubleContiniousSystemInfoBase(ISystemSpace systemSpace)
      : base(systemSpace)
    {
    }

    public IFunctionWithTime<T> GetDerivateFunction<T>(int derivatePower)
    {
      if (typeof(T) != typeof(double) || derivatePower != 1)
        throw new NotImplementedException();

      return (IFunctionWithTime<T>)GetFunctionDerivateInternal();
    }

    public IFunctionWithTime<T> GetDerivateFunction<T>(int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public IFunctionWithTime<T> GetFunction<T>()
    {
      if (typeof(T) != typeof(double))
        throw new NotImplementedException();

      return (IFunctionWithTime<T>)GetFunctionInternal();
    }

    public Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor)
    {
      throw new NotImplementedException();
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new Type[] { typeof(double) }; }
    }

    public abstract string PresentableName { get; }
    protected abstract IFunctionWithTime<double> GetFunctionInternal();
    protected abstract IFunctionWithTime<double> GetFunctionDerivateInternal();
  }
}