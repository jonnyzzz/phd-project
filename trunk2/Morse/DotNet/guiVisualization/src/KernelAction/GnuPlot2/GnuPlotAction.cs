using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.KernelAction;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot2;

namespace EugenePetrenko.Gui2.Visualization.src.KernelAction.GnuPlot2
{
	/// <summary>
	/// Summary description for GnuPlotAction.
	/// </summary>
	public class GnuPlotAction : IAction
	{
        private IGnuPlotParameters parameters;
	    public IProgressBarInfo progressBarInfo;

	    public void SetActionParameters(IParameters parameters)
	    {
	        this.parameters = (IGnuPlotParameters) parameters;    
	    }

	    public void SetProgressBarInfo(IProgressBarInfo pinfo)
	    {
	        this.progressBarInfo = pinfo;
	    }

	    public bool CanDo(IResultSet result)
	    {	        
	        foreach (IResult set in ResultSet.FromResultSet(result))
	        {
	            if (!(set is IGraphResult)) return false;
	        }
            return true;
	    }

	    public IResultSet Do(IResultSet input)
	    {
            return new EmptyResultSet();
	    }
	}
}
