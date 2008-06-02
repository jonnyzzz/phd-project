using System;
using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
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
                        if (v != 0) return v;

                        v = x.Dimension.CompareTo(y.Dimension);
                        if (v != 0) return v;

                        return x.FactoryName.CompareTo(y.FactoryName);
                      });

      ControlInternal = ListSelector.Create(
        services.Map(
          x => ListInfo.Create(x.FactoryName, string.Format("Dimension: {0}, Type: {1}", x.Dimension, x.Type), true, x)));
    }

    public IWizardPageWithState NextPage
    {
      get
      {
        var factory = ControlInternal.SelectedValue;
        if (factory == null)
          return null;

        switch (factory.Type)
        {
          case SystemType.Continious:
            return CreateContinious(CreateParameters(factory, CreateSpaceModel(factory)));
          case SystemType.Descrete:
            return CreateParameters(factory, CreateSpaceModel(factory));
        }
        return null;
      }
    }

    private IWizardPageWithState CreateContinious(IWizardPageWithState next)
    {
      return new SelectPredefinedContiniousMethodWizardPage(myProvider, () => next);
    }

    private IWizardPageWithState CreateParameters(IOptionsHolder factory, IWizardPageWithState next)
    {
      return factory.OptionsObjectType == null
               ? next
               : new WizardPageWithStateD(
                   new FormGeneratorWizardPage(
                     "Options",
                     Activator.CreateInstance(factory.OptionsObjectType)),
                   () => next);
    }

    private WizardPageWithStateD CreateSpaceModel(ISystemInfoFactory factory)
    {
      return new WizardPageWithStateD(
        new SpaceControlWizardPage(
          new FixedDimensionSpaceModel(factory.Dimension)),
        () => null);
    }

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}