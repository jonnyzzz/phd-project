using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [DocumentComponent]
  public class ComputeInvariantMeasureMethodSelectorImpl : IComputeInvariantMeasureMethodSelector
  {
    private readonly ISubContainerFactory myContainer;
    private readonly IApplicationClass myApp;

    [Autowire]
    private IComputeInveriantMeasureFactory[] Factories { get; set; }

    public ComputeInvariantMeasureMethodSelectorImpl(ISubContainerFactory container, IApplicationClass app)
    {
      myContainer = container;
      myApp = app;
    }

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
      return myApp.ShowDialog(
        f =>
          {
            using (var c = myContainer.SubContainer<ComputeInvariantMeasureUIComponent>())
            {
              var wizard = c.GetComponent<ComputeInvariantMeasureWizard>();
              using (var dlg = new WizardForm(wizard))
              {
                return dlg.ShowDialog(f) == DialogResult.OK ? wizard.CreateAction() : null;
              }
            }
          });
    }
  }
}