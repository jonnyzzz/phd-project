using System;
using System.Windows.Forms;
using gui2.src.TreeNodes;

namespace gui2.TreeNodes.MenuItems
{
	/// <summary>
	/// Summary description for SelectChildsMenuItem.
	/// </summary>
	public class SelectChildsMenuItem : TreeMenuItem
	{
		private readonly Node node;

		public SelectChildsMenuItem(string text, Node node) : base(text)
		{
			this.node = node;
		}

		protected override void EventClick()
		{
			Group.GetGroup(node).DeCheckAndRemoveAll();
			foreach (TreeNode anode in node.Nodes)
			{
				if (anode is Node)
				{
					Node aNode = (Node)anode;
					aNode.Checked = true;
				}				
			}
		}
	}
}
