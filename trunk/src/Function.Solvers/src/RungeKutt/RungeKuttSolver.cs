using System;
using DSIS.Core.System;
using DSIS.Function.Solvers.SimpleSolver;

namespace DSIS.Function.Solvers.src.RungeKutt
{
  public class RungeKuttSolver : SolvedFunctionBase
  {
    public RungeKuttSolver(IContiniousSystemInfo function, double dt)
      : base(function, dt)
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
      private readonly RungeKuttSolver myFunctionInfo;
      private readonly int myDimension;
      private readonly IFunctionWithTime<double> myK1;
      private readonly IFunctionWithTime<double> myK2;
      private readonly IFunctionWithTime<double> myK3;
      private readonly IFunctionWithTime<double> myK4;

      private readonly double myDt;

      public Function(RungeKuttSolver function)
      {
        myFunctionInfo = function;
        myDimension = myFunctionInfo.SystemSpace.Dimension;
        myDt = myFunctionInfo.myDt;

        myK1 = Create();
        myK2 = Create();
        myK3 = Create();
        myK4 = Create();        
      }

      private IFunctionWithTime<double> Create()
      {
        IFunctionWithTime<double> func = myFunctionInfo.myFunction.GetFunction<double>();
        func.Input = new double[myDimension];
        func.Output = new double[myDimension];
        return func;
      }

      public void Evaluate()
      {
        //todo: http://www.delphiplus.org/articles/algorithm/rk_method/
        throw new NotImplementedException("need to implement");
      }

      public int Dimension
      {
        get { return myDimension; }
      }

      public double[] Output
      {
        get { return myK1.Output; }
        set { myK1.Output = value; }
      }

      public double[] Input
      {
        get { return myK1.Input; }
        set { myK1.Input = value; }
      }

      public IFunctionIO<double>[] Derivates
      {
        get { return null; }
      }
    }
  }

}
