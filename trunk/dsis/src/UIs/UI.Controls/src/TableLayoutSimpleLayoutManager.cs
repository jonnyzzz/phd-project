using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Controls
{
  public class TableLayoutSimpleLayoutManager : ISimpleLayoutManager
  {
    public Control LayoutControls<Q>(IEnumerable<Q> _controls) where Q : IControlWithLayout
    {
      var qs = new CellData<Q>(_controls);
      var pn = new TableLayoutPanel
                 {
                   ColumnCount = qs.Cols, 
                   RowCount = qs.Rows
                 };

      foreach (var c in _controls)
      {
        pn.Controls.Add(c.Control, qs.Col(c.Float), qs.Row(c.Float));
      }

      return pn;
    }
  }
}