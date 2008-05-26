using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using log4net;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedSystemWizardPage : WizardPageBase<SelectPredefinedSystemPage>, IWizardPageWithState
  {
    private readonly IServiceProvider myProvider;
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectPredefinedSystemWizardPage(IServiceProvider prov, ISystemFunctionSelectionWizardInt wizard)
    {
      myProvider = prov;
      myWizard = wizard;
      ControlInternal = new SelectPredefinedSystemPage(prov.GetServices<ISystemInfoFactory>());
    }

    public IWizardPageWithState NextPage
    {
      get
      {
        var factory = ControlInternal.SelectedFactory;
        if (factory == null)
          return null;

        var page = new WizardPageWithStateD(
          new SpaceControlWizardPage(
            new FixedDimensionSpaceModel(factory.Dimension)), () => null);

        if (factory.OptionsObjectType != null)
        {
          var _page = page;
          page = new WizardPageWithStateD(
            new FormGeneratorWizardPage("Options", Activator.CreateInstance(factory.OptionsObjectType)),
            () => _page
            );
        }

        if (factory.Type == SystemType.Descrete)
        {
          return page;
        }
        
        if (factory.Type == SystemType.Continious)
        {
          return new WizardPageWithStateD(
              new SelectPredefinedContiniousMethodWizardPage(myProvider),
              () => page);
        }
        
        return null;
      }
    }
  }
}