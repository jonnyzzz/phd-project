using DSIS.Spring.Service;
using DSIS.UI.FunctionDialog.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SelectSystemWizardPage :
    WizardPageBase<ListSelector<ListInfo<IWizardPageWithState>, IWizardPageWithState>>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectSystemWizardPage(IServiceProvider prov, ISystemFunctionSelectionWizardInt wizard)
    {
      myWizard = wizard;
      Title = "Select the way to define system";
      ControlInternal = ListSelector.Create(new[]
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