using DSIS.UI.Controls.Web;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  public class CurrentDocumentControl : HtmlControl
  {
    public CurrentDocumentControl(IApplicationClass app)
    {
      app.DocumentChanged += DocumentChanged;
      DocumentChanged(this, new DocumentChangedEventArgs(null, app.Document));
    }

    private void DocumentChanged(object sender, DocumentChangedEventArgs e)
    {
      var doc = e.NewDocument;
      if (doc != null)
      {
        SetHTML("<html><body><h1>" + doc.Title + "</h1></body></html>");
      } else
      {
        SetHTML("<html><body><h1>No document selected</h1></body></html>");
      }
    }
  }
}
