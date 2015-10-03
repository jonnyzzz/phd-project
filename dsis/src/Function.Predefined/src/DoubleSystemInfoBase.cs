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

    public IFunction<T> GetFunction<T>(T[] precision)
    {
      if (typeof (T) != typeof (double))
        throw new NotImplementedException();

      return (IFunction<T>) GetFunctionInternal();
    }

    public abstract SystemType Type { get; }

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
  }
}