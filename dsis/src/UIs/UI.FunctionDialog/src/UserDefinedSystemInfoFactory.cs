using System.Windows.Forms;
using DSIS.Core.System;
using DSIS.Function.UserDefined;
using DSIS.UI.FunctionDialog.UI;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.UI.Wizard.OptionsWizard;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

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
        : base("Select Type of User-defined System Function", listFactory, factory.Enum(), x=>true)
      {
        myFactory = factory;
      }

      protected override ValidationResult ValidateOptions(IWizardPage page, UserFunctionParameters paramz)
      {
        var result = myFactory.CheckCode(paramz);
        if (result.Second.Count > 0)
        {
          using(var form = new CompilerErrorForm(result))
          {
            var dr= form.ShowDialog(page.Control.FindForm());
            if (dr == DialogResult.Retry)
              return ValidationResult.Retry;
            return ValidationResult.Cancel;
          }
        }
          
        return base.ValidateOptions(page, paramz);
      }
    }
  }  
}