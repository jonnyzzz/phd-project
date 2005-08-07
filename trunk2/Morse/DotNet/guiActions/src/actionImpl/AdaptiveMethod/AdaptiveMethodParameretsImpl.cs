using System;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.src.actionImpl.AdaptiveMethod
{
	/// <summary>
	/// Summary description for AdaptiveMethodParameretsImpl.
	/// </summary>
	public class AdaptiveMethodParameretsImpl : IAdaptiveMethodParameters 
	{
	    private int[] factor;
	    private double precision;
	    private Function function;

	    public AdaptiveMethodParameretsImpl(int[] factor, double precision, Function function)
	    {
	        this.factor = factor;
	        this.precision = precision;
	        this.function = function;
	    }

	    public int GetFactor(int index)
	    {
	        return factor[index];
	    }

	    public double GetPrecision()
	    {
	        return precision;
	    }

	    public IFunction GetFunction()
	    {
	        return function.IFunction;
	    }

	}
}
