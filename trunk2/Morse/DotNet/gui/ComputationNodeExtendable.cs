using System;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeExtendable.
	/// </summary>
	public class ComputationNodeExtendable : ComputationNodeAction
	{		
		private IExtendable node;
		private IExtendableParams param = null;
		public ComputationNodeExtendable(IExtendable node) : base()
		{
			this.node = node;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[] {
					 ComputationNodeMenuFactory.ExtendAction(new ComputationNodeMenuFactory.Extend(Extend))
				};
		}

		private void Extend() 
		{ 
			param = ComputationParametersFactory.ParamsExtend(null, node , param);
			if (param != null) 
			{
				Console.Out.WriteLine("C# OK");
				node.Extend(param);
			}
		}
	}
}
