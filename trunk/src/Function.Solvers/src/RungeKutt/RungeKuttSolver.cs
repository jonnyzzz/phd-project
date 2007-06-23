using DSIS.Core.System;
using DSIS.Function.Solvers.SimpleSolver;

namespace DSIS.Function.Solvers.RungeKutt
{
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

    #region Nested type: Function

    public class Function : IFunction<double>
    {
      private readonly int myDimension;
      private readonly IFunction<double> myF1;
      private readonly IFunction<double> myF2;
      private readonly IFunction<double> myF3;
      private readonly IFunction<double> myF4;
      private readonly RungeKuttSolver myFunctionInfo;
      private readonly double[] myH;
      private double[] myOutput;

      public Function(RungeKuttSolver function, double[] precision)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.SystemSpace.Dimension;

        myF1 = Create(precision);
        myF2 = Create(precision);
        myF3 = Create(precision);
        myF4 = Create(precision);

        myH = new double[myDimension];
        for (int i = 0; i < myDimension; i++)
        {
          myH[i] = myFunctionInfo.myDt/myFunctionInfo.mySteps;
        }
      }

      #region IFunction<double> Members

      public void Evaluate()
      {
        myF1.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF2.Input[i] = myF1.Input[i] + myH[i]*myF1.Output[i];
        }
        myF2.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF3.Input[i] = myF1.Input[i] + myH[i]*myF2.Output[i];
        }
        myF3.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myF4.Input[i] = myF1.Input[i] + 2*myH[i]*myF3.Output[i];
        }
        myF4.Evaluate();
        for (int i = 0; i < myDimension; i++)
        {
          myOutput[i] = myF1.Input[i] +
                        myH[i]/3.0*(myF1.Output[i] + 2*myF2.Output[i] + 2*myF3.Output[i] + myF4.Output[i]);
        }
        //NOTE: http://www.delphiplus.org/articles/algorithm/rk_method/
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
        set { myF1.Input = value; }
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }

      #endregion

      private IFunction<double> Create(double[] size)
      {
        IFunction<double> func = myFunctionInfo.myFunction.GetFunction(size);
        func.Input = new double[myDimension];
        func.Output = new double[myDimension];
        return func;
      }
    }

    #endregion
  }
}