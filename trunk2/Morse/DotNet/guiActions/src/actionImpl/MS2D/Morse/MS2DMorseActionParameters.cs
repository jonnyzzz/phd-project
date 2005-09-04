using System;
using guiActions.Parameters;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D.Morse
{
	/// <summary>
	/// Summary description for MS2DMorseActionParameters.
	/// </summary>
	public class MS2DMorseActionParameters : ParametersControl
	{
	    private Function function;

	    public MS2DMorseActionParameters(Function function)
	    {
	        this.function = function;
	    }

	    protected override IParameters SubmitDataInternal()
	    {
	        return new ComputationParametersImpl(function );
	    }

	    public override string BoxCaption
	    {
	        get { return "Morse Spectrum estimation"; }
	    }

	    public override bool NeedShowForm
	    {
	        get { return false; }
	    }
	}
}
