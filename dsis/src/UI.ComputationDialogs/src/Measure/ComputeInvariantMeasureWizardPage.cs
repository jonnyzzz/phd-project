using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.UI.Wizard.ListSelector;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComputeInvariantMeasureUIComponent]
  public class ComputeInvariantMeasureWizardPage : ListSelectorOptionsFactoryWizardPage<IComputeInveriantMeasureFactory>
  {
    public ComputeInvariantMeasureWizardPage(IApplicationDocument doc, IListSelectorFactory factory, IEnumerable<IComputeInveriantMeasureFactory> factories) : this(doc.Content, factory, factories)
    {
      
    }

    private ComputeInvariantMeasureWizardPage(Context ctx, IListSelectorFactory factory, IEnumerable<IComputeInveriantMeasureFactory> factories) : base(factory, factories, x=>x.Compatible(ctx))
    {
    }
  }
}