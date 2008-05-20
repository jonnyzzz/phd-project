using System.Windows.Forms;
using DSIS.Spring;
using DSIS.UI.Application.Actions;

namespace DSIS.UI.Application
{
  [UsedBySpring]
  public class MainFormProxy : IMainForm
  {
    private readonly IActionPresentationManager myActionManager;
    private readonly IMainMenuFactory myMenuFactoy;

    public MainFormProxy(IActionPresentationManager actionManager, IMainMenuFactory menuFactoy)
    {
      myActionManager = actionManager;
      myMenuFactoy = menuFactoy;
    }

    public Form GetFrom()
    {
      return new MainForm(myActionManager, myMenuFactoy);
    }
  }
}