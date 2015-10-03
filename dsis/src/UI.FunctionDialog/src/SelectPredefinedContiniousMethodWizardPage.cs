using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.FunctionDialog.UI;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.Utils;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedContiniousMethodWizardPage : WizardPageBase<ListSelector<ListInfo<IContiniousFunctionSolverFactory>, IContiniousFunctionSolverFactory>>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;
    private readonly Lazy<IWizardPageWithState> myNext;

    public SelectPredefinedContiniousMethodWizardPage(ISystemFunctionSelectionWizardInt wizard, IServiceProvider prov, Lazy<IWizardPageWithState> next)
    {
      myWizard = wizard;
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
          var paramz = Activator.CreateInstance(factory.OptionsObjectType);

          myWizard.ContiniousParameters = (IContiniousSolverParameters) paramz;

          return
            new WizardPageWithStateD(
              new FormGeneratorWizardPage("Continiois system evaluation parameters",
                                          paramz),
              myNext);
        }
        return myNext();
      }
    }

    public override void ControlShown()
    {
      var factory = myWizard.ContiniousFactory;
      if (factory != null)
      {
        ControlInternal.SelectedValue = factory;
      }
      base.ControlShown();
    }

    public override void ControlHidden()
    {
      myWizard.ContiniousFactory = ControlInternal.SelectedValue;
      base.ControlHidden();
    }

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}