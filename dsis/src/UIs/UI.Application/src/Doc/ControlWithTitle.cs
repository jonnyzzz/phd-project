using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  public class ControlWithTitle : IControlWithTitle
  {
    public ControlWithTitle(Control control, string title)
    {
      Control = control;
      Title = title;
    }

    public Control Control { get; private set; }

    public string Title { get; private set; }
  }
}