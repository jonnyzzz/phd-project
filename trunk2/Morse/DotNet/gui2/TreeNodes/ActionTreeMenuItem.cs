using System;
using System.Collections;
using System.Windows.Forms;
using gui2.Log;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for ActionTreeMenuItem.
	/// </summary>
	public class ActionTreeMenuItem : TreeMenuItem
	{
		private ActionWrapper action;
		public ActionTreeMenuItem(ActionWrapper action, params ActionWrapper[] beforeActions) : base(action.ActionName)
		{
			this.action = action;

			if (action.isChainLeaf)
			{
				this.Text = "<>" + this.Text;
			}

			this.MenuItems.Clear();
			this.MenuItems.AddRange( MenuItemFactory.CreateMenuItems(NextActionFactory.Instance.NextAction(action, beforeActions)));
		}
		
		protected override void EventClick()
		{
			if (action.isChainLeaf)
			{
				Logger.LogMessage("Event Click");		
			}
		}
	}
}
