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

      public Function(SimpleSolvedFunction function, double[] precision)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.SystemSpace.Dimension;
        myHostFunction = myFunctionInfo.myFunction.GetFunction(precision);
      }

      public void Evaluate()
      {
        myHostFunction.Evaluate();
      }

      public int Dimension
      {
        get { return myDimension; }
      }

      public double[] Output
      {
        get { return myHostFunction.Output; }
        set { myHostFunction.Output = value; }
      }

      public double[] Input
      {
        get { return myHostFunction.Input; }
        set { myHostFunction.Input = value; }
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }
    }
  }
}