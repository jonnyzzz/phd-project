using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.ComputationDialogs
{
  public class SelectFactoryAndOptionsWizardState<T,Q, O> : WizardPageWithState<T>
    where T : ListSelectorWizardPage<Q>
    where Q : class, IOptionsBasedFactory
  {
    private readonly IFormGeneratorWizardPageFactory myFactory;

    protected SelectFactoryAndOptionsWizardState(T page, IFormGeneratorWizardPageFactory factory)
      : base(page)
    {
      myFactory = factory;
    }

    public Q Factory
    {
      get { return Page.SelectedItem; }
    }

    private Type OptionsType
    {
      get
      {
        var factory = Factory;
        if (factory == null)
          return null;

        return factory.OptionsObjectType;
      }
    }

    public O Settings { get; private set; }

    public override IWizardPageWithState NextPage
    {
      get
      {
        var type = OptionsType;
        if (type == null)
          return null;

        var obj = (O) Activator.CreateInstance(type);
        Settings = obj;

        return new SIConstructionMethodSettingsWizardState(
          myFactory.CreatePage(
            "Settings for " + Factory.FactoryName,
            obj
            ));
      }
    }

    public override bool IsLastPage
    {
      get { return OptionsType == null; }
    }
  }
}