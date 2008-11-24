using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComputeInvariantMeasureUIComponent]
  public class ComputeInvariantMeasureWizardPage : ListSelectorOptionsFactoryWizardPage<IComputeInveriantMeasureFactory>
  {
    public ComputeInvariantMeasureWizardPage(IListSelectorFactory factory, IEnumerable<IComputeInveriantMeasureFactory> factories) : base(factory, factories)
    {
    }
  }
}