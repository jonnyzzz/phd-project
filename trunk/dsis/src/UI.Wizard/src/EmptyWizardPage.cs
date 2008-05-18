using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public class EmptyWizardPage : WizardPageBase
  {
    public EmptyWizardPage()
    {
      Title = "Empty page";
      Control = new Label {Text = "Empty page content"};
    }
  }
}