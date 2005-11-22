using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot2
{
	/// <summary>
	/// Summary description for IGnuPlotParameters.
	/// </summary>
	public interface IGnuPlotParameters : IParameters
	{
        bool NeedReduce { get; }
        bool NeedReduceInside { get; }
        bool NeedWriteFile { get; }
        bool NeedShow { get; }
        bool ShowBoxes { get; }        
	    int[] NewSize { get; }
        string FileName {get; }
	}
}
