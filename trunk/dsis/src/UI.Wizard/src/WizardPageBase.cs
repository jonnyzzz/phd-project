using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.Wizard
{
  public class WizardPageBase : IWizardPage
  {
    private Control myControl;
    private BoolErrorProviderHelper myHelper;

    public string Title { get; protected set; }

    public Control Control
    {
      get { return myControl; }
      protected set
      {
        if (myControl != value && myHelper != null)
        {
          myHelper.Dispose();
        }

        myControl = value;
        myHelper = new BoolErrorProviderHelper(myControl);
      }
    }

    public virtual bool Validate()
    {
      return myHelper.Validate();
    }

    public virtual void ControlShown()
    {
    }

    public virtual void ControlHidden()
    {
    }
  }
}