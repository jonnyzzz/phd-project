using System.Windows.Forms;
using DSIS.UI.Application.Doc;
using DSIS.UI.Controls;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Progress
{
  [DocumentComponent]
  public class ActionProgressControl : ActionExecutorProgressControl, IDocumentControl, IDocumentComponent
  {
    public ActionProgressControl(IInvocator invocator) : base(invocator)
    {
    }

    public string Ancor
    {
      get { return "ZZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] {Layout.LEFT, Layout.BOTTON,}; }
    }
  }
}