using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public class WizardPageProxy : IWizardPage
  {
    private readonly IWizardPage myPage;

    public WizardPageProxy(IWizardPage page)
    {
      myPage = page;
    }

    public string Title
    {
      get { return myPage.Title; }
    }

    public Control Control
    {
      get { return myPage.Control; }
    }

    public bool Validate()
    {
      return myPage.Validate();
    }

    public void ControlShown()
    {
      myPage.ControlShown();
    }

    public void ControlHidden()
    {
      myPage.ControlHidden();
    }
  }
}