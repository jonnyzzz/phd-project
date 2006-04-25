using EugenePetrenko.Gui2.Visualization.KernelAction;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot
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