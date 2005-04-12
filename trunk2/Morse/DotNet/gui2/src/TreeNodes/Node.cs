using System.Windows.Forms;
using gui2.src.TreeNodes;
using gui2.src.TreeNodes.MenuItems;
using guiActions.Actions;
using guiActions.src.filter;
using guiControls.TreeControl;
using guiKernel2.Node;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	public class Node : ComputationNode
	{	
		private KernelNode kernelNode;
		public Node(KernelNode kernelNode) : base()
		{
			this.kernelNode = kernelNode;			
			Update();
		}


		public override string NodeCaption
		{
			get { return string.Format("{0}", kernelNode.Caption); }
		}

		private MenuItem[] cachedMenuItems = null;
		protected MenuItem[] GetMenuItemsActions()
		{
			if (cachedMenuItems == null) 
			{
				cachedMenuItems = MenuItemFactory.CreateMenuItems(this, Filter.FilterActions(kernelNode.GetNextActions()));
			}
			return cachedMenuItems;
		}

		protected override MenuItem[] GetMenuItems()
		{
			Group group = Group.GetGroup(this);
			if (group.Contains(this))
			{
				return MergeWithDelimiter(GetMenuItemsActions(), new DelegatedMenuItem("Create Group", new Click(CreateGroup)));
			} else if (this.Nodes.Count > 0)
			{
				return MergeWithDelimiter(GetMenuItemsActions(), new DelegatedMenuItem("Group all childs", new Click(CreateGroupClick)));
			} else
			{
				return GetMenuItemsActions();
			}
		}


		private void CreateGroupClick()
		{
			Group group = Group.GetGroup(this);
			group.DeCheckAndRemoveAll();

			Node node = null;

			foreach (TreeNode treeNode in Nodes)
			{
				if (treeNode is Node)
				{
					node = (Node)treeNode;
					node.Checked = true;
				}
			}
			if (node != null) 
			{
				node.CreateGroup();
			}
		}

		private void CreateGroup()
		{
			Group group = Group.GetGroup(this);
			Node node = Parent as Node;
			if (node != null) 
			{
				Node groupNode = group.CreateNode();
				node.AddNodeChild(groupNode);
				group.DeCheckAndRemoveAll();
				groupNode.TreeView.SelectedNode = groupNode;
			} else
			{
				MessageBox.Show("Unable to add an Group for such a strange case");
			}
		}


		public KernelNode KernelNode
		{
			get { return kernelNode; }
		}

		public Action[] GetActions()
		{
			return Filter.FilterActions(kernelNode.GetNextActions());
		}

		public Action[] GetActionAfer(Action[] chain)
		{
			return Filter.FilterActions(kernelNode.GetNextActionsAfter(Filter.ToActionWrapper(chain)));
		}

		public void AddNodeChild(Node node)
		{
			Logger.Logger.LogMessage("Adding Node");
			
			this.Nodes.Add(node);
			if (this.TreeView != null) 
			{
				this.Expand();
				node.EnsureVisible();
			}
		}

		public ResultSet ResultSet
		{
			get
			{
				return KernelNode.Results;
			}
		}

		public void SelectionChanging()
		{
			Group group = Group.GetGroup(this);
			if (this.Checked)
			{
				group.RemoveNode(this);				
			} 
			else 
			{
				group.AddNode(this);
			}

			
		}

	}
}
