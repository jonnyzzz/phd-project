using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiActions.src.actionImpl.MSSegment.Create;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.MSSegment.Create
{
	/// <summary>
	/// Summary description for MSCreationAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMSCreationProcess), typeof(IMSCreationParameters))]
	public class MSCreationAction : Action
	{
	    public MSCreationAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
            int dim = ((IMSCreationProcess)Action).GetDimension(node.Results.ToResultSet);
            return new MSCreationControl(dim);
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CMSCreationProcessClass();
	    }
	}
}
