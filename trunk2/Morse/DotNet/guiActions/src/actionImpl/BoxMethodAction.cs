using System;
using guiActions.action;
using guiActions.parameters;
using guiKernel2.src.ActionFactory;
using MorseKernel2;

namespace guiActions.src.actionImpl
{
	/// <summary>
	/// Summary description for BoxMethodAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IBoxMethodAction), typeof(IBoxMethodParameters))]
	public class BoxMethodAction : Action
	{
		public BoxMethodAction(IAction action, bool isChainLeaf) : base(action, isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal()
		{
			throw new NotImplementedException();
		}
	}
}
