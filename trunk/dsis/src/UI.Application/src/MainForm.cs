using System.Windows.Forms;
using DSIS.UI.Application.Actions;
using DSIS.UI.FunctionDialog;

namespace DSIS.UI.Application
{
  public partial class MainForm : Form
  {
    private readonly IActionPresentationManager myActionManager;
    private readonly IMainMenuFactory myMenuFactoy;

    private MainForm()
    {
      InitializeComponent();      
    }

    public MainForm(IActionPresentationManager actionManager, IMainMenuFactory menuFactoy) : this()
    {
      myActionManager = actionManager;
      myMenuFactoy = menuFactoy;

      var menu = myMenuFactoy.BuildMenu(myActionManager.RootAction);
      myMainMenu.Items.Clear();
      myMainMenu.Items.AddRange(((ToolStripDropDownItem)menu).DropDownItems);
    }

    private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
    {
      using(var form = new SystemFunctionForm())
      {
        form.ShowDialog(this);
      }
    }
  }
}