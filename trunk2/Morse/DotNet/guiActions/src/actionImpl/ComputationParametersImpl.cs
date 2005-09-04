using System;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl
{
	/// <summary>
	/// Summary description for ComputationParametersImpl.
	/// </summary>
	public class ComputationParametersImpl : IComputationParameters
	{
	    private Function function;

	    public ComputationParametersImpl(Function function)
	    {
	        this.function = function;
	    }

	    public IFunction GetFunction()
	    {
	        return function.IFunction;
	    }
	}
}
