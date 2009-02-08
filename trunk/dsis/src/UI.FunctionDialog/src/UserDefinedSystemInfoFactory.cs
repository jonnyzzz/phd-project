using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Function.UserDefined;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.UI.Wizard.OptionsWizard;

namespace DSIS.UI.FunctionDialog
{
  [SystemFunctionComponent]
  public class UserDefinedSystemInfoFactory : ISystemInfoFactoryProvider
  {
    [Autowire]
    private IFormGeneratorWizardPageFactory FormGen { get; set; }

    [Autowire]
    private ITypeInstantiator TypeInstantiator{ get; set;}

    public string Name
    {
      get { return "User defined"; }
    }

    public string Description
    {
      get { return "Alows to create new system and use it throuh the system"; }
    }

    public bool Enabled
    {
      get { return true; }
    }

    public IWizardPack<ISystemInfo> CreateWizard()
    {
      return TypeInstantiator.Instanciate<OptionBa>();
    }

    [TypeInstanciable]
    private class OptionBa : OptionsBasedWizard<UserFunctionParameters, ISystemInfo, IUserDefinedFunctionFactory>
    {
      public OptionBa(IListSelectorWizardPageFactory listFactory, IEnumerable<IUserDefinedFunctionFactory> factories) : base("TBD", listFactory, factories, x=>true)
      {
      }
    }
  }  
}