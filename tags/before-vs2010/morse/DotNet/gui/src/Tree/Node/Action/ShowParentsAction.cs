using System;
using gui.Attributes;
using gui.Forms;
using gui.Logger;
using gui.Tree.Node.Action;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for ShowParentsAction.
	/// </summary>
	public class ShowParentsAction : ComputationNodeAction
	{
		IGroupNode node;
		public ShowParentsAction(IGroupNode node)
		{			
			this.node = node;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[] {
				ComputationNodeMenuFactory.getUniversalMenuItem(
					new ComputationNodeMenuFactory.UniversalMenuItemClick(Action),
						"Select Parent Nodes"),
				ComputationNodeMenuFactory.getUniversalMenuItem(
					new ComputationNodeMenuFactory.UniversalMenuItemClick(Deselect),
						"Deselect Checked Nodes")};	
		}

		private void Deselect()
		{
			ComputationNodePlural.getCurrentGroup().dehighlightChildrens();
		}

		private void Action()
		{
			ComputationForm form = Runner.ComputationForm;
			ComputationNode.ClearGroup();

			int length = node.nodeCount();
			for (int i=0; i<length; i++)
			{
				ComputationNode anode = form.findNodeByKernelNode(node.getNode(i));
				if (anode == null) Log.LogMessage(this, "Node not found!");

				anode.Checked = true;				
			}
		}

		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new ShowParentActionFactory());
		}

		private class ShowParentActionFactory : IActionFactory
		{
			public bool Corresponds(ComputationNode node)
			{
				return node.Node is IGroupNode;
			}

			public ComputationNodeAction CreateAction(ComputationNode node)
			{
				return new ShowParentsAction((IGroupNode)node.Node);
			}
		}

	}
}
