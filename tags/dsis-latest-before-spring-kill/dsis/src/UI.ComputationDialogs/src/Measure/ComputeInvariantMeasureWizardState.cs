using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComputeInvariantMeasureUIComponent]
  public class ComputeInvariantMeasureWizardState : SelectFactoryAndOptionsWizardState<ComputeInvariantMeasureWizardPage, IComputeInveriantMeasureFactory, object>
  {
    public ComputeInvariantMeasureWizardState(ComputeInvariantMeasureWizardPage page, IFormGeneratorWizardPageFactory factory) : base(page, factory)
    {
    }
  }
}