using System.Drawing;
using System.Windows.Forms;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentMeasureImage : ImageDrawingControl, IDocumentCenterControl
  {
    private readonly IoCDrawEntropyMeasureWithBaseAction myAction;
    private readonly IApplicationDocument myDoc;

    public ShowCurrentMeasureImage(
      IApplicationDocument doc,
      IoCDrawEntropyMeasureWithBaseAction action,
      IActionExecution exec,
      IInvocator invocator) : base(exec, invocator)
    {
      myAction = action;
      myDoc = doc;
    }

    protected override string DrawImage(Size sz)
    {
      myAction.Height = sz.Height;
      myAction.Width = sz.Width;
      var ctx = myDoc.Content;

      string file = null;
      if (myAction.Compatible(ctx).Empty())
      {
        var result = myAction.Apply(ctx);
        if (result.ContainsKey(FileKeys.ImageKey))
        {
          file = FileKeys.ImageKey.Get(result).Path;
        }
      }
      return file;
    }

    Control IControlWithTitle.Control
    {
      get { return this; }
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