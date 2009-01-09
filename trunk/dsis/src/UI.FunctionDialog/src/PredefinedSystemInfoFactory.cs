using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.UI.Wizard;

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
    private SelectSystemInfoWizard Factory { get; set; }

    public IWizardPack<ISystemInfo> CreateWizard()
    {
      return Factory;
    }
  }
}