using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.UI.Application.Actions;
using System.Linq;

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
  }
}