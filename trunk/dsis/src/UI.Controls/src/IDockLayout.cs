using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public interface IDockLayout
  {
    Panel Layout<C>(DockStyle dock, IEnumerable<C> controls) where C : Control;

    void Layout<C>(Control host, DockStyle dock, IEnumerable<C> controls) where C : Control;
  }
}