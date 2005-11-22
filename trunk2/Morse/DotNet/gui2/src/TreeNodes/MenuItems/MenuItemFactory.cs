using System.Collections;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Application.TreeNodes.MenuItems;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;

namespace EugenePetrenko.Gui2.Application.TreeNodes
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
                } else if (action is ISeparator)
                {
                    menus.Add(new SeparatorMenuItem());
                } else {
                    menus.Add(new ActionTreeMenuItem(node, action, path));
                }
            }

            return (MenuItem[]) menus.ToArray(typeof (MenuItem));
        }

    }
}