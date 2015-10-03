using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;
using System.Linq;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardPage : ListSelectorOptionsFactoryWizardPage<ICellImageBuilderFactory>
  {
    public SIConstructionMethodWizardPage(IListSelectorFactory factory, IEnumerable<ICellImageBuilderFactory> factories)
      : base(factory, factories.Sort((o1,o2) => o1.FactoryName.CompareTo(o2.FactoryName)))
    {
      Title = "Select Cell Image building method";
      SelectedItem = factories.Where(x=>x.IsDefault).Single();
    }
  }
}