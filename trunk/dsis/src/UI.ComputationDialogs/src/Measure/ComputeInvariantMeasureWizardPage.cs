using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.Scheme;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.UI.Wizard;
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

  [SIConstructionComponent]
  public class ComputeInvariantMeasureWizard : StateWizard
  {
    private readonly ComputeInvariantMeasureWizardState myState;

    public ComputeInvariantMeasureWizard(ComputeInvariantMeasureWizardState state)
    {
      myState = state;
      Title = "Select Symbolic Image construction method";
      FirstPage = state;
    }

    public IAction CreateAction()
    {
      return myState.Factory.CreateComputeAction(myState.Settings);
    }
  }


  [ComponentImplementation]
  public class ComputeInvariantMeasureWizardImpl : ISIConstructionWizard
  {
    private readonly IComponentContainer myContainer;
    private readonly IApplicationClass myApp;

    public ComputeInvariantMeasureWizardImpl(IComponentContainer container, IApplicationClass app)
    {
      myContainer = container;
      myApp = app;
    }

    public ICellImageBuilderSettings ShowWizard()
    {
      return myApp.ShowDialog(
        f =>
        {
          using (var c = myContainer.SubContainer<ComputeInvariantMeasureUIComponent>())
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