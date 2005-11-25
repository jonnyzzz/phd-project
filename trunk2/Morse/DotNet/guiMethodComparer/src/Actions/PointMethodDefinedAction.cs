using System;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
	/// <summary>
	/// Summary description for PointMethodDefinedAction.
	/// </summary>
	public class PointMethodDefinedAction : PointMethodDefinedActionBase
	{
	    public PointMethodDefinedAction(IMethodParameters methodParameters) : base(methodParameters)
	    {
	    }

	    public override bool UseOffsets()
	    {
	        return false;
	    }

	    public override void GetOffset(int index, out double offset1, out double offset2)
	    {
	        offset1 = 0;
            offset2 = 0;
	    }

	    public override string Name
	    {
	        get { return "Point method"; }
	    }
	}
}
