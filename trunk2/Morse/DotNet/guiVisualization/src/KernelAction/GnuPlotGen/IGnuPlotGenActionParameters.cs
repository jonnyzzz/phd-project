using System;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlotGen
{
	/// <summary>
	/// Summary description for GnuPlotGenActionParameters.
	/// </summary>
	public interface IGnuPlotGenActionParameters : IParameters
	{
		string Title{ get; }

        int Width{ get; }
        int Height { get; }
        
        bool ShowHistory { get; }

        string GlobalPath{ get; }

        string GnuPlotFile{ get; }        
        string PointFileFormat { get; }
	    string OutputFile { get; }
        string ParametersFile { get; }

		string ShowStyle(IResult result);
	}
}
