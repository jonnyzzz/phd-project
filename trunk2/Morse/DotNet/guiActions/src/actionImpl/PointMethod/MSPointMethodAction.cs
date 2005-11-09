using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiActions.src.actionImpl.PointMethod;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.PointMethod
{
	/// <summary>
	/// Summary description for MSPointMethodAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMSMethodAction), typeof(IPointMethodParameters))]
	public class MSPointMethodAction : PointMethodAction
	{
	    public MSPointMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {            
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CMSMethodActionClass();
	    }
	}
}
