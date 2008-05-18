using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public class WizardPageBase : IWizardPage
  {
    public string Title { get; protected set; }
    public Control Control { get; protected set; }
    public virtual bool Validate()
    {
      return true;
    }

    public virtual void ControlShown()
    {
    
    }

    public virtual void ControlHidden()
    {
    
    }
  }
}