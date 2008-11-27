using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for ComputationNodeSubdevidablePoint.
	/// </summary>
	public class ComputationNodeSubdevidablePoint : ComputationNodeAction
	{
		private ISubdevidablePoint node;
		private ISubdevidePointParams param = null;

		public ComputationNodeSubdevidablePoint(ISubdevidablePoint node) : base()
		{
			this.node = node;
			param = null;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return
				new ComputationNodeMenuItem[]
					{
						ComputationNodeMenuFactory.SubdevidePointAction(new ComputationNodeMenuFactory.UniversalMenuItemClick(SubdevidePoint))
					};
		}

		private void SubdevidePoint()
		{
			param = ComputationParametersFactory.ParamsSubdevidePoint(null, node as IGraph, param);
			if (param != null)
			{
				node.SubdevidePoint(param);
			}
		}

	}
}