using MorseKernelATL;

namespace gui
{	
	public class ComputationNodeSubdevidable : ComputationNodeAction
	{
		ISubdevidable node;
		ISubdevideParams param = null;
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
						ComputationNodeMenuFactory.SubdevideAction(new ComputationNodeMenuFactory.Subdevide(Subdevide))
				};
		}

		private void Subdevide()
		{
			param = ComputationParametersFactory.ParamsSubdevide(null, node as IGraph, param);
			if (param != null) 
			{
				node.Subdevide(param);
			}
		}

	}
}
