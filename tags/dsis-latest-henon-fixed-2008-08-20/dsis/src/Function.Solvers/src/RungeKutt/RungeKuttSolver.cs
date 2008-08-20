using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

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
      get { return "Runge-Kutt"; }
    }

    protected override IFunction<double> GetDoubleFunctionOne(double[] precision)
    {
      return new Function(this, precision);
    }

    private class Function : IFunction<double>
    {
      private readonly int myDimension;
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

      private readonly RungeKuttSolver myFunctionInfo;
      private readonly double myDt;
      private readonly double myDt3;
      private double[] myOutput;
      

      public Function(RungeKuttSolver function, double[] precision)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.Dimension;

        myF1 = Create(precision, out myF1Input, out myF1Output);
        myF2 = Create(precision, out myF2Input, out myF2Output);
        myF3 = Create(precision, out myF3Input, out myF3Output);
        myF4 = Create(precision, out myF4Input, out myF4Output);

        myDt = myFunctionInfo.myDt/myFunctionInfo.mySteps;
        myDt3 = myDt/3.0;
      }

      public void Evaluate()
      {
        myF1.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF2Input[i] = myF1Input[i] + myDt*myF1Output[i];
        }
        myF2.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF3Input[i] = myF1Input[i] + myDt*myF2Output[i];
        }
        myF3.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF4Input[i] = myF1Input[i] + 2*myDt*myF3Output[i];
        }
        myF4.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myOutput[i] = myF1Input[i] +
                        myDt3 * (myF1Output[i] + 2*myF2Output[i] + 2*myF3Output[i] + myF4Output[i]);
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
        get { return myF1.Input; }
        set { myF1Input = myF1.Input = value; }
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }

      private IFunction<double> Create(double[] size, out double[] input, out double[] output)
      {
        IFunction<double> func = myFunctionInfo.myFunction.GetFunction<double>(size);
        input = func.Input = new double[myDimension];
        output = func.Output = new double[myDimension];
        return func;
      }
    }
  }
}