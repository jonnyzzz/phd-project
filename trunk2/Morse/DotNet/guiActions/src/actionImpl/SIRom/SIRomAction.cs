using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.SIRom
{
	/// <summary>
	/// Summary description for SIRomAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(ISIRomAction),typeof(ISIRomActionParameters))]
	public class SIRomAction : Action
	{
		public SIRomAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			return new SIRomActionParameters();
		}

		protected override MorseKernel2.IAction CreateAction()
		{
			return new CSIRomActionClass();
		}
	}
}
