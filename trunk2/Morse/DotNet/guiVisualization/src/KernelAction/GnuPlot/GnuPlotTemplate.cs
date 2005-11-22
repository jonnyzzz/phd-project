using System.Xml;

namespace EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlot
{
    /// <summary>
    /// Summary description for GnuPlotTemplate.
    /// </summary>
    /// 
    public class GnuPlotTemplate
    {
        private string SafeGetText(XmlNode root, string path)
        {
            XmlNode node = root.SelectSingleNode(path);
            return node == null ? null : node.Value;
        }

        public GnuPlotTemplate(XmlNode node)
        {
            header = SafeGetText(node, "header/text()");
            history = SafeGetText(node, "history/text()");
            plot = SafeGetText(node, "plot/text()");
            bodyTemplate = SafeGetText(node, "bodyTemplate/text()");
            delimiter = SafeGetText(node, "delimiter/text()");
            footer = SafeGetText(node, "footer/text()");
        }

        private string header = null;
        private string history = null;
        private string plot = null;
        private string bodyTemplate = null;
        private string delimiter = null;
        private string footer = null;

        public string Header
        {
            get { return header; }
        }

        public string History
        {
            get { return history; }
        }

        public string Plot
        {
            get { return plot; }
        }

        public string BodyTemplate
        {
            get { return bodyTemplate; }
        }

        public string Delimiter
        {
            get { return delimiter; }
        }

        public string Footer
        {
            get { return footer; }
        }
    }
}