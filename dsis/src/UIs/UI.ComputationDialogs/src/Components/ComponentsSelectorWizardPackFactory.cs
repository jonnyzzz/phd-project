using System.Collections.Generic;
using DSIS.Graph;
using DSIS.UI.Wizard;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.ComputationDialogs.Components
{
  [ComponentImplementation]
  public class ComponentsSelectorWizardPackFactory : IComponentsSelectorWizardPackFactory
  {
    [Autowire]
    private ISubContainerFactory Factory { get; set; }

    public IWizardPack<ICollection<IStrongComponentInfo>> CreateWizard(IGraphStrongComponents comps)
    {
      var c = Factory.SubContainer<ComponentsComponentImplementationAttribute>(comps);
      return c.Start().GetComponent<ComponentsSelectorWizardPack>();
    }
  }
}