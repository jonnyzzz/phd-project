using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Controls.TreeControl
{
    /// <summary>
    /// Summary description for NoMenuItem.
    /// </summary>
    public class NoMenuItem : MenuItem
    {
        public NoMenuItem() : base("No actions")
        {
            this.Enabled = false;
        }
    }
}