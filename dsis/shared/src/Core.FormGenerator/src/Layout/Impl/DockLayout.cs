using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using EugenePetrenko.Core.FormGenerator.Layout.Impl;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.Layout.Impl
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
   
      int tabIndex = host.Controls.Cast<Control>().Select(x=>x.TabIndex).Merge(0.Enum()).Max() + 1;
      var fn = ControlSizeCalculator.ComputeSize(dock);
      var sz = new Size(0, 0);
      foreach (var control in list)
      {
        sz = fn(sz, control.Size);
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