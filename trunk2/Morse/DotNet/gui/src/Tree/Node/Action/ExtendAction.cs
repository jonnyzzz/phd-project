using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for Extend.
	/// </summary>
	public class ExtendAction : ComputationNodeAction
	{
		private IExtendable node;

		public ExtendAction(IExtendable node)
		{
			this.node = node;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.getUniversalMenuItem(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(Extend),
						"Projective Bundle")
				};
		}

		private void Extend()
		{
			node.Extend();
		}

		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new ExtendActionFactory());
		}


		private class ExtendActionFactory : IActionFactory
		{
			public bool Corresponds(ComputationNode node)
			{
				return node.Node is IExtendable;
			}

			public ComputationNodeAction CreateAction(ComputationNode node)
			{
				return new ExtendAction((IExtendable) node.Node);
			}
		}

	}
}