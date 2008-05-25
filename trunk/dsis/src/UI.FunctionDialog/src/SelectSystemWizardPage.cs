using System.Collections.Generic;
using DSIS.Spring.Service;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SelectSystemWizardPage : WizardPageBase<SelectSystemPage>, IWizardPageWithState
  {
    private readonly Dictionary<SystemSpaceSelection, IWizardPageWithState> myFactory =
      new Dictionary<SystemSpaceSelection, IWizardPageWithState>();

    public SelectSystemWizardPage(IServiceProvider prov)
    {
      Title = "Select the way to define system";
      ControlInternal = new SelectSystemPage();
      myFactory = new Dictionary<SystemSpaceSelection, IWizardPageWithState>
                    {
                      {SystemSpaceSelection.PREDEFINED, new SelectPredefinedSystemWizardPage(prov)},
                      {SystemSpaceSelection.USER, null}
                    };
    }

    public IWizardPageWithState NextPage
    {
      get
      {
        IWizardPageWithState fac;
        return myFactory.TryGetValue(ControlInternal.Value, out fac) ? fac : null;
      }
    }
  }

}