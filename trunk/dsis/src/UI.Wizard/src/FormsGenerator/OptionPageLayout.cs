using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Controls;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IOptionPageLayout
  {
    Control Layout<Q>(IEnumerable<Q> controls)
      where Q : IOptionPageControl;
  }

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
      var result = new List<Control>();

      foreach (Q q in controls)
      {
        AddAttribute(q.Title, q.Description, q.Control, result);
      }

      return myLayout.Layout(DockStyle.Top, result);
    }

    private static void AddAttribute(string title, string description, Control field, ICollection<Control> result)
    {
      var panel = new Panel
                    {
                      Dock = DockStyle.Top,
                      Width = 150,
                      Padding = new Padding(0, 0, 5, 5),
                      Height = 25
                    };
      var caption = new Label
                      {
                        Text = title,
                        Width = 70,
                        Dock = DockStyle.Left,
                      };
      field.Width = 150;
      field.Dock = DockStyle.Left;

      panel.Controls.Add(field);
      panel.Controls.Add(caption);

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