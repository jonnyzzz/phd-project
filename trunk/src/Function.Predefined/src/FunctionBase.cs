using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public abstract class FunctionBase<T> : FunctionIO<T>, IFunction<T>
  {
    private int myDimension;

    protected FunctionBase(int dimension, params IFunctionIO<T>[] derivates) : base(derivates)
    {
      myDimension = dimension;
    }

    protected FunctionBase(int dimension)
    {
      myDimension = dimension;
    }

    #region IFunction<T> Members

    public int Dimension
    {
      get { return myDimension; }
    }

    public abstract void Evaluate();

    #endregion
  }
}