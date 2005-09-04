using System;
using System.Drawing;
using System.Windows.Forms;
using gui2.ActionPerformer;
using guiActions.Actions;
using guiKernel2.Actions;
using guiKernel2.ActionFactory;
using guiKernel2.Container;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for ActionTreeMenuItem.
	/// </summary>
	public class ActionTreeMenuItem : TreeMenuItem
	{
		private Action action;
		private Action[] actionPath;
		private Node node;

		public ActionTreeMenuItem(Node node, Action action, params Action[] beforeActions) : base(action.ActionName, action.IsChainLeaf)
		{
			this.action = action;
			this.node = node;

			this.MenuItems.Clear();
			actionPath = Merge(beforeActions, action);
			this.MenuItems.AddRange(
				MenuItemFactory.CreateMenuItems(
				    node, 
				    node.GetActionAfter(actionPath),
				    actionPath
				    )
                );

			this.OwnerDraw = true;

		}


	
		
		protected override void EventClick()
		{
			if (action.IsChainLeaf)
			{
				Logger.Logger.LogMessage("Event Click");
				Runner.Runner.Instance.ComputationForm.AcceptActionChain(node, actionPath);
			}
		}

		
	}
}
