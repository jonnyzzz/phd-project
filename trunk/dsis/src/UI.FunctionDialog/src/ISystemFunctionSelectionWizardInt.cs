using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.UI.FunctionDialog
{
  public interface ISystemFunctionSelectionWizardInt
  {
    ISystemInfoFactory SystemFactory{ get; set; }
    IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    IContiniousSolverParameters ContiniousParameters { get; set; }
    ISystemInfoParameters SystemParameters { get; set; }
    SpaceModel Space { get; set; }

    ISystemInfo CreateInfo();
    ISystemSpace CreateSpace();
  }
}