using System.Windows.Forms;
using EugenePetrenko.Shared.Core.Ioc.Api;

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