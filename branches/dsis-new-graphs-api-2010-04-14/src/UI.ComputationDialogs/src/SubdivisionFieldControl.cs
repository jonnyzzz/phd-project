using System.Windows.Forms;

namespace DSIS.UI.ComputationDialogs
{
  public partial class SubdivisionFieldControl : UserControl
  {
    public SubdivisionFieldControl(string caption) : this()
    {
      myLabel.Text = caption;
    }
    public SubdivisionFieldControl()
    {
      InitializeComponent();
    }
  }
}