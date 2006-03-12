using System.Collections;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes.MenuItems;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
    /// <summary>
    /// Summary description for MenuItemFactory.
    /// </summary>
    public class MenuItemFactory
    {
        private static MenuItem CreateMenuItem(Node node, ActionRef actionRef, ResultSet set, out bool next)
        {
			next = false;
			if (actionRef.ActionName == NextActionFactory.SEPARATOR_ACTION)
			{
				return new SeparatorMenuItem();
			} else if (actionRef.Constraint.Match(set))
        	{
				next = true;
        		return new ActionTreeMenuItem(node, actionRef);
        	} else
			{
				return new DisabledActionMuniItem(actionRef.ActionCaption, actionRef.ActionDetail);
			}
        }

		private static void BuildActionTree(Node node, ActionRef action, ResultSet set, MenuItem root)
		{
			foreach (ActionRef act in action.ActionRefs)
			{
				bool cont;
				MenuItem item = CreateMenuItem(node, act, set, out cont);
				root.MenuItems.Add(item);
				if (cont)
				{
					BuildActionTree(node, act, set, item);
				}
			}
		}

		public static MenuItem[] CreateMenuItems(Node node, ActionRef[] actions)
		{
			ResultSet set = node.ResultSet;
			ArrayList items = new ArrayList();
			foreach (ActionRef action in actions)
			{
				bool cont;
				MenuItem item = CreateMenuItem(node, action, set, out cont);
				items.Add(item);
				if (cont)
				{
					BuildActionTree(node, action, set, item);
				}
			}
			return (MenuItem[]) items.ToArray(typeof(MenuItem));
		}
    }
}