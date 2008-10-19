using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;

namespace DSIS.UI.Application.Doc
{
  [ComponentImplementation]
  public class CurrentStepControl : UserControl, IDocumentControl
  {
    public CurrentStepControl()
    {
      BackColor = Color.BlueViolet;
      Size = MinimumSize = new Size(200, 200);
    }

    public Layout[] Float
    {
      get { return new [] {DSIS.UI.Controls.Layout.LEFT, DSIS.UI.Controls.Layout.TOP, }; }
    }

    public string Ancor
    {
      get { return "010"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }

//  [ComponentImplementation]
  public class CurrentGapControl : UserControl, IDocumentControl
  {
    public CurrentGapControl()
    {
      BackColor = Color.Black;
      Size = MinimumSize = new Size(200, 200);
    }

    public Layout[] Float
    {
      get { return new [] {DSIS.UI.Controls.Layout.LEFT, DSIS.UI.Controls.Layout.CENTER }; }
    }

    public string Ancor
    {
      get { return "GAP"; }
    }

    public Control Control
    {
      get { return this; }
    }
  }
}