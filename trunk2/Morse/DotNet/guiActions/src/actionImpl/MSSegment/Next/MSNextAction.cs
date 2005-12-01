using System;
using EugenePetrenko.Gui2.Actions.ActionImpl.PointMethod;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MSSegment.Next
{
	/// <summary>
	/// Summary description for MSNextAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IMSMethodAction), typeof(IPointMethodParameters))]
	public class MSNextAction : PointMethodAction
	{
	    public MSNextAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override IAction CreateAction()
	    {
	        return new CMSMethodAction();
	    }
	}
}
