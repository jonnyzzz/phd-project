using System;

namespace DSIS.UI.Wizard
{
  public class WizardPageWithStateD : WizardPageWithState
  {
    private readonly Func<IWizardPageWithState> myNextPage;

    public WizardPageWithStateD(IWizardPage page, Func<IWizardPageWithState> nextPage) : base(page)
    {
      myNextPage = nextPage;
    }

    public override IWizardPageWithState NextPage
    {
      get { return myNextPage(); }
    }
  }
}