using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs.Measure
{
  [ComponentImplementation]
  public class ComputeInvariantMeasureMethodSelectorImpl : IComputeInvariantMeasureMethodSelector
  {
    private readonly IComponentContainer myContainer;
    private readonly IApplicationClass myApp;

    public ComputeInvariantMeasureMethodSelectorImpl(IComponentContainer container, IApplicationClass app)
    {
      myContainer = container;
      myApp = app;
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