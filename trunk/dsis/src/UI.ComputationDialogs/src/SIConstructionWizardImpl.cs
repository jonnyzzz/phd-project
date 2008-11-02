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
    private readonly IComponentContainer myContainer;
    private readonly IApplicationClass myApp;

    public SIConstructionWizardImpl(IComponentContainer container, IApplicationClass app)
    {
      myContainer = container;
      myApp = app;
    }

    public ICellImageBuilderSettings ShowWizard()
    {
      return myApp.ShowDialog(
        f =>
          {
            using ( var c = myContainer.SubContainer <ComponentInterfaceAttribute, ComponentCollectionAttribute,
              SIConstructionComponent>())
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