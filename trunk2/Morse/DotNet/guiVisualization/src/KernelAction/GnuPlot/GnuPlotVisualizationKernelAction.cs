using System.Collections;
using System.Diagnostics;
using System.Xml;
using gui.Resource;
using guiExternalResource.Core;
using guiExternalResource.src.FileResources;
using guiKernel2.Container;
using guiKernel2.Node;
using guiVisualization.KernelAction.GnuPlot;
using MorseKernel2;

namespace guiVisualization.KernelAction
{
	/// <summary>
	/// Summary description for GnuPlotVisualization.
	/// </summary>
	public class GnuPlotVisualizationKernelAction : IAction
	{
		private IGnuPlotVisualizationKernelParameters parameters = null;
		private IProgressBarInfo progressBarInfo = null;

		public GnuPlotVisualizationKernelAction()
		{
		}

		public void SetActionParameters(IParameters parameters)
		{
			this.parameters = (IGnuPlotVisualizationKernelParameters)parameters;
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
			TempFileAllocator tempFiles = Core.Instance.ResourceManager.TempFileAllocator;
			ResultSet resultSet = ResultSet.FromResultSet(input);

			int dimension = ((IGraphResult)resultSet.ToResults[0]).GetGraphInfo().GetDimension();

			XmlNode resource = ResourceManager.Instance.GetXmlResource("gnuplot");

			string xpath = string.Format("templates/template[@dimension=\"{0}\"]", dimension);
			GnuPlotScriptGen script = new GnuPlotScriptGen(new GnuPlotTemplate(resource.SelectSingleNode(xpath)));

			foreach (IResult aResult in resultSet.ToResults)
			{
				IGraphResult result = (IGraphResult)aResult;
				string file = tempFiles.CreateFile();
				result.SaveText(file);
				script.addFile(file);
			}

			RunGnuPlot(ResourceManager.Instance.TempFileAllocator.SaveToTempFile(script.ToString()), resource);

			return new EmptyResultSet();
		}


		private void RunGnuPlot(string filescript, XmlNode resource)
		{
			ProcessStartInfo pi = new ProcessStartInfo();
			pi.FileName = ResourceManager.Instance.AbsolutePathFileName( resource.SelectSingleNode("exe/text()").Value );
			pi.Arguments = string.Format(resource.SelectSingleNode("params/text()").Value, filescript);
			pi.ErrorDialog = true;

			Logger.Logger.LogMessage("Arguments: {0} ", pi.Arguments);

			Process.Start(pi);
		}

	}
}
