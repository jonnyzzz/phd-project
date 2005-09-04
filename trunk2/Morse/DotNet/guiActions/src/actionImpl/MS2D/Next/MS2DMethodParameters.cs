using System;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Next
{
	/// <summary>
	/// Summary description for MS2DMethodParameters.
	/// </summary>
	public class MS2DMethodParameters : ActionParameters
	{
	    private Function function;

	    public MS2DMethodParameters(Function function)
	    {
	        this.function = function;
	    }

	    protected override IParameters LoadParameters(int factor)
	    {
	        return new MS2DMethodParametersImpl(factor, function);
	    }
	}
}
