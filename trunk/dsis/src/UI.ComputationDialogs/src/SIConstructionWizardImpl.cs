using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Ioc;
using DSIS.UI.ComputationDialogs.Builders;
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

    public ICellImageBuilderWizardResult ShowWizard(ICellCoordinateSystem system)
    {
      using (var c = myContainer.SubContainer<SIConstructionComponent>())
      {
        c.RegisterComponent(system);

        var settings = Presenter.ShowWizardOrNull(c.GetComponent<SIConstructionWizardPack>());
        if (settings == null)
          return null;

        var result2 = Presenter.ShowWizardOrNull(c.GetComponent<SubdivisionWizardPack>());
        if (result2 == null)
          return null;

        if (result2.Constraints.Count == 0)
          throw new ArgumentException("There should be at least one constraint");

        var sym = new SymmetricBuilder(settings, result2.Subdivision, result2.Constraints);
        return result2.UseUnsimmetric ? (ICellImageBuilderWizardResult) new UnSymmetricBuilder(sym) : sym;
      }
    }
  }
}