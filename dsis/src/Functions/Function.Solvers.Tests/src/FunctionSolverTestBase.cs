using System;
using DSIS.Core.System;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace Function.Solvers.Tests
{
  public abstract class FunctionSolverTestBase
  {
    protected static double dT { get { return 0.001; } }
    protected static double Prec { get { return 0.001; } }

    protected abstract ISystemInfo Solve(ISystemInfo fun);

    [Test]
    public void Test_ConstantFunction()
    {
      DoTest(x=>1, x=>x);
    }

    [Test]
    public void Test_ZeroFunction()
    {
      DoTest(x=>0, x=>x + dT);
    }

    [Test]
    public void Test_LinearFunction()
    {
      DoTest(x => x, x => x * Math.Exp(dT));
    }

    [Test]
    public void Test_Circle()
    {
      //todo: check formula
      DoTest(-1, 1, x=>Math.Sqrt(1 - x*x), x0 => Math.Asin(dT) + x0);
    }

    [Test]
    public void Test_Cos2()
    {
      DoTest(-1, 1, x=>Math.Cos(x)*Math.Cos(x), x0 => Math.Atan(Math.Tan(x0) + dT));
    }
    
    private void DoTest(Func<double, double> dF, Func<double, double> F)
    {
      DoTest(-5, 5, dF, F);      
    }

    private void DoTest(double min, double max, Func<double, double> dF, Func<double, double> F)
    {
      var m = new MockSystemInfo<double>((i, o) =>
                                           {
                                             o[0] = dF(i[0]);
                                           },
                                         new MockSystemSpace(1, -1, 1, 100));

      var info = Solve(m);
      var fun = info.GetFunction(new[] { Prec });
      fun.Input = new double[1];
      fun.Output = new double[1];
      for(double i = min; i < max; i+= 0.34)
      {
        fun.Input[0] = i;
        fun.Evaluate();
        var ex = F(i);
        var ac = fun.Output[0];
        Assert.AreEqual(ex, ac, Prec * 10, "Solve({0}) = {1} <> F({0}) = {2}", i, ac, ex);
      }
    }
  }
}