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
						"Extend")
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
			public bool Corresponds(IKernelNode node)
			{
				return node is IExtendable;
			}

			public ComputationNodeAction CreateAction(IKernelNode node)
			{
				return new ExtendAction((IExtendable) node);
			}
		}

	}
}