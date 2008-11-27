using DSIS.Scheme;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComputeInvariantMeasureUIComponent]
  public class ComputeInvariantMeasureWizard : StateWizard
  {
    private readonly ComputeInvariantMeasureWizardState myState;

    public ComputeInvariantMeasureWizard(ComputeInvariantMeasureWizardState state)
    {
      myState = state;
      Title = "Select Symbolic Image construction method";
      FirstPage = state;
    }

    public IAction CreateAction()
    {
      return myState.Factory.CreateComputeAction(myState.Settings);
    }
  }
}