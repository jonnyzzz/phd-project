using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.HomotopAction
{
	/// <summary>
	/// Summary description for HomotopAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IIsolatedSetAction), typeof(IIsolatedSetParameters))]
	public class HomotopAction : Action
	{
		public HomotopAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override IAction CreateAction()
		{
			return new CIsolatedSetActionClass();
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			return new HomotopParameters(node);
		}
	}
}
