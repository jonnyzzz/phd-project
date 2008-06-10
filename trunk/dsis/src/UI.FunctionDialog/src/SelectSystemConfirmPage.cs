using DSIS.UI.Controls.Web;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public class SelectSystemConfirmPage : WizardPageBase<HtmlControl>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectSystemConfirmPage(ISystemFunctionSelectionWizardInt wizard)
    {
      myWizard = wizard;
      ControlInternal = new HtmlControl();
      ControlInternal.SetHTML("<html><head><title>aaa</title><body><h1>TestControl</h1></body></html>");
    }

    public IWizardPageWithState NextPage
    {
      get { return null; }
    }

    public bool IsLastPage
    {
      get { return true; }
    }
  }
}