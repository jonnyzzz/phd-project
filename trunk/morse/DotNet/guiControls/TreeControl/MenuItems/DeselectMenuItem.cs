using System;
using System.Windows.Forms;

namespace guiControls.TreeControl.MenuItems
{
	/// <summary>
	/// Summary description for DeselectMenuItem.
	/// </summary>
	public class DeselectMenuItem : MenuItem
	{
		private ComputationNode node;
		public DeselectMenuItem(ComputationNode node)
		{
			this.node = node;
			this.Text = "Deselect";
			this.Click +=new EventHandler(DeselectMenuItem_Click);
		}

		private void DeselectMenuItem_Click(object sender, EventArgs e)
		{
			node.TreeView.SelectedNode = null;
		}
	}
}
