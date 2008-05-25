using DSIS.Spring.Service;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SystemFunctionSelectionWizard : StateWizard
  {
    public SystemFunctionSelectionWizard(IServiceProvider prov) : base(new SelectSystemWizardPage(prov))
    {
    }
  }
}