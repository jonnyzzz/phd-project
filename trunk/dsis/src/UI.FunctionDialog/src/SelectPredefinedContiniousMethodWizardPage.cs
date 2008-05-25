using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Service;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedContiniousMethodWizardPage : WizardPageBase<SelectPredefinedContiniousMethodPage>
  {
    public SelectPredefinedContiniousMethodWizardPage(IServiceProvider prov)
    {
      var services = prov.GetServices<IContiniousFunctionSolverFactory>();
      ControlInternal = new SelectPredefinedContiniousMethodPage(services);
    }
  }
}