using System.Windows.Forms;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DocumentControl : IDocumentMainControl
  {
    
    [Used]
    public DocumentControl(IApplicationDocument doc, IDocumentControl[] control)
    {
      var m = new LayoutManager();
      foreach (var c in control)
      {
        m.AddControl(c);
      }
      Control = new ControlWithTitle(m.LayoutControls(), "DSIS :: " + doc.Title);
    }

    public IControlWithTitle Control { get; private set;}
  }
}