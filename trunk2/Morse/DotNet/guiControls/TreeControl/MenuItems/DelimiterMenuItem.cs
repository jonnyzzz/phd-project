using System;
using System.Windows.Forms;

namespace guiControls.TreeControl.MenuItems
{
	/// <summary>
	/// Summary description for DelimiterMenuItem.
	/// </summary>
	public class DelimiterMenuItem : MenuItem
	{
		public DelimiterMenuItem() : base("-")
		{
			this.Enabled = false;
		}
	}
}
