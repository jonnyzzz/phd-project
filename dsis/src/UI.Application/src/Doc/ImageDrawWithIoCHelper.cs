using System.Drawing;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  public class ImageDrawWithIoCHelper : ImageDrawingControl
  {
    private readonly IIocDrawHelper myHelper;
    private readonly IApplicationDocument myDocument;

    public ImageDrawWithIoCHelper(IActionExecution exec, IInvocator invocator, IIocDrawHelper helper, IApplicationDocument document) : base(exec, invocator)
    {
      myHelper = helper;
      myDocument = document;
    }

    protected override string DrawImage(Size sz)
    {
      return myHelper.DrawImage(myDocument.Content, sz);
    }
  }
}