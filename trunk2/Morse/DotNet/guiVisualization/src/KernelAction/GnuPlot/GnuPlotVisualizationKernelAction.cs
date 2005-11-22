using System.Diagnostics;
using System.IO;
using System.Xml;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.ExternalResource.FileResources;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot;

namespace EugenePetrenko.Gui2.Visualization.KernelAction
{
    /// <summary>
    /// Summary description for GnuPlotVisualization.
    /// </summary>
    public class GnuPlotVisualizationKernelAction : IAction
    {
        private IGnuPlotVisualizationKernelParameters parameters = null;

        public GnuPlotVisualizationKernelAction()
        {
        }

        public void SetActionParameters(IParameters parameters)
        {
            this.parameters = (IGnuPlotVisualizationKernelParameters) parameters;
        }

        public void SetProgressBarInfo(IProgressBarInfo pinfo)
        {
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

            int dimension = ((IGraphResult) resultSet.ToResults[0]).GetGraphInfo().GetDimension();

            XmlNode resource = ResourceManager.Instance.GetXmlResource("gnuplot").SelectSingleNode(parameters.Parameters.NeedShow ? "show" : "save");

            string xpath = string.Format("templates/template[@dimension=\"{0}\"]", dimension);
            GnuPlotScriptGen script = new GnuPlotScriptGen(new GnuPlotTemplate(resource.SelectSingleNode(xpath)), parameters.Parameters);

            foreach (IResult aResult in resultSet.ToResults)
            {
                IGraphResult result = (IGraphResult) aResult;
                string file = tempFiles.CreateFile();
                result.SaveText(file);
                script.AddFile(file, KernelNode.GetResultCaption(result, true));
            }

            RunGnuPlot(ResourceManager.Instance.TempFileAllocator.SaveToTempFile(script.Generate()), resource);

            return new EmptyResultSet();
        }

        private void ShowFromFileList(int dimension, string[] fileset)
        {
            XmlNode resource = ResourceManager.Instance.GetXmlResource("gnuplot").SelectSingleNode((parameters.Parameters == null) ? "show" : "save");

            string xpath = string.Format("templates/template[@dimension=\"{0}\"]", dimension);
            GnuPlotScriptGen script = new GnuPlotScriptGen(new GnuPlotTemplate(resource.SelectSingleNode(xpath)), parameters.Parameters);

            foreach (string file in fileset)
            {
                int len;
                using (TextReader tr = File.OpenText(file))
                {
                    len = tr.ReadToEnd().Split('\n').Length;
                }
                script.AddFile(file, file + " " + len.ToString());
            }
            RunGnuPlot(ResourceManager.Instance.TempFileAllocator.SaveToTempFile(script.Generate()), resource);
        }


        private void RunGnuPlot(string filescript, XmlNode resource)
        {
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.FileName = ResourceManager.Instance.AbsolutePathFileName(resource.SelectSingleNode("exe/text()").Value);
            pi.Arguments = string.Format(resource.SelectSingleNode("params/text()").Value, filescript);
            pi.ErrorDialog = true;

            Logger.LogMessage("Arguments: {0} ", pi.Arguments);

            Process.Start(pi);
        }


        public static void ExportFile(string[] files, string output, string title)
        {
            //GnuPlotParameters pars = new GnuPlotParameters(output, title);
            GnuPlotParametersImpl pars = new GnuPlotParametersImpl(output, 1000, 1000, true, true, false, false);
            GnuPlotVisualizationKernelAction action = new GnuPlotVisualizationKernelAction();
            action.SetActionParameters(pars);
            action.ShowFromFileList(2, files);
        }
    }
}