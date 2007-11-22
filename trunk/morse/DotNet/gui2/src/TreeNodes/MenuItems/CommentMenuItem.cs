using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Application.TreeNodes.MenuItems
{
  /// <summary>
  /// Summary description for CommentMenuItem.
  /// </summary>
  public class CommentMenuItem : TreeMenuItem
  {
    public CommentMenuItem(string caption) : base(caption, false)
    {
    }

    protected override void DrawBackGround(DrawItemEventArgs e)
    {
      e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
    }

    protected override void OnMeasureItem(MeasureItemEventArgs e)
    {
      base.OnMeasureItem(e);

      e.ItemHeight += 40;
      e.ItemWidth += 20;
    }

    protected override void DrawFocusedRectangle(DrawItemEventArgs e)
    {
    }

    protected override void BaseDrawItem(DrawItemEventArgs e)
    {
    }

    protected override void EventClick()
    {
    }
  }
}