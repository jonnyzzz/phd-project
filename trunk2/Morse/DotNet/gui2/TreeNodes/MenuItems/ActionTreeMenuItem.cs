using System;
using guiActions.action;
using guiKernel2.Actions;
using guiKernel2.src.ActionFactory;
using guiKernel2.src.Container;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for ActionTreeMenuItem.
	/// </summary>
	public class ActionTreeMenuItem : TreeMenuItem
	{
		private ActionWrapper action;

		public ActionTreeMenuItem(Node node, Action action, params Action[] beforeActions) : base(action.ActionName)
		{
			this.action = action;

			if (action.IsChainLeaf)
			{
				this.Text = "<>" + this.Text;
			}

			this.MenuItems.Clear();
			Action[] actionPath = Merge(action, beforeActions);
			this.MenuItems.AddRange(
				MenuItemFactory.CreateMenuItems(
				node, 
				node.GetActionAfer(actionPath),
				actionPath
				));
		}
		
		protected override void EventClick()
		{
			if (action.IsChainLeaf)
			{
				Logger.Logger.LogMessage("Event Click");		
			}
		}
	}
}
