using System;
using System.Windows.Forms;
using DSIS.Core.Builders;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.FunctionDialog.UI;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.Utils;

namespace DSIS.UI.ComputationDialogs
{
  [SIConstructionComponent]
  public class SelectSIConstructionMethodWizardPage : WizardPageBase<ListSelector<ListInfo<ICellImageBuilderFactory>, ICellImageBuilderFactory>>
  {
    public SelectSIConstructionMethodWizardPage(ICellImageBuilderFactory[] factories)
    {
      ControlInternal = ListSelector.Create(
        factories.Map(
        x=>ListInfo.Create(
          x.FactoryName,
          "",
          true,
          x)));
      Title = "Select Cell Image building method"; 
    }

    public ICellImageBuilderFactory SelectedItem
    {
      get { return ControlInternal.SelectedValue; }
    }

    public override bool Validate()
    {
      return SelectedItem != null;
    }
  }

  [SIConstructionComponent]
  public class SelectSIConstructionMethodWizardState : WizardPageWithState<SelectSIConstructionMethodWizardPage>
  {
    public SelectSIConstructionMethodWizardState(SelectSIConstructionMethodWizardPage page)
      : base(page)
    {
    }

    public override IWizardPageWithState NextPage
    {
      get
      {
        var factory = Page.SelectedItem;
        if (factory == null)
          return null;

        var type = factory.OptionsObjectType;
        if (type == null)
          return null;

        var obj = (ICellImageBuilderSettings)Activator.CreateInstance(type);

        return new SelectSIConstructionMethodSettingsWizardState(
          new FormGeneratorWizardPage(
            "Settings for " + factory.FactoryName,
            obj
            ));
      }
    }
  }

  public class SelectSIConstructionMethodSettingsWizardState : WizardPageWithState
  {
    public SelectSIConstructionMethodSettingsWizardState(IWizardPage page) : base(page)
    {
    }

    public override IWizardPageWithState NextPage
    {
      get { return null; }
    }
  }


  [SIConstructionComponent]
  public class SIConstructionWizard : StateWizard
  {
    public SIConstructionWizard(SelectSIConstructionMethodWizardState state)
    {
      Title = "Select Symbolic Image construction method";
      FirstPage = state;
    }
  }
}