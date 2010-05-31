using DSIS.Core.System;
using DSIS.Function.Solvers.Merson;
using NUnit.Framework;

namespace Function.Solvers.Tests
{
  [TestFixture]
  public class MersonSolverTest : FunctionSolverTestBase
  {
    protected override ISystemInfo Solve(ISystemInfo fun)
    {
      return new MersonSolver(fun, dT/10);
    }
  }
}