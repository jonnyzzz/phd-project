using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot;

namespace EugenePetrenko.Gui2.Visualization.KernelAction
{
    /// <summary>
    /// Summary description for GnuPlotVisualizationKernelParameters.
    /// </summary>
    public interface IGnuPlotVisualizationKernelParameters : IParameters
    {        
        IGnuPlotScriptGenParameters Parameters { get; }
    }
}