using System.Diagnostics;
using System.IO;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.ExternalResource.FileResources;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;
using EugenePetrenko.Gui2.MorseKernel2;
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
            GnuPlotTemplate template = GnuPlotTemplate.Create( dimension, !parameters.Parameters.NeedShow );

            GnuPlotScriptGen script = new GnuPlotScriptGen(template, parameters.Parameters);

            foreach (IResult aResult in resultSet.ToResults)
            {
                IGraphResult result = (IGraphResult) aResult;
                string file = tempFiles.CreateFile();
                result.SaveText(file);
                script.AddFile(file, KernelNode.GetResultCaption(result, true), parameters.Parameters.ShowStyle(aResult));
            }

            RunGnuPlot(ResourceManager.Instance.TempFileAllocator.SaveToTempFile(script.Generate()), template);

            return new EmptyResultSet();
        }

        private void ShowFromFileList(int dimension, string[] fileset)
        {
            GnuPlotTemplate template = GnuPlotTemplate.Create(dimension, parameters.Parameters.NeedWriteFile);
            GnuPlotScriptGen script = new GnuPlotScriptGen(template, parameters.Parameters);

            foreach (string file in fileset)
            {
                int len;
                using (TextReader tr = File.OpenText(file))
                {
                    len = tr.ReadToEnd().Split('\n').Length;
                }
                script.AddFile(file, file + " " + len.ToString(), "dots");
            }
            RunGnuPlot(ResourceManager.Instance.TempFileAllocator.SaveToTempFile(script.Generate()), template);
        }


        private void RunGnuPlot(string filescript, GnuPlotTemplate template)
        {
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.FileName = ResourceManager.Instance.AbsolutePathFileName( template.Exe/*resource.SelectSingleNode("exe/text()").Value*/);
            pi.Arguments = string.Format(template.Arguments/*resource.SelectSingleNode("params/text()").Value*/, filescript);
            pi.ErrorDialog = true;

            Logger.LogMessage("Arguments: {0} ", pi.Arguments);

            Process.Start(pi);
        }


        public static void ExportFile(string[] files, string output, string title)
        {
            //GnuPlotParameters pars = new GnuPlotParameters(output, title);
            GnuPlotParametersImpl pars = new GnuPlotParametersImpl(output, "dots", 1000, 1000, true, true, false, false);
            GnuPlotVisualizationKernelAction action = new GnuPlotVisualizationKernelAction();
            action.SetActionParameters(pars);
            action.ShowFromFileList(2, files);
        }
    }
}