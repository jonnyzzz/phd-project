using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.actionImpl.PointMethod
{
	/// <summary>
	/// Summary description for PointMethodAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IPointMethodAction), typeof(IPointMethodParameters))]
	public class PointMethodAction : Action
	{
		public PointMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			int dim = ((IPointMethodAction)Action).GetDimensionForParameters(node.Results.ToResultSet);
			return new PointMethodParameters(dim, Core.Instance.KernelDocument.Function);
		}

		protected override IAction CreateAction()
		{
			return new CPointMethodActionClass();
		}
	}
}
