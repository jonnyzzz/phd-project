using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Application.TreeNodes.MenuItems
{
  /// <summary>
  /// Summary description for DisabledActionMuniItem.
  /// </summary>
  public class DisabledActionMuniItem : TreeMenuItem
  {
    private readonly string comment;

    public DisabledActionMuniItem(string title, string detail) : base(title, false)
    {
      comment = detail;
      if (comment != null)
      {
        MenuItems.Add(new CommentMenuItem(comment));
      }
    }

    public string Comment
    {
      get { return comment; }
    }

    protected override void EventClick()
    {
    }

    protected override void DrawBackGround(DrawItemEventArgs e)
    {
      e.Graphics.FillRectangle(new SolidBrush(Color.DarkSalmon), e.Bounds);
    }
  }
}