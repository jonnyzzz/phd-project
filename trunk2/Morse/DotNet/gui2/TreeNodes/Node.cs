using System;
using System.Windows.Forms;
using guiActions.action;
using guiActions.src.filter;
using guiControls.TreeControl;
using guiKernel2.src.Node;

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
			get { return string.Format("Sample Node [ {0} ]", kernelNode.Caption); }
		}

		protected override MenuItem[] GetMenuItems()
		{
			return MenuItemFactory.CreateMenuItems(this, Filter.FilterActions(kernelNode.GetNextActions()));
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

	}
}
