using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using System.Linq;
using DSIS.Utils;

namespace DSIS.UI.Controls
{
  [ComponentImplementation]
  public class DockLayout : IDockLayout
  {
    public Panel Layout<C>(DockStyle dock, IEnumerable<C> controls) where C : Control
    {
      var pn = new Panel();
      Layout(pn, dock, controls);
      return pn;
    }

    public void Layout<C>(Control host, DockStyle dock, IEnumerable<C> controls) where C : Control
    {
      if (host.Controls.Count != 0)
        throw new ArgumentException("Control should not contain any child controls", "host");

      var list = new List<C>(controls);

/*
      if (dock == DockStyle.Top || dock == DockStyle.Left)
        list.Reverse();
*/
    
      int tabIndex = host.Controls.Cast<Control>().Select(x=>x.TabIndex).Join(0.Enum()).Max() + 1;
      var fn = ControlSizeCalculator.ComputeSize(dock);
      var sz = new Size(0, 0);
      foreach (var control in list)
      {
        sz = fn(sz, control.Bounds.Size);
        control.Dock = dock;
        host.Controls.Add(control);
        
        control.TabIndex = tabIndex++;

        if (dock == DockStyle.Top || dock == DockStyle.Left)
          host.Controls.SetChildIndex(control, 0);
      }
      host.Size = sz;
    }
  }
}