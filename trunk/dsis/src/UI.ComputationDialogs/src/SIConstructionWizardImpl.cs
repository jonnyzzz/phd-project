using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
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

    public ICellImageBuilderWizardResult ShowWizard(ICellCoordinateSystem system)
    {
      using (var c = myContainer.SubContainer<SIConstructionComponent>())
      {
        c.RegisterComponent(system);

        var wizard = c.GetComponent<SIConstructionWizardPack>();
        var settings = Presenter.ShowWizardOrNull(wizard);
        if (settings == null)
          return null;

        var wizard2 = c.GetComponent<SubdivisionWizardPack>();
        Presenter.ShowWizard(wizard2);

        return new Proxy(settings, system.Dimension);
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