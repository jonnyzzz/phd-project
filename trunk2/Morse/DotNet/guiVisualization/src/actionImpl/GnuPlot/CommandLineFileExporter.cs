using System;
using guiVisualization.KernelAction;

namespace guiVisualization.actionImpl.GnuPlot
{
	/// <summary>
	/// Summary description for CommandLineFileExporter.
	/// </summary>
	public class CommandLineFileExporter
	{
		public static void ExportFiles(string[] files, string output, string title)
		{
			GnuPlotVisualizationKernelAction.ExportFile(files, output, title);
		}
	}
}
