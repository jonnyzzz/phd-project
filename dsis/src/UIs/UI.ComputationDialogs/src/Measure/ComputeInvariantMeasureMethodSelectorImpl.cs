using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.UI.Wizard;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [DocumentComponent]
  public class ComputeInvariantMeasureMethodSelectorImpl : IComputeInvariantMeasureMethodSelector
  {
    [Autowire]
    private ISubContainerFactory myContainer{ get; set;}

    [Autowire]
    private IComputeInveriantMeasureFactory[] Factories { get; set; }

    [Autowire]
    private IWizardFormPresenter Presented { get; set; }

    public bool IsApplicable(Context ctx)
    {
      foreach (var factory in Factories)
      {
        if (factory.Compatible(ctx))
          return true;
      }
      return false;
    }

    public IAction ShowWizard()
    {       
      using (var c = myContainer.SubContainer<ComputeInvariantMeasureUIComponent>())
      {
        var wizard = c.Start().GetComponent<ComputeInvariantMeasureWizard>();
        return Presented.ShowWizardOrNull(wizard);        
      }
    }
  }
}