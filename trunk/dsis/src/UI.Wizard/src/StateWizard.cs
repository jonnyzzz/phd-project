namespace DSIS.UI.Wizard
{
  public class StateWizard : IWizardPack
  {
    private readonly IWizardPageWithState myRootPage;

    protected StateWizard(IWizardPageWithState rootPage)
    {
      myRootPage = rootPage;
    }

    public string Title { get; protected set; }

    public IWizardPage FirstPage
    {
      get { return myRootPage; }
    }

    public bool IsLastPage(IWizardPage page)
    {
      return Next(page) == null;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return ((IWizardPageWithState) page).NextPage;
    }
  }
}