using System;
using DSIS.Spring.Attributes;

namespace DSIS.Function.Solvers.RungeKutt
{
  [SpringBean]
  public class RungeKuttSolverFactory : ContiniousFunctionSolverBase
  {
    public RungeKuttSolverFactory() : base("Runge-Kutt solver")
    {
    }

    public override Type OptionsObjectType
    {
      get { return typeof (RungeKuttOptions); }
    }
  }
}