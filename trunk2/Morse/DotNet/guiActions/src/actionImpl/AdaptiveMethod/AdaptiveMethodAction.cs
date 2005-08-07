using System;
using guiActions.Actions;
using guiActions.Parameters;
using guiActions.src.actionImpl.AdaptiveMethod;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.ActionImpl.AdaptiveMethod
{
	/// <summary>
	/// Summary description for AdaptiveMethodAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IAdaptiveMethodAction), typeof(IAdaptiveMethodParameters))]
	public class AdaptiveMethodAction : Action
	{
	    public AdaptiveMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {
	        IAdaptiveMethodAction action = (IAdaptiveMethodAction)Action;
	        int dim = action.GetDimension(node.Results.ToResultSet);
            double precision = action.GetRecomendedPrecision(node.Results.ToResultSet);
            return new AdaptiveMethodParameters(dim, Core.Instance.KernelDocument.Function, precision );
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new MorseKernel2.CAdaptiveMethodActionClass();
	    }
	}
}
