using System;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Create
{
	/// <summary>
	/// Summary description for MS2DActionParameters.
	/// </summary>
	public class MS2DCreateActionParameters : ActionParameters
	{
	    
	    protected override IParameters LoadParameters(int factor)
	    {
	        return new MS2DCreateActionParametersImpl(factor);
	    }
	}
}
