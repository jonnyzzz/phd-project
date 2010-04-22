using DSIS.Core.System;
using NUnit.Framework;

namespace Function.Solvers.Tests
{
  [TestFixture]
  public class RungeKuttSolverTest : FunctionSolverTestBase
  {
    protected override ISystemInfo Solve(ISystemInfo fun)
    {
      return new DSIS.Function.Solvers.RungeKutt.RungeKuttSolver(fun, 10, dT/10);
    }
  }
}