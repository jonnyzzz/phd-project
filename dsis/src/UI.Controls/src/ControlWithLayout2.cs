using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public class ControlWithLayout2 : IControlWithLayout2
  {
    private readonly Control myControl;
    private readonly string myAncor;
    private readonly Layout[] myLayout;

    public ControlWithLayout2(Control control, string ancor, params Layout[] layout)
    {
      myControl = control;
      myAncor = ancor;
      myLayout = layout;
    }

    public Layout[] Float
    {
      get { return myLayout; }
    }

    public string Ancor
    {
      get { return myAncor; }
    }

    public Control Control
    {
      get { return myControl; }
    }
  }
}