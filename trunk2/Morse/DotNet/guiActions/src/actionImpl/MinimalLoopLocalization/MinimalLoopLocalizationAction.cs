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

		private MinimalLoopLocalizationParameters parameters = null;
		public void FakeControl(MinimalLoopLocalizationParameters control)
		{
			SetFakeControl(control);
			parameters = control;
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			if (parameters == null) 
			{
				int dimension = ((IMinimalLoopLocalizationAction)Action).GetDimension(node.Results.ToResultSet);
				return new MinimalLoopLocalizationParameters(dimension);
			} else
			{
				return parameters;
			}
		}

		protected override MorseKernel2.IAction CreateAction()
		{
			return new CMinimalLoopLocalizationActionClass();
		}
	}
}
