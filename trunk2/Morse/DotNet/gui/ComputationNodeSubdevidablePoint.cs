using System;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeSubdevidablePoint.
	/// </summary>
	public class ComputationNodeSubdevidablePoint : ComputationNodeAction
	{
		ISubdevidablePoint node;
		ISubdevidePointParams param = null;
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
					ComputationNodeMenuFactory.SubdevidePointAction(new ComputationNodeMenuFactory.SubdevidePoint(SubdevidePoint))
				};
		}

		private void SubdevidePoint()
		{
			param = ComputationParametersFactory.ParamsSubdevidePoint(null, node as IGraph, param);
			if (param != null ) 
			{
				node.SubdevidePoint(param);
			}
		}

	}
}

