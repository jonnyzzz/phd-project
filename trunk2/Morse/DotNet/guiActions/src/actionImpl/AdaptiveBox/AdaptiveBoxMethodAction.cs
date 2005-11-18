using System;
using System.Collections;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.ActionFactory;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.AdaptiveBox
{
	/// <summary>
	/// Summary description for AdaptiveBoxMethodAction.
	/// </summary>
	/// 
    [ActionMapping(typeof(IAdaptiveBoxMethod), typeof(IAdaptiveBoxParameters))]
	public class AdaptiveBoxMethodAction : Action
	{
	    public AdaptiveBoxMethodAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
	    {
	    }

	    protected override ParametersControl GetParametersControlInternal(KernelNode node)
	    {	       
            IAdaptiveBoxMethod action = (IAdaptiveBoxMethod)Action;

	        MorseKernel2.IResultSet set = node.Results.ToResultSet;
	        int dim = action.GetDimensionFromParameters(set);
	        double[] data = new double[dim];
            for (int i=0; i<dim; i++)
            {
                data[i] = action.GetRecomendedPrecision(set,i);
            }
	        return new AdaptiveBoxParameters(Core.Instance.KernelDocument.Function, dim, data);
	    }

	    protected override MorseKernel2.IAction CreateAction()
	    {
	        return new CAdaptiveBoxMethodClass();
	    }
	}
}
