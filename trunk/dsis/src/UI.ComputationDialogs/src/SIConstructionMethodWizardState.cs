using System;
using DSIS.Core.Builders;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SIConstructionMethodWizardState : WizardPageWithState<SIConstructionMethodWizardPage>
  {
    public SIConstructionMethodWizardState(SIConstructionMethodWizardPage page)
      : base(page)
    {
    }

    private ICellImageBuilderFactory Factory
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

    public ICellImageBuilderSettings Settings { get; private set; }

    public override IWizardPageWithState NextPage
    {
      get
      {
        var type = OptionsType;
        if (type == null)
          return null;

        var obj = (ICellImageBuilderSettings) Activator.CreateInstance(type);
        Settings = obj;

        return new SIConstructionMethodSettingsWizardState(
          new FormGeneratorWizardPage(
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