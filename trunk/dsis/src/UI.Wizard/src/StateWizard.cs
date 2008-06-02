namespace DSIS.UI.Wizard
{
  public abstract class StateWizard : IWizardPack
  {
    public string Title { get; protected set; }

    public IWizardPage FirstPage { get; protected set; }

    public bool IsLastPage(IWizardPage page)
    {
      return ((IWizardPageWithState)page).IsLastPage;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return ((IWizardPageWithState) page).NextPage;
    }
  }
}