using System.Windows.Forms;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [ComponentImplementation]
  public class ScrollableLayoutImpl : IScrollableLayout
  {
    public void MakeScrollableOnY(ScrollableControl control)
    {
      control.ClientSize = control.Size;
      control.AutoScrollMargin = control.Size;
      control.MinimumSize = control.Size;

      control.VerticalScroll.Visible = true;
      control.VerticalScroll.Enabled = true;     
      control.AutoScroll = true;
    }
  }
}