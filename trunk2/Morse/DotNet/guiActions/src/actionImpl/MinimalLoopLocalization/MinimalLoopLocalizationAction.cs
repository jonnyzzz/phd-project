using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.MinimalLoopLocalization
{
	/// <summary>
	/// Summary description for MinimalLoopLocalization.
	/// </summary>
	/// 
	[ActionMapping(typeof(IMinimalLoopLocalizationAction), typeof(IMinimalLoopLocalizationParameters))]
	public class MinimalLoopLocalizationAction : Action
	{
		public MinimalLoopLocalizationAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			int dimension = ((IMinimalLoopLocalizationAction)Action).GetDimension(node.Results.ToResultSet);
			return new MinimalLoopLocalizationParameters(dimension);
		}

		protected override MorseKernel2.IAction CreateAction()
		{
			return new CMinimalLoopLocalizationActionClass();
		}
	}
}
