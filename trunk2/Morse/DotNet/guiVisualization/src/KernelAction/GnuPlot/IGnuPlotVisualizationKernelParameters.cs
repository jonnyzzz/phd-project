using System;
using guiActions.Parameters;
using MorseKernel2;
using guiVisualization.KernelAction.GnuPlot;

namespace guiVisualization.KernelAction
{
	/// <summary>
	/// Summary description for GnuPlotVisualizationKernelParameters.
	/// </summary>
	public interface IGnuPlotVisualizationKernelParameters : IParameters
	{
		/// <summary>
		/// Returns null if we need to show
		/// </summary>
		GnuPlotScriptGenParameters Parameters { get; }

		string Title { get; }
		
	}
}
