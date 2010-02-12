using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedContiniousMethodWizardPage : WizardPageBase<ListSelector<ListInfo<IContiniousFunctionSolverFactory>, IContiniousFunctionSolverFactory>>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;
    private readonly Func<IWizardPageWithState> myNext;

    public SelectPredefinedContiniousMethodWizardPage(ISystemFunctionSelectionWizardInt wizard, IServiceProvider prov, Func<IWizardPageWithState> next)
    {
      myWizard = wizard;
      var services = prov.GetServices<IContiniousFunctionSolverFactory>();
      var map = services.Map(x => ListInfo.Create(x.MethodName, "", true, x));
      ControlInternal = prov
        .GetService<IListSelectorFactory>()
        .Create<ListInfo<IContiniousFunctionSolverFactory>, IContiniousFunctionSolverFactory>(map);
      myNext = next;

      Title = "Select continious system solver";
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
              myWizard.FormGeneratorWizardPageFactory.CreatePage("Continiois system solver parameters",paramz),
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