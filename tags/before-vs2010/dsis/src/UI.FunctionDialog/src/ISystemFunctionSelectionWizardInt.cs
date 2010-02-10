using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.FunctionDialog
{
  public interface ISystemFunctionSelectionWizardInt
  {
    ISystemInfoFactory SystemFactory{ get; set; }
    IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    IContiniousSolverParameters ContiniousParameters { get; set; }
    ISystemInfoParameters SystemParameters { get; set; }
    SpaceModel Space { get; set; }

    IFormGeneratorWizardPageFactory FormGeneratorWizardPageFactory { get; }

    ISystemInfo CreateInfo();
    ISystemSpace CreateSpace();
  }
}