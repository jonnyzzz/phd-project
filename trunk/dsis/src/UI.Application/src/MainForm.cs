using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.UI.Application.Actions;

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

      myMenuFactoy.SetMenu(myActionManager.RootAction, myMainMenu, ()=>new Context());
    }

    public Control MainContent
    {
      set
      {
        myToolStrip.ContentPanel.Controls.Clear();
        var control = value;
        control.Dock = DockStyle.Fill;
        myToolStrip.ContentPanel.Controls.Add(control);
      }
    }
  }
}