using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.Utils;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedContiniousMethodWizardPage : WizardPageBase<ListSelector<ListInfo<IContiniousFunctionSolverFactory>, IContiniousFunctionSolverFactory>>, IWizardPageWithState
  {
    private readonly Lazy<IWizardPageWithState> myNext;

    public SelectPredefinedContiniousMethodWizardPage(IServiceProvider prov, Lazy<IWizardPageWithState> next)
    {
      var services = prov.GetServices<IContiniousFunctionSolverFactory>();
      ControlInternal = ListSelector.Create(services.Map(x => ListInfo.Create(x.MethodName, "", true, x)));
      myNext = next;
    }

    public IWizardPageWithState NextPage
    {
      get
      {
        var factory = ControlInternal.SelectedValue;
        if (factory == null)
          return null;

        if (factory.OptionsObjectType != null)
        {
          return
            new WizardPageWithStateD(
              new FormGeneratorWizardPage("Continiois system evaluation parameters",
                                          Activator.CreateInstance(factory.OptionsObjectType)),
              myNext);
        }
        return myNext();
      }
    }

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}