using System.Collections.Generic;
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
    private IComponentContainer Container { get; set; }

    [Autowire]
    private IEnumerable<IContiniousFunctionSolverFactory> Solvers { get; set; }

    public IWizardPack<ISystemInfo> CreateWizard(ISystemInfo continious)
    {
      //TODO: possible leak on dispose
      var c = Container.SubContainer<ContiniousSystemComponentAttribute>();

      Solvers.Convert(x => new ContiniousFunctionSolverWrapper(continious, x)).Each(c.RegisterComponent);

      c.Start();

      return c.GetComponent<ContiniousSystemParametersWizard>();
    }
  }
}