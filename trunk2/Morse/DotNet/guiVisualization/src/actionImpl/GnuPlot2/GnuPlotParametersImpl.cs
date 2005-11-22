using System;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Visualization.KernelAction;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2
{
	/// <summary>
	/// Summary description for GnuPlotParametersImpl.
	/// </summary>
	public class GnuPlotParametersImpl : IGnuPlotScriptGenParameters, IGnuPlotVisualizationKernelParameters
	{
	    private string fileName;
	    private int width;
	    private int height;
	    private bool showHistory;
	    private bool needFile;
	    private bool needShow;
	    private bool showBoxes;

	    public GnuPlotParametersImpl(string fileName, int width, int height, bool showHistory, bool needFile, bool needShow, bool showBoxes)
	    {
	        this.fileName = fileName;
	        this.width = width;
	        this.height = height;
	        this.showHistory = showHistory;
	        this.needFile = needFile;
	        this.needShow = needShow;
	        this.showBoxes = showBoxes;
	    }

	    public IGnuPlotScriptGenParameters Parameters
	    {
	        get { return this; }
	    }

	    public string FileName
	    {
	        get { return fileName; }
	    }

        public string PlotTitle
        {
            get
            {
                if (Core.Instance.KernelDocument != null && Core.Instance.KernelDocument.Title != null)
                {
                    return Core.Instance.KernelDocument.Title;
                }
                else return "";
            }
        }

	    public int Width
	    {
	        get { return width; }
	    }

	    public int Height
	    {
	        get { return height; }
	    }

	    public bool ShowHistory
	    {
	        get { return showHistory; }
	    }

	    public bool NeedWriteFile
	    {
	        get { return needFile; }
	    }

	    public bool NeedShow
	    {
	        get { return needShow; }
	    }

	    public bool ShowBoxes
	    {
	        get { return showBoxes; }
	    }
    }
}
