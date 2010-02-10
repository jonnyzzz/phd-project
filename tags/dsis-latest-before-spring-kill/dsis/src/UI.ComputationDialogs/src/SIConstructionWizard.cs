using DSIS.Core.Builders;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionWizard : StateWizard
  {
    private readonly SIConstructionMethodWizardState myState;

    public SIConstructionWizard(SIConstructionMethodWizardState state)
    {
      myState = state;
      Title = "Select Symbolic Image construction method";
      FirstPage = state;
    }

    public ICellImageBuilderSettings Settings
    {
      get { return myState.Settings; }
    }
  }
}