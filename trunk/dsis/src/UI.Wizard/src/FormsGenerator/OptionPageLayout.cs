using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [ComponentImplementation]
  public class OptionPageLayout : IOptionPageLayout
  {
    private readonly IDockLayout myLayout;

    public OptionPageLayout(IDockLayout layout)
    {
      myLayout = layout;
    }

    public Control Layout<Q>(IEnumerable<Q> controls)
      where Q : IOptionPageControl
    {
      return myLayout.Layout(DockStyle.Top, CollectControls(controls));
    }

    private List<Control> CollectControls<Q>(IEnumerable<Q> controls)
      where Q : IOptionPageControl
    {
      var result = new List<Control>();

      foreach (Q q in controls)
      {
        AddAttribute(q.Title, q.Description, q.Control, result);
      }
      return result;
    }

    public void Layout<Q>(Control host, IEnumerable<Q> controls) where Q : IOptionPageControl
    {
      myLayout.Layout(host, DockStyle.Top, CollectControls(controls));
    }

    private static void AddAttribute(string title, string description, Control field, ICollection<Control> result)
    {
      var panel = new Panel
                    {                      
                      Width = 150,
                      Padding = new Padding(0, 0, 5, 5),
                    };
      var caption = new Label
                      {
                        Text = title,
                        Width = 120,
                        Dock = DockStyle.Left,
                      };
      field.Width = 150;
      var sz = Math.Max(field.Height, caption.Height);

      panel.Dock = DockStyle.Top;
      field.Dock = DockStyle.Top;

      panel.Controls.Add(field);
      panel.Controls.Add(caption);
      
      panel.Height = sz;

      result.Add(panel);

      if (description != null)
      {
        var label = new Label
                      {
                        Padding = new Padding(10, 0, 0, 0),
                        Dock = DockStyle.Top,
                        Text = description
                      };

        result.Add(label);
      }
    }
  }
}