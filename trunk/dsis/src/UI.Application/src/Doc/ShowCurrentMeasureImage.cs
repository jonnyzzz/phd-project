using System.Drawing;
using System.Windows.Forms;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentMeasureImage : IDocumentCenterControl
  {
    private readonly ImageDrawWithIoCHelper myHelper;

    public ShowCurrentMeasureImage(
      IApplicationDocument doc,
      IoCDrawEntropyMeasure action,
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
      get { return "Invariant Measure"; }
    }

    public string SortOrder
    {
      get { return "000h"; }
    }
  }
}