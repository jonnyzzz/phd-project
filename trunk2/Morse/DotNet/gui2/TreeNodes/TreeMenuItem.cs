using System;
using System.Collections;
using System.Windows.Forms;
using guiKernel2.Actions;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for TreeMenuItem.
	/// </summary>
	/// 

	public abstract class TreeMenuItem : MenuItem
	{
		public TreeMenuItem(string caption) : base(caption)
		{
			this.Click +=new EventHandler(TreeMenuItem_Click);
		}

		protected abstract void EventClick();
		private void TreeMenuItem_Click(object sender, EventArgs e)
		{
			EventClick();
		}
	}
}
