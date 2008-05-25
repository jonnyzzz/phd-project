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
    private static readonly ILog LOG = LogManager.GetLogger(typeof (SelectPredefinedSystemWizardPage));
    private readonly IServiceProvider myProvider;

    public SelectPredefinedSystemWizardPage(IServiceProvider prov)
    {
      myProvider = prov;
      var services = prov.GetServices<ISystemInfoFactory>();
      if (LOG.IsDebugEnabled)
      {
        using (NDC.Push("Predefined systems"))
        {
          foreach (var service in services)
          {
            LOG.DebugFormat("System: {0}", service.FactoryName);
          }
        }
      }
      ControlInternal = new SelectPredefinedSystemPage(services);
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
        else if (factory.Type == SystemType.Continious)
        {
          return
            new WizardPageWithStateD(
              new SelectPredefinedContiniousMethodWizardPage(myProvider),
              () => page);
        }
        else return null;
      }
    }
  }
}