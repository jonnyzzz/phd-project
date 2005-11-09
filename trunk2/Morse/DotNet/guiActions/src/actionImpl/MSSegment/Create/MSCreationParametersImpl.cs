using System;
using MorseKernel2;

namespace guiActions.actionImpl.MSSegment.Create
{
	/// <summary>
	/// Summary description for MSCreateParameters.
	/// </summary>
	public class MSCreationParametersImpl : IMSCreationParameters
	{
	    private int[] param;

	    public MSCreationParametersImpl(int[] param)
	    {
	        this.param = param;
	    }

	    public int GetFactor(int index)
	    {
	        return param[index];
	    }
	}
}
