using System;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;
using DSIS.UI.Wizard.ListSelector;
using IServiceProvider=DSIS.Spring.Service.IServiceProvider;

namespace DSIS.UI.FunctionDialog
{
  [Obsolete]
  public class SelectSystemWizardPage :
    WizardPageBase<ListSelector<ListInfo<IWizardPageWithState>, IWizardPageWithState>>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectSystemWizardPage(IServiceProvider prov, ISystemFunctionSelectionWizardInt wizard)
    {
      myWizard = wizard;
      Title = "Select the way to define system";
      var selector = prov
        .GetService<IListSelectorFactory>()
        .Create<ListInfo<IWizardPageWithState>, IWizardPageWithState>(
        new[]
          {
            ListInfo.Create<IWizardPageWithState>(
              "Predefined",
              "Use one of the systems from the list",
              true,
              new SelectPredefinedSystemWizardPage
                (
                prov,
                myWizard
                )
              ),
            ListInfo.Create<IWizardPageWithState>(
              "User defined",
              "Alows to create new system and use it throuh the system",
              false,
              null
              )
          });
      prov.GetService<IScrollableLayout>().MakeScrollableOnY(selector);
      ControlInternal = selector;
    }

    public IWizardPageWithState NextPage
    {
      get { return ControlInternal.SelectedValue; }
    }

    public bool IsLastPage
    {
      get { return false; }
    }
  }
}