using System;
using System.Windows.Forms;

namespace guiControls.TreeControl
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
