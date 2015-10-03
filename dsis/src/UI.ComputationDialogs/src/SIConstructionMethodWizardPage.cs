using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardPage : ListSelectorOptionsFactoryWizardPage<ICellImageBuilderFactory>
  {
    public SIConstructionMethodWizardPage(IListSelectorFactory factory, IEnumerable<ICellImageBuilderFactory> factories)
      : base(factory, factories)
    {
      Title = "Select Cell Image building method";
    }
  }
}