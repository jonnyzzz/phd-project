using DSIS.Core.Builders;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.UI.Wizard;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  [ComponentImplementation]
  public class SIConstructionWizardImpl : ISIConstructionWizard
  {
    [Autowire]
    private ISubContainerFactory myContainer { get; set; }

    [Autowire]
    private IWizardFormPresenter Presenter { get; set; }

    public ICellImageBuilderWizardResult ShowWizard(int dimension)
    {
      using (var c = myContainer.SubContainer<SIConstructionComponent>())
      {
        var wizard = c.GetComponent<SIConstructionWizard>();
        var settings = Presenter.ShowWizardOrNull(wizard);
        return settings == null ? null : new Proxy(settings, dimension);
      }
    }

    private class Proxy : ICellImageBuilderWizardResult
    {
      private readonly ICellImageBuilderSettings mySettings;
      private readonly int myDimension;

      public Proxy(ICellImageBuilderSettings settings, int dimension)
      {
        mySettings = settings;
        myDimension = dimension;
      }

      public ICellImageBuilderSettings Setting
      {
        get { return mySettings; }
      }

      public long[] Subdivision
      {
        get { return 2L.Fill(myDimension); }
      }

      public ICellImageBuilderWizardResult Next(Context ctx)
      {
        return null;
      }
    }
  }
}