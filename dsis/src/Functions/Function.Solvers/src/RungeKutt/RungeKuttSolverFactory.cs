using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Function.Solvers.RungeKutt
{
  [ComponentImplementation]
  public class RungeKuttSolverFactory : ContiniousFunctionSolverBase
  {
    public RungeKuttSolverFactory() : base("Runge-Kutt solver")
    {
    }

    public override Type OptionsObjectType
    {
      get { return typeof (RungeKuttOptions); }
    }

    public override ISystemInfo Create(ISystemInfo system, IContiniousSolverParameters parameters)
    {
      var opts = (RungeKuttOptions) parameters;
      return new RungeKuttSolver(system, opts.Steps, opts.dTime);
    }
  }
}