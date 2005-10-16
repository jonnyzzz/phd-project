using System;

namespace guiVisualization.KernelAction.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotScriptGenParameters.
	/// </summary>
	public interface GnuPlotScriptGenParameters
	{
		string FileName { get; }

		int Width { get; }
		int Height { get; }	  
	}
}