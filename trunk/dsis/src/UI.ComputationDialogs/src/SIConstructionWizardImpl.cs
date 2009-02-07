using System.Windows.Forms;
using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [ComponentImplementation]
  public class SIConstructionWizardImpl : ISIConstructionWizard
  {
    private readonly ISubContainerFactory myContainer;
    private readonly IApplicationClass myApp;

    public SIConstructionWizardImpl(ISubContainerFactory container, IApplicationClass app)
    {
      myContainer = container;
      myApp = app;
    }

    public ICellImageBuilderSettings ShowWizard()
    {
      return myApp.ShowDialog(
        f =>
          {
            using ( var c = myContainer.SubContainer<SIConstructionComponent>())
            {
              var wizard = c.GetComponent<SIConstructionWizard>();
              using (var dlg = new WizardForm(wizard))
              {
                return dlg.ShowDialog(f) == DialogResult.OK ? wizard.Settings : null;
              }
            }
          });
    }
  }
}