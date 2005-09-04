using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Create
{
	/// <summary>
	/// Summary description for MS2DCreateAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMS2DCreationAction), typeof(IMS2DCreationParameters))]
	public class MS2DCreateAction : Action
	{
	    public MS2DCreateAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        return new MS2DCreateActionParameters();
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CMS2DCreationActionClass();
	    }
	}
}
