using System.Windows.Forms;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.Layout.Impl
{
  [ComponentImplementation]
  public class ScrollableLayoutImpl : IScrollableLayout
  {
    public Control MakeScrollableOnY(Control pn)
    {
      if (pn is ScrollableControl)
      {
        MakeScrollableOnY((ScrollableControl)pn);
        return pn;
      }

      var p = new Panel {MinimumSize = pn.MinimumSize, Size = pn.Size};
      pn.Dock = DockStyle.Fill;
      p.Controls.Add(pn);
      MakeScrollableOnY(p);
      return p;
    }

    private static void MakeScrollableOnY(ScrollableControl control)
    {
      control.AutoScrollMargin = new System.Drawing.Size(5, 13);
      control.ClientSize = control.Size;

      control.VerticalScroll.Visible = true;
      control.VerticalScroll.Enabled = true;   
      control.AutoScroll = true;
    }
  }
}