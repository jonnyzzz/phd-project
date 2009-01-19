using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  //TODO: DROP
  public abstract class Function<T> : FunctionIO<T>
  {
    protected Function(int dimension, params IFunctionIO<T>[] derivates) : base(dimension, derivates)
    {
    }

    protected Function(int dimension) : base(dimension)
    {
    }
  }
}