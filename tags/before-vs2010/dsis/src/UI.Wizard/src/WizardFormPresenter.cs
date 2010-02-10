using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard
{
  [ComponentImplementation]
  public class WizardFormPresenter : AbstractWizardFormPresenter
  {
    protected override Form CreateWizardForm<T>(IWizardPack<T> wizard)
    {
      return new WizardForm(wizard.Controller);
    }
  }
}