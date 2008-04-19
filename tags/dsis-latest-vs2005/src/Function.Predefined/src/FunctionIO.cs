using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class FunctionIO<T> : IFunctionIO<T>
  {
    private readonly IFunctionIO<T>[] myDerivates = null;
    private T[] myInput = null;
    private T[] myOutput = null;

    public FunctionIO()
    {
    }

    public FunctionIO(params IFunctionIO<T>[] derivates)
    {
      myDerivates = derivates;
    }

    public IFunctionIO<T>[] Derivates
    {
      get { return myDerivates; }
    }

    public T[] Input
    {
      get { return myInput; }
      set { myInput = value; }
    }

    public T[] Output
    {
      get { return myOutput; }
      set { myOutput = value; }
    }
  }
}