using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Function.Solvers.Merson
{
  [ComponentImplementation]
  public class MersonSolverFactory : ContiniousFunctionSolverBase
  {
    public MersonSolverFactory() : base("Merson solver")
    {
    }

    public override Type OptionsObjectType
    {
      get { return typeof (MersonOptions); }
    }

    public override ISystemInfo Create(ISystemInfo system, IContiniousSolverParameters parameters)
    {
      var opts = (MersonOptions) parameters;
      return new MersonSolver(system, opts.dTime);
    }
  }
}