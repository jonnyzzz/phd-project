using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Application.Actions;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class MainFormProxy : IMainForm
  {
    private readonly IActionPresentationManager myActionManager;
    private readonly IMainMenuFactory myMenuFactoy;
    private readonly XmlActionPreesentationManager myPresentation;

    private MainForm myForm = null;

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

    public void SetContent(IControlWithTitle control)
    {
      myForm.MainContent = control.Control;
      myForm.Text = control.Title;
    }
  }
}