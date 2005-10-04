using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;


namespace guiActions.actionImpl.Projector
{
	/// <summary>
	/// Summary description for ProjectorAction.
	/// </summary>
	/// 
	[ActionMapping(typeof(IProjectAction), typeof(IProjectActionParameters))]
	public class ProjectorAction : Action
	{
		public ProjectorAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
		{
		}

		protected override ParametersControl GetParametersControlInternal(KernelNode node)
		{
			int dim = ((IProjectAction)Action).GetDimention(node.Results.ToResultSet);
			return new ProjectorParameters(dim);
		}

		protected override IAction CreateAction()
		{
			return new CProjectActionClass();
		}
	}
}
