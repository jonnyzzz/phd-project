using DSIS.Core.System;

namespace DSIS.Function.Solvers.SimpleSolver
{
  public class FunctionBase
  {
    protected readonly int myDimension;
    protected double[] myInput;
    protected double[] myOutput;
    protected readonly double myDt;

    public FunctionBase(int dimension, double dt)
    {
      myDimension = dimension;
      myDt = dt;
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public double[] Input
    {
      get { return myInput; }
      set { myInput = value; }
    }

    public double[] Output
    {
      get { return myOutput; }
      set { myOutput = value; }
    }

    public IFunctionIO<double>[] Derivates
    {
      get { return null; }
    }
  }
}