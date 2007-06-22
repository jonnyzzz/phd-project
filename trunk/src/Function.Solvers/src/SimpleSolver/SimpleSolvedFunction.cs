using DSIS.Core.System;

namespace DSIS.Function.Solvers.SimpleSolver
{
  public class SimpleSolvedFunction : SolvedFunctionBase
  {
    public SimpleSolvedFunction(IContiniousSystemInfo function, double dt) : base(function, dt)
    {
    }

    protected override IFunction<double> GetDoubleFunction()
    {
      return new Function(this);
    }

    protected override string PresentableMethodName
    {
      get { return "Simple"; }
    } 

    public class Function : IFunction<double>
    {
      private readonly SimpleSolvedFunction myFunctionInfo;
      private readonly int myDimension;
      private readonly IFunctionWithTime<double> myHostFunction;
      private readonly double myDt;

      public Function(SimpleSolvedFunction function)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.SystemSpace.Dimension;
        myDt = myFunctionInfo.myDt;
        myHostFunction = myFunctionInfo.myFunction.GetFunction<double>();
      }

      public void Evaluate()
      {
        myHostFunction.Evaluate(myDt);
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