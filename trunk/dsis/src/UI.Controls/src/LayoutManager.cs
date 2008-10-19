using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.Controls
{
  public class LayoutManager
  {
    private readonly List<IControlWithLayout> myControls = new List<IControlWithLayout>();

    public void AddControl(IControlWithLayout control)
    {
      myControls.Add(control);
    }

    public void AddControl(Control control, string ancor, Layout @float)
    {
      AddControl(new ControlWithLayout(control, ancor, @float));
    }

    public Control LayoutControls()
    {
      myControls.Sort((a,b)=>a.Ancor.CompareTo(b.Ancor));

      var root = new Panel();
      var result = root;
      foreach (var control in myControls.Filter(x=>x.Float != Layout.CENTER))
      {
        var layout = new Panel {Dock = FromLayout(control.Float) };
        var content = new Panel{Dock = DockStyle.Fill};

        control.Control.Dock = DockStyle.Fill;
        layout.Controls.Add(control.Control);

        root.Controls.Add(layout);
        root.Controls.Add(content);
        root = content;
      }
      foreach (var control in myControls.Filter(x=>x.Float == Layout.CENTER))
      {
        Control value = control.Control;
        value.Dock = DockStyle.Fill;
        root.Controls.Add(value);
      }

      return result;
    }

    private static DockStyle FromLayout(Layout l)
    {
      switch(l)
      {
        case Layout.CENTER:
          return DockStyle.Fill;
        case Layout.EAST:
          return DockStyle.Right;
        case Layout.NORTH:
          return DockStyle.Bottom;
        case Layout.SOUTH:
          return DockStyle.Top;
        case Layout.WEST:
          return DockStyle.Left;
      }
      throw new NotImplementedException("Does not support layout " + l);
    }
  }
}