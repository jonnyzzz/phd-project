using DSIS.Core.System;

namespace DSIS.Function.Predefined
{
  public class FunctionIO<T> : IFunctionIO<T>
  {
    private readonly int myDimention;
    private readonly IFunctionIO<T>[] myDerivates = null;
    private T[] myInput = null;
    private T[] myOutput = null;

    public FunctionIO(int dimention)
    {
      myDimention = dimention;
    }

    public FunctionIO(int dimention, params IFunctionIO<T>[] derivates) : this(dimention)
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

    public int Dimension { get { return myDimention; } }
  }
}