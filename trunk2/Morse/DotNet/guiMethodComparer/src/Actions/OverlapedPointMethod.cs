using System;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
	/// <summary>
	/// Summary description for OverlapedPointMethod.
	/// </summary>
	public class OverlapedPointMethod : PointMethodDefinedActionBase
	{
	    public OverlapedPointMethod(IMethodParameters methodParameters) : base(methodParameters)
	    {
	    }

	    public override bool UseOffsets()
	    {
	        return true;
	    }

	    public override void GetOffset(int index, out double offset1, out double offset2)
	    {
	        offset1 = GlobalParameters.PointMethodOffset(index);
	        offset2 = GlobalParameters.PointMethodOffset(index);
	    }

	    public override string Name
	    {
	        get { return "Overlaped method"; }
	    }
	}
}
