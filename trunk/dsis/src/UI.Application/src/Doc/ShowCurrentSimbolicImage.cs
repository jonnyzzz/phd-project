using System.Drawing;
using System.Windows.Forms;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentSimbolicImage : IDocumentCenterControl
  {
    private readonly ImageDrawWithIoCHelper myHelper;

    public ShowCurrentSimbolicImage(
      IApplicationDocument doc, 
      IoCDrawSimbolicImage action, 
      IActionExecution exec,
      IInvocator invocator)      
    {
      myHelper = new ImageDrawWithIoCHelper(exec, invocator, action, doc);
    }

    Control IControlWithTitle.Control
    {
      get { return myHelper; }
    }

    string IControlWithTitle.Title
    {
      get { return "Symbolic Image"; }
    }

    public string SortOrder
    {
      get { return "000a"; }
    }
  }
}