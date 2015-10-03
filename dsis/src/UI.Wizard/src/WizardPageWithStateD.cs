using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public class WizardPageWithStateD : WizardPageWithState
  {
    private readonly Lazy<IWizardPageWithState> myNextPage;

    public WizardPageWithStateD(IWizardPage page, Lazy<IWizardPageWithState> nextPage) : base(page)
    {
      myNextPage = nextPage;
    }

    public override IWizardPageWithState NextPage
    {
      get { return myNextPage(); }
    }
  }
}