using System.Drawing;
using System.Windows.Forms;

namespace DSIS.UI.Application.Doc
{  
  public class CenterControl : UserControl, IDocumentCenterControl
  {
    protected CenterControl()
    {
      BackColor = Color.Red;
    }

    public Control Control
    {
      get { return this; }
    }

    public string Title
    {
      get { return "Symbolic Image"; }
    }
  }
}