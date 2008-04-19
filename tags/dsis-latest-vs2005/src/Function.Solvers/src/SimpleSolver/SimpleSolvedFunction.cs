using DSIS.Core.System;

namespace DSIS.Function.Solvers.SimpleSolver
{
  public class SimpleSolvedFunction : SolvedFunctionBase
  {
    public SimpleSolvedFunction(ISystemInfo function, int steps, double dt) : base(function, steps, dt)
    {
    }

    protected override IFunction<double> GetDoubleFunctionOne(double[] precision)
    {
      return new Function(this, precision);
    }

    protected override string PresentableMethodName
    {
      get { return "Simple"; }
    } 

    public class Function : IFunction<double>
    {
      private readonly SimpleSolvedFunction myFunctionInfo;
      private readonly int myDimension;
      private readonly IFunction<double> myHostFunction;
      private double[] myOutput;
      private double[] myInput;
      private readonly double[] myFOutput;
      private readonly double myDt;



      public Function(SimpleSolvedFunction function, double[] precision)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.Dimension;
        myHostFunction = myFunctionInfo.myFunction.GetFunction<double>(precision);
        myInput = myHostFunction.Input;
        myFOutput = new double[myDimension];
        myHostFunction.Output = myFOutput;
        myDt = function.myDt;
      }

      public void Evaluate()
      {
        myHostFunction.Evaluate();
        for(int i= 0; i<Dimension; i++)
        {
          myOutput[i] = myInput[i] + myDt*myFOutput[i];
        }
      }

      public int Dimension
      {
        get { return myDimension; }
      }

      public double[] Output
      {
        get { return myOutput; }
        set { myOutput = value; }
      }

      public double[] Input
      {
        get { return myHostFunction.Input; }
        set { myInput = myHostFunction.Input = value; }
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }
    }
  }
}