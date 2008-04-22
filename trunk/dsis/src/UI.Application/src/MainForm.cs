using System.Windows.Forms;
using DSIS.UI.FunctionDialog.src;

namespace DSIS.UI.Application
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
    {
      using(SystemFunctionForm form = new SystemFunctionForm())
      {
        form.ShowDialog(this);
      }
    }
  }
}