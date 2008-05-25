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
    private readonly XmlActionPreesentationManager myPresentation;

    private Form myForm = null;

    public MainFormProxy(IActionPresentationManager actionManager, IMainMenuFactory menuFactoy, XmlActionPreesentationManager presentation)
    {
      myActionManager = actionManager;
      myMenuFactoy = menuFactoy;
      myPresentation = presentation;
    }

    public Form GetFrom()
    {
      if (myForm == null)
      {
        myPresentation.LoadAssembly(GetType().Assembly);
        myForm = new MainForm(myActionManager, myMenuFactoy);
      }
      return myForm;
    }
  }
}