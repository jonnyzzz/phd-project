using System.Collections.Generic;

namespace DSIS.UI.FunctionDialog
{
  public class ContiniousFunctionSolverWrappers
  {
    public IEnumerable<ContiniousFunctionSolverWrapper> Factories { get; private set; }

    public ContiniousFunctionSolverWrappers(IEnumerable<ContiniousFunctionSolverWrapper> factories)
    {
      Factories = factories;
    }
  }
}