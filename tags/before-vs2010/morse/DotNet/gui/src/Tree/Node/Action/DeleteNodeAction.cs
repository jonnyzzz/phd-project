using System;
using System.Windows.Forms;
using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for DeleteNodeAction.
	/// </summary>
	public class DeleteNodeAction : ComputationNodeAction
	{
		ComputationNode node;
		public DeleteNodeAction(ComputationNode node)
		{
			this.node = node;
			
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[] {
				ComputationNodeMenuFactory.getUniversalMenuItem(
					new ComputationNodeMenuFactory.UniversalMenuItemClick(Action), "Delete" )};
		}

		private void Action()
		{
			try 
			{
				node.Parent.Nodes.Remove(node);
			} catch (Exception)
			{
				MessageBox.Show("Unable to delete this node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new DeleteNodeActionFactory());
		}


		private class DeleteNodeActionFactory : IActionFactory
		{
			public bool Corresponds(ComputationNode node)
			{
				return true;
			}

			public ComputationNodeAction CreateAction(ComputationNode node)
			{
				return new DeleteNodeAction(node);
			}
		}
	}
}
