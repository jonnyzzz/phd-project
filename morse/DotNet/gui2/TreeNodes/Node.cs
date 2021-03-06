using System;
using System.Windows.Forms;
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
		protected override MenuItem[] GetMenuItems()
		{
			if (cachedMenuItems == null) 
			{
				cachedMenuItems = MenuItemFactory.CreateMenuItems(this, Filter.FilterActions(kernelNode.GetNextActions()));
			}
			return cachedMenuItems;
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

		public void AddChild(Node node)
		{
			Logger.Logger.LogMessage("Adding Node");
			
			this.Nodes.Add(node);
			this.Expand();
		}

		public ResultSet ResultSet
		{
			get
			{
				return KernelNode.Results;
			}
		}

	}
}
