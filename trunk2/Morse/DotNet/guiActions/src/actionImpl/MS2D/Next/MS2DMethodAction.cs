using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Document;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Next
{
	/// <summary>
	/// Summary description for MS2DMethodAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMS2DProcessAction), typeof(IMS2DProcessParameters))]
	public class MS2DMethodAction : Action
	{
	    public MS2DMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        return new MS2DMethodParameters(Core.Instance.KernelDocument.Function);
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CMS2DProcessActionClass();
	    }
	}
}
