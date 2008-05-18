namespace DSIS.UI.Wizard
{
  public class EmptyWizard : IWizardPack
  {
    private readonly IWizardPage myPage = new EmptyWizardPage();

    public string Title
    {
      get { return "Empty Wizard"; }
    }

    public IWizardPage FirstPage
    {
      get { return myPage; }
    }

    public bool IsLastPage(IWizardPage page)
    {
      return true;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return null;
    }
  }
}