using System;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveMethod
{
	/// <summary>
	/// Summary description for MSAdaptiveAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IMSAdaptiveMethod), typeof(IAdaptiveMethodParameters))]
	public class MSAdaptiveAction : AdaptiveMethodAction
	{
		public MSAdaptiveAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override IAction CreateAction()
		{
			return new CMSAdaptiveActionClass();
		}

	}
}
