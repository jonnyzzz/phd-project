using DSIS.Scheme;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComputeInvariantMeasureUIComponent]
  public class ComputeInvariantMeasureWizard : StateWizard, IWizardPack<IAction>
  {
    private readonly ComputeInvariantMeasureWizardState myState;

    public ComputeInvariantMeasureWizard(ComputeInvariantMeasureWizardState state)
    {
      myState = state;
      Title = "Select Invariant Measure Approximation Method";
      FirstPage = state;
    }

    public void Dispose()
    {     
    }

    public IWizardPack Controller
    {
      get { return this; }
    }

    public IAction GetResult()
    {
      return myState.Factory.CreateComputeAction(myState.Settings);
    }
  }
}