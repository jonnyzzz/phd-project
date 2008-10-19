using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.Controls
{
  public interface IControlWithLayout2
  {
    string Ancor { get; }
    Layout[] Float { get; }
    Control Control { get; }
  }

  public class LayoutManager
  {
    private static Panel AddPanel(Queue<IControlWithLayout> controls, Control root)
    {
      var control = controls.Dequeue();
      var value = control.Control;

      var borderSize = root.Padding.Size + root.Padding.Size + new Size(2, 2);

      Layout expectedLayout = control.Float;
      var layout = new Panel
                     {
                       Dock = FromLayout(expectedLayout), 
                       BackColor = Color.Orange, 
                       Padding = new Padding(5),
                       Text = value.GetType().ToString()
                     };
      var content = new Panel
                      {
                        Padding = new Padding(5),
                        Dock = DockStyle.Fill, 
                        BackColor = Color.Yellow, 
                        Text = "Container: " + value.GetType()
                      };

      layout.Size = value.Size + layout.Padding.Size + layout.Padding.Size;
      layout.MinimumSize = value.MinimumSize + layout.Padding.Size + layout.Padding.Size;

      value.Dock = DockStyle.Fill;
      layout.Controls.Add(value);

      root.Controls.Add(content);
      root.Controls.Add(layout);

      if (controls.Count == 0)
      {
        root.Size = layout.Size + borderSize;
        root.MinimumSize = layout.MinimumSize + borderSize;
        return content;
      }

      var result = AddPanel(controls, content);
      var f = ComputeSize(expectedLayout);
      root.Size = f(layout.Size, content.Size) + borderSize;
      root.MinimumSize = f(layout.MinimumSize, content.MinimumSize) + borderSize;
      return result;
    }

    private static Func<Size, Size, Size> ComputeSize(Layout expectedLayout)
    {
      
      switch (expectedLayout)
      {
        case Layout.BOTTON:
        case Layout.TOP:
          return (a,b) => new Size(
                         Math.Max(a.Width, b.Width),
                         a.Height + b.Height
                         );
        case Layout.LEFT:
        case Layout.RIGHT:
          return (a,b) => new Size(
                         a.Width + b.Width,
                         Math.Max(a.Height, b.Height)
                         );
        default:
          return (a, b) => { throw new ArgumentException("layout " + expectedLayout + " not supported"); };
      }
    }

    public Control LayoutControls(IEnumerable<IControlWithLayout> _controls)
    {
      var controls = new List<IControlWithLayout>(_controls);
      controls.Sort((a,b)=>a.Ancor.CompareTo(b.Ancor));

      var result = new Panel {AutoSize = true};
      var deeper = AddPanel(new Queue<IControlWithLayout>(controls.Filter(x=>x.Float != Layout.CENTER)), result);

      foreach (var control in controls.Filter(x=>x.Float == Layout.CENTER))
      {
        var value = control.Control;
        value.Dock = DockStyle.Fill;
        deeper.Controls.Add(value);
      }

      return result;
    }

    private static DockStyle FromLayout(Layout l)
    {
      switch(l)
      {
        case Layout.CENTER:
          return DockStyle.Fill;

        case Layout.RIGHT:
          return DockStyle.Right;
        case Layout.BOTTON:
          return DockStyle.Bottom;
        case Layout.TOP:
          return DockStyle.Top;
        case Layout.LEFT:
          return DockStyle.Left;
      }
      throw new NotImplementedException("Does not support layout " + l);
    }
  }
}