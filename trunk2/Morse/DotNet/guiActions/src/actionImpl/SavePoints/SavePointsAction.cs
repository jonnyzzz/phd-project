using System;
using guiActions.Actions;
using guiActions.KernelActions.SavePoints;
using guiActions.Parameters;
using guiActions.src.actionImpl.SavePoints;
using guiKernel2.ActionFactory;
using guiKernel2.Node;

namespace guiActions.actionImpl.SavePoints
{
	/// <summary>
	/// Summary description for SavePointsAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(SavePointsKernelAction), typeof(ISavePointsParameters))]
	public class SavePointsAction : Action
	{
		public SavePointsAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}


		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			return new SavePointsParameters();
		}

		protected override MorseKernel2.IAction CreateAction()
		{
			return new SavePointsKernelAction();
		}

		public override bool PublishResults
		{
			get { return false; }
		}
	}
}
