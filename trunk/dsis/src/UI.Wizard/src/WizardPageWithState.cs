using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public abstract class WizardPageWithState : IWizardPageWithState
  {
    private readonly IWizardPage myPage;

    public WizardPageWithState(IWizardPage page)
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

    public abstract IWizardPageWithState NextPage { get; }
  }
}