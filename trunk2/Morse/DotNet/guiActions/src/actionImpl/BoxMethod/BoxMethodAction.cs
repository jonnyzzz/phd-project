using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.ActionImpl
{
	/// <summary>
	/// Summary description for BoxMethodAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IBoxMethodAction), typeof(IBoxMethodParameters))]
	public class BoxMethodAction : Action
	{
		public BoxMethodAction(bool isChainLeaf) : base(isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{			
			int dim = ((IBoxMethodAction)Action).GetDimensionForParameters(node.Results.ToResultSet);
			return new BoxMethodParameters(dim, Core.Instance.KernelDocument.Function);
		}

		protected override IAction CreateAction()
		{
			return new CBoxMethodActionClass();
		}

		public override string ActionName
		{
			get { return "Linear Method"; }
		}
	}
}
