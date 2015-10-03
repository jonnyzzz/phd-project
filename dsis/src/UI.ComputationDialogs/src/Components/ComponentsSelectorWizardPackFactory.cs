using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Graph;
using DSIS.UI.Wizard;

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
      return c.GetComponent<ComponentsSelectorWizardPack>();
    }
  }
}