using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class ContiniousSystemParametersWizardFactory
  {
    [Autowire]
    private ISubContainerFactory Container { get; set; }

    [Autowire]
    private IEnumerable<IContiniousFunctionSolverFactory> Solvers { get; set; }

    public IWizardPack<ISystemInfo> CreateWizard(ISystemInfo continious)
    {
      //TODO: possible leak on dispose
      var c = Container.SubContainer<ContiniousSystemComponentAttribute>();

      var list = Solvers.Select(x => new ContiniousFunctionSolverWrapper(continious, x));
      var s = new ContiniousFunctionSolverWrappers(list.ToArray());
      c.RegisterComponent(s);
      c.Start();

      return c.GetComponent<ContiniousSystemParametersWizard>();
    }
  }
}