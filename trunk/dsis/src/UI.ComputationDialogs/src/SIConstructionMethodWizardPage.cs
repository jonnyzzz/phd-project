using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardPage :
    WizardPageBase<ListSelector<ListInfo<ICellImageBuilderFactory>, ICellImageBuilderFactory>>
  {
    public SIConstructionMethodWizardPage(ICellImageBuilderFactory[] factories)
    {
      ControlInternal = ListSelector.Create(
        factories.Map(
          x => ListInfo.Create(
                 x.FactoryName,
                 "",
                 true,
                 x)));
      Title = "Select Cell Image building method";
    }

    public ICellImageBuilderFactory SelectedItem
    {
      get { return ControlInternal.SelectedValue; }
    }

    public override bool Validate()
    {
      return SelectedItem != null;
    }
  }
}