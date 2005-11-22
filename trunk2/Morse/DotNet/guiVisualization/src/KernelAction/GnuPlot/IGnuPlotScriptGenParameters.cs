namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot
{
    /// <summary>
    /// Summary description for GnuPlotScriptGenParameters.
    /// </summary>
    public interface IGnuPlotScriptGenParameters
    {
        bool NeedWriteFile { get; }
        bool NeedShow { get; }

        string FileName { get; }
        string PlotTitle{ get; }

        int Width { get; }
        int Height { get; }

        bool ShowHistory { get; }          
        bool ShowBoxes { get; }                
    }
}