using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public abstract class WizardPageWithState : WizardPageWithState<IWizardPage>
  {
    protected WizardPageWithState(IWizardPage page) : base(page)
    {
    }
  }

  public abstract class WizardPageWithState<P> : IWizardPageWithState
    where P : IWizardPage
  {
    private readonly P myPage;

    protected WizardPageWithState(P page)
    {
      myPage = page;
    }

    protected P Page
    {
      get { return myPage; }
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

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}