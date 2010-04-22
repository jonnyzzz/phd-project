using System;
using DSIS.Core.System;

namespace DSIS.Function.Solvers.Merson
{
  public class MersonSolver : SolvedFunctionBase<MersonSolver.Context>
  {
    public MersonSolver(ISystemInfo function, int steps, double dt) : base(function, steps, dt)
    {
    }

    protected override string PresentableMethodName
    {
      get { return string.Format("Runge-Kutt(Step:{0},dt:{1})@{2}", mySteps, myDt, myFunction.PresentableName); }
    }

    public class Context
    {
      public double H;

      public void IncreasePrecision()
      {
        H /= 2;
      }
    }

    protected override Context CreateContext(double[] precision)
    {
      return new Context();
    }

    protected override IFunction<double> GetDoubleFunctionOne(Context ctx, double[] precision)
    {
      return new Function(this, ctx, precision);
    }

    private class Function : FunctionBase, IFunction<double>
    {
      private readonly Context myCtx;
      private readonly double[] myPrecision;
      private readonly IFunction<double>[] myF = new IFunction<double>[5];

      private readonly double[][] myFInput = new double[5][];
      private readonly double[][] myFOutput = new double[5][];
      private readonly double[][] myK = new double[5][];
      
      private double[] myOutput;

      public Function(MersonSolver solver, Context ctx, double[] precision) : base(solver.Dimension, solver.myFunction)
      {
        myCtx = ctx;
        myPrecision = precision;
        for (int i = 0; i < 5; i++)
        {
          myF[i] = Create(precision, out myFInput[i], out myFOutput[i]);
          myK[i] = new double[Dimension];
        }
        myOutput = new double[Dimension];
      }

      public double[] Input
      {
        get { return myF[0].Input; }
        set { myF[0].Input = value; }
      }

      public double[] Output
      {
        get { return myOutput; }
        set { myOutput = value; }
      }

      public void Evaluate()
      {
        double h = myCtx.H;
        double h3 = h/3;

        //k1:
        myF[0].Evaluate();
        for(int i = 0; i < Dimension; i++)
        {
          myK[0][i] = h3*myFOutput[0][i];
        }

        //k2:
        for(int i = 0; i < Dimension; i++)
        {
          myFInput[1][i] = myFInput[0][i] + myK[0][i];
        }
        myF[1].Evaluate();
        for(int i =0; i <Dimension; i++)
        {
          myK[1][i] = h3*myFOutput[1][i];
        }

        //k3:
        for(int i = 0; i < Dimension; i++)
        {
          myFInput[2][i] = myFInput[0][i] + (myK[0][i] + myK[1][i])/2;
        }
        myF[2].Evaluate();
        for(int i =0; i<Dimension;i++)
        {
          myK[2][i] = h*myFOutput[2][i];
        }

        //k4:
        for(int i = 0; i < Dimension; i++)
        {
          myFInput[3][i] = myFInput[0][i] + 0.375*(myK[0][i] + myK[2][i]);
        }
        myF[3].Evaluate();
        for(int i =0; i < Dimension; i++)
        {
          myK[3][i] = myK[0][i] + 4.0*h3*myFOutput[3][i];
        }

        //k5:
        for(int i =0; i < Dimension; i++)
        {
          myFInput[4][i] = myFInput[0][i] + 1.5*(myK[4][i] - myK[3][i]);
        }
        myF[4].Evaluate();
        for(int i =0; i < Dimension; i++)
        {
          myK[4][i] = h3*myFOutput[4][i];
        }


        //r:
        for(int i = 0; i < Dimension; i++)
        {
          double ri = (2*myK[3][i] - 3*myK[2][i] - myK[4][i])/10;
          if (ri > myPrecision[i])
          {
            myCtx.IncreasePrecision();
            Evaluate();
            return;
          }
        }

        for(int i =0; i < Dimension; i++)
        {
          myOutput[i] = myFInput[0][i] + (myK[3][i] + myK[4][i])/2;
        }
      }
    }
  }
}