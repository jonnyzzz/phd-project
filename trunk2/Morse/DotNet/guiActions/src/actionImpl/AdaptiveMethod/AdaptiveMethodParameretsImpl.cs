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
	    private double[] precision;
	    private Function function;
	    private int upperLimit;

	    public AdaptiveMethodParameretsImpl(int[] factor, double[] precision, int upperLimit, Function function)
	    {
	        this.factor = factor;
	        this.precision = precision;
	        this.upperLimit = upperLimit;
	        this.function = function;
	    }

	    public int GetFactor(int index)
	    {
	        return factor[index];
	    }

	    public double GetPrecision(int index)
	    {
	        return precision[index];
	    }

	    public int GetUpperLimit()
	    {
	        return upperLimit;
	    }

	    public IFunction GetFunction()
	    {
	        return function.IFunction;
	    }

	}
}
