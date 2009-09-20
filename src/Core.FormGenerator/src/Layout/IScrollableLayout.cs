using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Layout
{
  public interface IScrollableLayout
  {
    Control MakeScrollableOnY(Control pn);
  }
}