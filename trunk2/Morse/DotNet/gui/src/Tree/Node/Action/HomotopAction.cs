using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for HomotopAction.
	/// </summary>
	public class HomotopAction : ComputationNodeAction
	{
		private IHomotopFind node;
		private int dimenstion;

		public HomotopAction(IHomotopFind node, int dimenstion)
		{
			this.node = node;
			this.dimenstion = dimenstion;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[]
				{
					new ComputationNodeMenuFactory.UniversalComputationMenuItem(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(Homotop),
						"!Experimental! Homotop Paths")
				};
		}

		private void Homotop()
		{
			IHomotopParams param = ComputationParametersFactory.getHomotopParams(null, dimenstion);
			if (param != null)
			{
				node.Homotop(param);
			}
		}


		[InitializeOnRun(true)]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new HomotopActionFactory());
		}

		private class HomotopActionFactory : IActionFactory
		{
			public bool Corresponds(IKernelNode node)
			{
				return node is IHomotopFind && node is IGraph;
			}

			public ComputationNodeAction CreateAction(IKernelNode node)
			{
				return new HomotopAction((IHomotopFind) node, ((IGraph) node).graphDimension());
			}
		}
	}
}