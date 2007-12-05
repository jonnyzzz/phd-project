using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleSystemInfoBase : SystemInfoDecoratorBase, ISystemInfo
  {
    public DoubleSystemInfoBase(ISystemSpace systemSpace) : base(systemSpace)
    {
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower)
    {
      if (typeof (T) != typeof (double) || derivatePower != 1)
        throw new NotImplementedException();

      return (IFunction<T>) GetFunctionDerivateInternal();
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate)
    {
      throw new NotImplementedException();
    }

    public IFunction<T> GetFunction<T>(T[] precision)
    {
      if (typeof (T) != typeof (double))
        throw new NotImplementedException();

      return (IFunction<T>) GetFunctionInternal();
    }
    
    public Type[] SupportedFunctionTypes
    {
      get { return new Type[] {typeof (double)}; }
    }    

    public abstract string PresentableName { get; }
    protected abstract IFunction<double> GetFunctionInternal();
    protected abstract IFunction<double> GetFunctionDerivateInternal();
  }
}