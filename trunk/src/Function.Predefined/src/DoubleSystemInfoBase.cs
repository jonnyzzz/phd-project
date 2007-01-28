using System;
using DSIS.Core.System;
using DSIS.Core.System.Tree;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleSystemInfoBase : SystemInfoDecoratorBase, ISystemInfo
  {
    public DoubleSystemInfoBase(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    protected abstract IFunction<double> GetFunctionInternal();
    protected abstract IFunction<double> GetFunctionDerivateInternal();

    public IFunction<T> GetFunction<T>()
    {
      if (typeof(T) != typeof(double))
        throw new NotImplementedException();

      return (IFunction<T>) GetFunctionInternal();
    }

    public IFunction<T> GetDerivateFunction<T>(int derivatePower)
    {
      if (typeof(T) != typeof(double) || derivatePower != 1)
        throw new NotImplementedException();

      return (IFunction<T>)GetFunctionDerivateInternal();
    }

    public IFunction<T> GetDerivateFunction<T>(int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public Q ProcessFunctionTree<Q>(IFunctionTreeVisitor<Q> visitor)
    {
      throw new NotImplementedException();
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new Type[]{typeof(double)}; }
    }
  }
}