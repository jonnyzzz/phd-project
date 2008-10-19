using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DocumentControl : IDocumentMainControl
  {
    [Used]
    public DocumentControl(IApplicationDocument doc, IDocumentControl[] controls)
    {
      var m = new SmartLayoutManager();
      Control = new ControlWithTitle(m.LayoutControls(controls), "DSIS :: " + doc.Title);
    }

    public IControlWithTitle Control { get; private set;}
  }
}