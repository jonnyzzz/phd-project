using System;
using System.Collections;
using System.Windows.Forms;
using guiActions.Actions;
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



		protected Action[] Merge(Action action, params Action[] actions)
		{
			return Merge(new Action[]{action}, actions );
		}

		protected Action[] Merge(Action[] actions1, params Action[] actions2)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(actions1);
			arrayList.AddRange(actions2);
			return (Action[])arrayList.ToArray(typeof(Action));
		}
	}
}
