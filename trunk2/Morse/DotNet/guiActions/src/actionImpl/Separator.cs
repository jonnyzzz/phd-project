using System;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
	/// <summary>
	/// Summary description for SeparatorMenuItem.
	/// </summary>
	/// 
    [ActionMapping(typeof (ISeparatorAction), typeof (IParameters))]
	public class Separator : Action, ISeparator, ISeparatorAction
	{
	    public Separator(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }	    

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        throw new NotImplementedException();
	    }

	    protected override IAction CreateAction()
	    {
	        return this;
	    }

	    public void SetActionParameters(IParameters parameters)    
	    {
	        throw new NotImplementedException();
	    }

	    public void SetProgressBarInfo(IProgressBarInfo pinfo)
	    {
	        throw new NotImplementedException();
	    }

	    public bool CanDo(IResultSet result)
	    {
	        return false;
	    }

	    public IResultSet Do(IResultSet input)
	    {
	        throw new NotImplementedException();
	    }
	}
}
