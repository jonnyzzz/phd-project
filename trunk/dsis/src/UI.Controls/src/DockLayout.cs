using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Controls
{
  [ComponentImplementation]
  public class DockLayout : IDockLayout
  {
    public Panel Layout(DockStyle dock, IEnumerable<Control> controls)
    {
      var pn = new Panel();
      Layout(pn, dock, controls);
      return pn;
    }

    public void Layout(Control host, DockStyle dock, IEnumerable<Control> controls)
    {
      if (host.Controls.Count != 0)
        throw new ArgumentException("Control should not contain any child controls", "host");

      var list = new List<Control>(controls);
      if (dock == DockStyle.Top || dock == DockStyle.Left)
        list.Reverse();

      var fn = ControlSizeCalculator.ComputeSize(dock);
      var sz = new Size(0, 0);
      foreach (var control in list)
      {
        sz = fn(sz, control.Bounds.Size);
        control.Dock = dock;
        host.Controls.Add(control);        
      }
      host.Size = sz;
    }
  }
}