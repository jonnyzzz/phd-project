using System;
using guiKernel2.Actions;
using guiKernel2.src.Node;
using MorseKernel2;

namespace guiKernel2.src.ActionFactory
{
	/// <summary>
	/// Summary description for NextActionFactory.
	/// </summary>
	public class NextActionFactory
	{
		public static NextActionFactory Instance { 
			get
			{
				return Container.Container.Instance.NextActionFactory;
			}
		}

		public ActionWrapper[] NextAction(ActionWrapper action, params ActionWrapper[] beforeActions)
		{
			return new ActionWrapper[0];
		}

		public ActionWrapper[] NextAction(KernelNode node)
		{
			return new ActionWrapper[] {  };
		}
	
	}
}
