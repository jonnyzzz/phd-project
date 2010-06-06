using DSIS.Core.System;
using DSIS.UI.Wizard;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class PredefinedSystemInfoFactory : ISystemInfoFactoryProvider
  {
    public string Name
    {
      get { return "Predefined"; }
    }

    public string Description
    {
      get { return "Use one of the systems from the list"; }
    }

    public bool Enabled
    {
      get { return true; }
    }

    [Autowire]
    private ITypeInstantiator Factory { get; set; }

    public IWizardPack<ISystemInfo> CreateWizard()
    {
      return Factory.Instanciate<SelectSystemInfoWizard>();
    }
  }
}