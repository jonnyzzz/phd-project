using gui.Logger;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	public class ComputationNodeSubdevidable : ComputationNodeAction
	{
		private volatile ISubdevidable node;
		private volatile ISubdevideParams param = null;

		public ComputationNodeSubdevidable(ISubdevidable node) : base()
		{
			this.node = node;
			param = null;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return
				new ComputationNodeMenuItem[]
					{
						ComputationNodeMenuFactory.SubdevideAction(new ComputationNodeMenuFactory.UniversalMenuItemClick(Subdevide))
					};
		}

		private void Subdevide()
		{
			lock (node)
			{
				Log.LogMessage(this, "Subdevide invoke");

				param = ComputationParametersFactory.ParamsSubdevide(null, node as IGraph, param);
				if (param != null)
				{
					node.Subdevide(param);
				}
			}
		}

	}
}