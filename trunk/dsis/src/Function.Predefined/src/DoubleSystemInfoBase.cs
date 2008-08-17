using System;
using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleSystemInfoBase : SystemInfoDecoratorBase, ISystemInfo
  {
    private readonly int myDimension;

    protected DoubleSystemInfoBase(int dimension)
    {
      myDimension = dimension;
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

    public IFunction<T> GetFunction<T>(T precision)
    {
      var ts = new T[myDimension];
      for(int i=0; i< myDimension; i++)
      {
        ts[i] = precision;
      }
      return GetFunction<T>(ts);
    }

    public Type[] SupportedFunctionTypes
    {
      get { return new[] {typeof (double)}; }
    }    

    public abstract string PresentableName { get; }

    public int Dimension
    {
      get { return myDimension; }
    }

    protected abstract IFunction<double> GetFunctionInternal();

    protected virtual IFunction<double> GetFunctionDerivateInternal()
    {
      throw new NotImplementedException();
    }
  }
}