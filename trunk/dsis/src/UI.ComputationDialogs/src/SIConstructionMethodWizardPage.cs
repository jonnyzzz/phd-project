using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardPage : ListSelectorWizardPage<ICellImageBuilderFactory>
  {
    public SIConstructionMethodWizardPage(IListSelectorFactory factory, IEnumerable<ICellImageBuilderFactory> factories)
      : base(factory, factories, x=>x.FactoryName)
    {
      Title = "Select Cell Image building method";
    }
  }
}