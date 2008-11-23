using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.Controls
{
  [ComponentImplementation]
  public class DockLayout
  {
    public Control Layout(DockStyle dock, IEnumerable<Control> controls)
    {
      var list = new List<Control>(controls);
      var pn = new Panel();

      if (dock == DockStyle.Top || dock == DockStyle.Left)
      {
        list.Reverse();
      }

      Func<Size, Size, Size> fn = ControlSizeCalculator.ComputeSize(dock);
      var sz = new Size(0,0);
      foreach (var control in list)
      {
        control.Dock = dock;
        sz = fn(sz, control.Size);
        pn.Controls.Add(control);
      }
      pn.Size = sz;
      return pn;
    }
  }
}