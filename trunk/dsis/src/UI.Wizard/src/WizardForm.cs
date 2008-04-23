using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public partial class WizardForm : Form
  {
    private readonly WizardFormModel myModel;


    public WizardForm() : this(new WizardFormModel())
    {
    }

    public WizardForm(WizardFormModel model)
    {
      myModel = model;
      InitializeComponent();
    }    
  }
}
