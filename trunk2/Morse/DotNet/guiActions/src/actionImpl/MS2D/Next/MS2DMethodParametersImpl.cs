using System;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Next
{
	/// <summary>
	/// Summary description for MS2DMethodParametersImpl.
	/// </summary>
	public class MS2DMethodParametersImpl : IMS2DProcessParameters
	{
	    private int factor;
	    private Function function;

	    public MS2DMethodParametersImpl(int factor, Function function)
	    {
	        this.factor = factor;
	        this.function = function;
	    }

	    public IFunction GetFunction()
	    {
	        return function.IFunction;
	    }

	    public int GetFactor()
	    {
	        return factor;
	    }

	    
	}
}
