using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Function.UserDefined;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.UI.Wizard.OptionsWizard;
using DSIS.Utils;

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
      private readonly IUserDefinedFunctionFactory myFactory;

      public OptionBa(IListSelectorWizardPageFactory listFactory, IUserDefinedFunctionFactory factory) 
        : base("TBD", listFactory, factory.Enum(), x=>true)
      {
        myFactory = factory;
      }

      protected override Ref<string> ValidateOptions(UserFunctionParameters paramz)
      {
        var result = myFactory.CheckCode(paramz);
        if (result.Count >0)
        {
          return (result.FoldLeft("", (err, x) => x + " " + err)).ToRef();
        }
        return base.ValidateOptions(paramz);
      }
    }
  }  
}