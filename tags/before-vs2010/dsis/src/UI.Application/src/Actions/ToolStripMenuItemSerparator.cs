using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  public class ToolStripMenuItemSerparator : ToolStripSeparator, IMenuItem<ToolStripItem>
  {
    public void Update()
    {
    }

    public ToolStripItem MainMenu
    {
      get { return this; }
    }

    public ICollection<IMenuItem<ToolStripItem>> Children
    {
      get { return EmptyArray<IMenuItem<ToolStripItem>>.Instance; }
    }
  }
}