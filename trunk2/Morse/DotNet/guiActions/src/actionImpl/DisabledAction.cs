using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.actionImpl
{
	/// <summary>
	/// Summary description for DisabledAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IDisabledActionInterface), typeof(IParameters))]
	public class DisabledAction : Action, IDisabledAction, IDisabledActionInterface
	{
	    public string comment;

	    public DisabledAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    public void SetComment(string comment)
	    {
            this.comment = comment;
	        
	    }

	    public string Comment
	    {
	        get { return comment; }
	    }

	    public string Caption
	    {
	        get { return base.ActionName; }
	    }

	    public void SetActionParameters(MorseKernel2.IParameters parameters)
	    {	        
	    }

	    public void SetProgressBarInfo(MorseKernel2.IProgressBarInfo pinfo)
	    {	        
	    }

	    public bool CanDo(MorseKernel2.IResultSet result)
	    {
            return false;
	    }

	    public MorseKernel2.IResultSet Do(MorseKernel2.IResultSet input)
	    {
            throw new ArgumentException("Unable to perform action for Disabled Elemet");
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        throw new ArgumentException("Unable to perform action for Disabled Elemet");
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return this;
	    }
	}
}
