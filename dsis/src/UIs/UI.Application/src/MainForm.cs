using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.UI.Application.Actions;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application
{
  [TypeInstanciable]
  public partial class MainForm : Form
  {
    private readonly IActionPresentationManager myActionManager;
    private readonly IMainMenuFactory myMenuFactoy;

    private MainForm()
    {
      InitializeComponent();  
    }

    [Used]
    public MainForm(IActionPresentationManager actionManager, IMainMenuFactory menuFactoy) : this()
    {
      myActionManager = actionManager;
      myMenuFactoy = menuFactoy;

      myMenuFactoy.SetMenu(myActionManager.RootAction, myMainMenu, ()=>new Context());
    }

    public void AddStatusBarControl(ToolStripItem component)
    {
      myStatusBar.Items.Add(component);
    }

    public Control MainContent
    {
      set
      {
        SuspendLayout();

        var host = myToolStrip.ContentPanel;
        host.AutoScroll = true;
        host.Controls.Clear();
        var control = value;
        control.Dock = DockStyle.Fill;
        host.Controls.Add(control);

        ResumeLayout(true);
      }
    }
  }
}