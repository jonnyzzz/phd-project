using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class Function<T> : FunctionIO<T>
  {
    private readonly int myDimension;

    public int Dimension
    {
      get { return myDimension; }
    }

    protected Function(int dimension, params IFunctionIO<T>[] derivates) : base(derivates)
    {
      myDimension = dimension;
    }

    protected Function(int dimension)
    {
      myDimension = dimension;
    }
  }
}