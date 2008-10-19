using System.Windows.Forms;
using DSIS.UI.Controls.Web;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class CurrentDocumentControl : HtmlControl, IControlWithTitle
  {
    public CurrentDocumentControl(IApplicationDocument doc)
    {
      SetHTML("<html><body><h1>" + doc.Title + "</h1></body></html>");
    }

    public Control Control
    {
      get { return this; }
    }

    public string Title
    {
      get { return "Document opened"; }
    }
  }
}
