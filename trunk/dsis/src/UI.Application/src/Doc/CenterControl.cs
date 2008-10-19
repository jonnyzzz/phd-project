using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation]
  public class CenterControl : UserControl, IDocumentControl
  {
    public CenterControl()
    {
      BackColor = Color.Red;
    }

    public Layout[] Float
    {
      get { return new [] {DSIS.UI.Controls.Layout.CENTER}; }
    }

    public string Ancor
    {
      get { return "!"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}