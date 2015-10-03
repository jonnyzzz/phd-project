using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;
using DSIS.UI.Wizard.OptionsWizard;

namespace DSIS.UI.FunctionDialog
{
  [ContiniousSystemComponent]
  public class ContiniousSystemParametersWizard : OptionsBasedWizard<IContiniousSolverParameters, ISystemInfo, ContiniousFunctionSolverWrapper>
  {
    public ContiniousSystemParametersWizard(
      IListSelectorWizardPageFactory listFactory,
      IEnumerable<ContiniousFunctionSolverWrapper> factories)
      : base("Select continious integration method", listFactory, factories, x=>true)
    {
    }
  }
}