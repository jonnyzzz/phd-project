using DSIS.UI.Wizard;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class SelectSystemInfoProviderWizardFactory : IWizardPackFactory<ISystemInfoFactoryProvider>
  {
    [Autowire]
    private ITypeInstantiator myInstanciator { get; set; }

    public IWizardPack<ISystemInfoFactoryProvider> CreateWizard()
    {
      return myInstanciator.Instanciate<SelectSystemInfoProviderWizard>();
    }
  }
}