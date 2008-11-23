using DSIS.Core.Builders;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardState : 
    SelectFactoryAndOptionsWizardState<
    SIConstructionMethodWizardPage,
    ICellImageBuilderFactory, 
    ICellImageBuilderSettings>
  {
    public SIConstructionMethodWizardState(SIConstructionMethodWizardPage page, IFormGeneratorWizardPageFactory factory)
      : base(page, factory)
    {
    }
  }
}