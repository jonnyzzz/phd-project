using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  public class SIConstructionMethodSettingsWizardState : WizardPageWithState
  {
    public SIConstructionMethodSettingsWizardState(IWizardPage page) : base(page)
    {
    }

    public override IWizardPageWithState NextPage
    {
      get { return null; }
    }

    public override bool IsLastPage
    {
      get { return true; }
    }
  }
}