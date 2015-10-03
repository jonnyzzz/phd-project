using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Controls.TreeControl.MenuItems
{
  /// <summary>
  /// Summary description for DelimiterMenuItem.
  /// </summary>
  public class DelimiterMenuItem : MenuItem
  {
    public DelimiterMenuItem() : base("-")
    {
      Enabled = false;
    }
  }
}