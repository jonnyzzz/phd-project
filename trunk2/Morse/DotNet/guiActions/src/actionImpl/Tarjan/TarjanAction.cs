using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.Tarjan
{
	/// <summary>
	/// Summary description for TarjanAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(ITarjanAction), typeof(ITarjanParameters))]
	public class TarjanAction : Action
	{
		public TarjanAction(bool isChainLeaf) : base(isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			return new TarjanParameters();
		}

		protected override IAction CreateAction()
		{
			return new CTarjanActionClass();
		}

		public override string ActionName
		{
			get { return "Strong Components Localization"; }
		}
	}
}
