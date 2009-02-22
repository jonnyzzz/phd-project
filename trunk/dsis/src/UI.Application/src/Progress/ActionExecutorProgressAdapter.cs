using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  public class ActionExecutorProgressAdapter : UserControl
  {
    private readonly ActionExecutorProgressControl myControl;

    public IActionExecution Execution { get { return myControl; } }

    public ActionExecutorProgressAdapter(Control usersControl, ITypeInstantiator instance)
    {
      myControl = instance.Instanciate<ActionExecutorProgressControl>(new OneTreadExecutor());

      var cnt = myControl.Control;
      cnt.Visible = false;
      cnt.Dock = DockStyle.Bottom;

      usersControl.Dock = DockStyle.Fill;

      Controls.Add(cnt);
      Controls.Add(usersControl);

      myControl.ComputationStarted += delegate { cnt.Visible = true; };
      myControl.ComputationFinished += delegate { cnt.Visible = false; };
    }
  }
}