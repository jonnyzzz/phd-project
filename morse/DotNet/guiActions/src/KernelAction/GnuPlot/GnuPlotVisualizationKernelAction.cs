using System;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.src.KernelAction
{
	/// <summary>
	/// Summary description for GnuPlotVisualization.
	/// </summary>
	public class GnuPlotVisualizationKernelAction : IAction
	{
		private GnuPlotVisualizationKernelParameters parameters = null;
		private IProgressBarInfo progressBarInfo = null;

		public GnuPlotVisualizationKernelAction()
		{
		}

		public void SetActionParameters(IParameters parameters)
		{
			this.parameters = (GnuPlotVisualizationKernelParameters)parameters;
		}

		public void SetProgressBarInfo(IProgressBarInfo pinfo)
		{
			this.progressBarInfo = pinfo;
		}

		public bool CanDo(IResultSet aResultSet)
		{
			ResultSet resultSet = ResultSet.FromResultSet(aResultSet);
			foreach (IResult result in resultSet.ToResults)
			{
				if (!(result is IGraphResult)) return false;
			}
			return true;
		}

		public IResultSet Do(IResultSet input)
		{
			throw new NotImplementedException();
		}
	}
}
