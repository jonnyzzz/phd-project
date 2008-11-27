using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public interface ISimpleLayoutManager
  {
    Control LayoutControls<Q>(IEnumerable<Q> _controls)
      where Q : IControlWithLayout;
  }
}