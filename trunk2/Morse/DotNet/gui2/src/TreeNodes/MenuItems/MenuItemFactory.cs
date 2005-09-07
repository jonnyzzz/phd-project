using System;
using System.Collections;
using System.Windows.Forms;
using gui2.src.TreeNodes.MenuItems;
using guiActions.Actions;
using guiKernel2.ActionFactory;
using guiKernel2.Actions;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for MenuItemFactory.
	/// </summary>
	public class MenuItemFactory
	{
		public static MenuItem[] CreateMenuItems(Node node)
		{
			return CreateMenuItems(node, node.GetActions());
		}

		public static MenuItem[] CreateMenuItems(Node node, Action[] actions, params Action[] path)
		{
			ArrayList menus = new ArrayList();

			foreach (Action action in actions)
			{
                if (action is IDisabledAction)
                {                    
                    menus.Add(new DisabledActionMuniItem((IDisabledAction) action));
                } 
                else 
                {
                    menus.Add(new ActionTreeMenuItem(node, action, path));
                }
			}

			return (MenuItem[])menus.ToArray(typeof(MenuItem));
		}

	}
}
