using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.UI.UI;

namespace DSIS.UI.Controls
{
  public class TabbedLayout
  {
    public Control Layout<T>(IEnumerable<T> controls)
      where T : IControlWithTitle
    {
      var result = new TabControl();
      
      foreach (var control in from c in controls orderby c.Title select c)
      {
        var page = new TabPage
                     {
                       Text = control.Title,
                     };
        var content = control.Control;
        content.Dock = DockStyle.Fill;
        page.Controls.Add(content);
        result.TabPages.Add(page);
      }

      return result;
    }
  }
}