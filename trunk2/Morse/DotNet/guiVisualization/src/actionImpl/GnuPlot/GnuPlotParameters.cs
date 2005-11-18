using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.KernelAction;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot
{
    /// <summary>
    /// Summary description for GnuPlotParameters.
    /// </summary>
    public class GnuPlotParameters : ParametersControl, IGnuPlotVisualizationKernelParameters, GnuPlotScriptGenParameters
    {
        private string fileNameToSave = null;
        private string defaultTitle = string.Empty;

        public GnuPlotParameters(string fileNameToSave, string defaultTitle)
        {
            this.fileNameToSave = fileNameToSave;
            this.defaultTitle = defaultTitle == null ? "" : defaultTitle;
        }

        public GnuPlotParameters()
        {
        }

        protected override IParameters SubmitDataInternal()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "png";
            dialog.Filter = "Png image|*.png|All files|*.*";
            dialog.Title = "Select file to save picture or press cancel to show it";

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                fileNameToSave = dialog.FileName;
            }
            else
            {
                fileNameToSave = null;
            }

            return this;
        }

        public override string BoxCaption
        {
            get { return "Visualization settings"; }
        }

        public override bool NeedShowForm
        {
            get { return false; }
        }

        public GnuPlotScriptGenParameters Parameters
        {
            get { return FileName == null ? null : this; }
        }

        public string FileName
        {
            get { return this.fileNameToSave; }
        }

        int GnuPlotScriptGenParameters.Width
        {
            get { return 1000; }
        }

        int GnuPlotScriptGenParameters.Height
        {
            get { return 1000; }
        }


        public string Title
        {
            get
            {
                if (Core.Instance.KernelDocument != null && Core.Instance.KernelDocument.Title != null)
                {
                    return Core.Instance.KernelDocument.Title;
                }
                else return defaultTitle;
            }
        }
    }
}