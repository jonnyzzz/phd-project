using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public class EmptyWizardPage : WizardPageBase
  {
    public EmptyWizardPage()
    {
      Title = "Empty page";
      ControlInternal = new Label {Text = "Empty page content"};
    }
  }
}