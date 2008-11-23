using System;
using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedSystemWizardPage :
    WizardPageBase<ListSelector<ListInfo<ISystemInfoFactory>, ISystemInfoFactory>>, IWizardPageWithState
  {
    private readonly IServiceProvider myProvider;
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectPredefinedSystemWizardPage(IServiceProvider prov, ISystemFunctionSelectionWizardInt wizard)
    {
      myProvider = prov;
      myWizard = wizard;
      var services = new List<ISystemInfoFactory>(prov.GetServices<ISystemInfoFactory>());
      services.Sort(delegate(ISystemInfoFactory x, ISystemInfoFactory y)
                      {
                        var v = x.Type.CompareTo(y.Type);
                        if (v != 0) return -v;

                        v = x.Dimension.CompareTo(y.Dimension);
                        if (v != 0) return v;

                        return x.FactoryName.CompareTo(y.FactoryName);
                      });

      ControlInternal = ListSelector.Create(
        services.Map(
          x => ListInfo.Create(
            x.FactoryName, 
            string.Format("Dimension: {0}, Type: {1}", x.Dimension, x.Type), 
            true, 
            x)));
    }

    public override void ControlShown()
    {
      var factory = myWizard.SystemFactory;
      if (factory != null) 
        ControlInternal.SelectedValue = factory;
      
      base.ControlShown();
    }

    public override void ControlHidden()
    {
      var value = SelectedValue();
      if (value != null)
      {
        myWizard.SystemFactory = value;
      }
      base.ControlHidden();
    }

    public IWizardPageWithState NextPage
    {
      get
      {
        var factory = SelectedValue();
        if (factory == null)
          return null;

        var systemSelector = CreateParameters(factory, CreateSpaceModel(factory, CreateFinalPage()));

        switch (factory.Type)
        {
          case SystemType.Continious:
            return CreateContinious(systemSelector);
          case SystemType.Descrete:
            return systemSelector;
        }
        return null;
      }
    }

    private ISystemInfoFactory SelectedValue()
    {
      return ControlInternal.SelectedValue;
    }

    private IWizardPageWithState CreateContinious(IWizardPageWithState next)
    {
      return new SelectPredefinedContiniousMethodWizardPage(myWizard, myProvider, () => next);
    }

    private IWizardPageWithState CreateParameters(IOptionsHolder factory, IWizardPageWithState next)
    {
      if (factory.OptionsObjectType == null)
        return next;

      var instance = Activator.CreateInstance(factory.OptionsObjectType);

      myWizard.SystemParameters = (ISystemInfoParameters) instance;
      return factory.OptionsObjectType == null
               ? next
               : new WizardPageWithStateD(
                 myProvider.GetService<IFormGeneratorWizardPageFactory>()
                 .CreatePage(
                     "Options",
                     instance),
                   () => next);
    }

    private WizardPageWithStateD CreateSpaceModel(ISystemInfoFactory factory, IWizardPageWithState next)
    {
      var model = new FixedDimensionSpaceModel(factory.Dimension);
      myWizard.Space = model;

      return new WizardPageWithStateD(
        new SpaceControlWizardPage(
          model),
        () => next);
    }

    private IWizardPageWithState CreateFinalPage()
    {
      return new SelectSystemConfirmPage(myWizard);
    }

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}