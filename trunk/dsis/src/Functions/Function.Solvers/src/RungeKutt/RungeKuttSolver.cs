using DSIS.Core.System;

namespace DSIS.Function.Solvers.RungeKutt
{
  /// <summary>
  /// http://www.delphiplus.org/articles/algorithm/rk_method/
  /// </summary>
  public class RungeKuttSolver : SolvedFunctionBase
  {
    public RungeKuttSolver(ISystemInfo function, int steps, double dt)
      : base(function, steps, dt)
    {
    }

    protected override string PresentableMethodName
    {
      get { return string.Format("Runge-Kutt(Step:{0},dt:{1})@{2}", mySteps, myDt, myFunction.PresentableName); }
    }

    protected override IFunction<double> GetDoubleFunctionOne(double[] precision)
    {
      return new Function(this, precision);
    }

    private class Function : FunctionBase, IFunction<double>
    {      
      private readonly IFunction<double> myF1;
      private readonly IFunction<double> myF2;
      private readonly IFunction<double> myF3;
      private readonly IFunction<double> myF4;
      private double[] myF1Input;
      private readonly double[] myF2Input;
      private readonly double[] myF3Input;
      private readonly double[] myF4Input;
      private readonly double[] myF1Output;
      private readonly double[] myF2Output;
      private readonly double[] myF3Output;
      private readonly double[] myF4Output;

      private readonly double myDt;
      private readonly double myDt2;
      private readonly double myDt6;
      private double[] myOutput;
      

      public Function(RungeKuttSolver function, double[] precision) : base(function.Dimension, function.myFunction)
      {
        myF1 = Create(precision, out myF1Input, out myF1Output);
        myF2 = Create(precision, out myF2Input, out myF2Output);
        myF3 = Create(precision, out myF3Input, out myF3Output);
        myF4 = Create(precision, out myF4Input, out myF4Output);

        myDt = function.myDt;
        myDt2 = myDt/2.0;
        myDt6 = myDt/6.0;
      }

      public void Evaluate()
      {
        myF1.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF2Input[i] = myF1Input[i] + myDt2*myF1Output[i];
        }
        myF2.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF3Input[i] = myF1Input[i] + myDt2*myF2Output[i];
        }
        myF3.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF4Input[i] = myF1Input[i] + myDt*myF3Output[i];
        }
        myF4.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myOutput[i] = myF1Input[i] +
                        myDt6 * (myF1Output[i] + 2*myF2Output[i] + 2*myF3Output[i] + myF4Output[i]);
        }        
      }

      public double[] Output
      {
        get { return myOutput; }
        set { myOutput = value; }
      }

      public double[] Input
      {
        get { return myF1.Input; }
        set { myF1Input = myF1.Input = value; }
      }
    }
  }
}