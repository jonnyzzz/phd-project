using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public interface IDockLayout
  {
    Control Layout(DockStyle dock, IEnumerable<Control> controls);

    void Layout(Control host, DockStyle dock, IEnumerable<Control> controls);
  }
}