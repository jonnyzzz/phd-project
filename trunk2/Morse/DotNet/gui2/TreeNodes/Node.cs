using System;
using System.Windows.Forms;
using guiControls.TreeControl;
using guiKernel2.src.ActionFactory;
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
			return MenuItemFactory.CreateMenuItems(kernelNode.NextActions);
		}
	}
}
