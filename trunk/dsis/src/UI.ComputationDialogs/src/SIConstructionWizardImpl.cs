using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.UI.Wizard;

namespace DSIS.UI.ComputationDialogs
{
  [ComponentImplementation]
  public class SIConstructionWizardImpl : ISIConstructionWizard
  {
    [Autowire]
    private ISubContainerFactory myContainer { get; set; }

    [Autowire]
    private IWizardFormPresenter Presenter { get; set; }

    public ICellImageBuilderSettings ShowWizard()
    {
      using (var c = myContainer.SubContainer<SIConstructionComponent>())
      {
        var wizard = c.GetComponent<SIConstructionWizard>();
        return Presenter.ShowWizardOrNull(wizard);
      }
    }
  }
}