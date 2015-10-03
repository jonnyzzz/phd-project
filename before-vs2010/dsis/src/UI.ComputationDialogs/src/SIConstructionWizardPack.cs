using DSIS.Core.Builders;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionWizardPack : StateWizard, IWizardPack<ICellImageBuilderSettings>
  {
    private readonly SIConstructionMethodWizardState myState;

    public SIConstructionWizardPack(SIConstructionMethodWizardState state)
    {
      myState = state;
      Title = "Select Symbolic Image construction method";
      FirstPage = state;
    }

    public void Dispose()
    {      
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public ICellImageBuilderSettings GetResult()
    {
      return myState.Settings;
    }
  }
}