using System;
using gui.Attributes;
using gui.Logger;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	public class SubdevideAction : ComputationNodeAction
	{
		private ISubdevidable node;

		public SubdevideAction(ISubdevidable node) : base()
		{
			this.node = node;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return
				new ComputationNodeMenuItem[]
					{
						ComputationNodeMenuFactory.getUniversalMenuItem(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(Subdevide),
						"Subdevide Linear Method")
					};
		}

		private void Subdevide()
		{
			ISubdevideParams param = ComputationParametersFactory.ParamsSubdevide(
					null, 
					node as IGraph, 
					null
				);
			if (param != null)
			{
				node.Subdevide(param);
			}
		}

		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new SubdevideActionFactory());
		}

		private class SubdevideActionFactory : IActionFactory
		{
			public bool Corresponds(ComputationNode node)
			{				
				return node.Node is ISubdevidable;
			}

			public ComputationNodeAction CreateAction(ComputationNode node)
			{
				return new SubdevideAction((ISubdevidable)node.Node);
			}
		}
	}
}