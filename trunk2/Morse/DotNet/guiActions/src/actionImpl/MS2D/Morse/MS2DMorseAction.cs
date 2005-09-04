using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Morse
{
	/// <summary>
	/// Summary description for MS2DMorseAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMS2DRomAction), typeof(IComputationParameters))]
	public class MS2DMorseAction : Action
	{
	    public MS2DMorseAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        return new MS2DMorseActionParameters(Core.Instance.KernelDocument.Function);
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CMS2DRomActionClass();
	    }
	}
}
