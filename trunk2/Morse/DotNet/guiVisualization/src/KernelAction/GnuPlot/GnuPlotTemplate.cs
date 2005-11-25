using System.Xml;
using EugenePetrenko.Gui2.ExternalResource.Core;

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

        public GnuPlotTemplate(XmlNode generatorNode, XmlNode resource)
        {
            header = SafeGetText(generatorNode, "header/text()");
            history = SafeGetText(generatorNode, "history/text()");
            plot = SafeGetText(generatorNode, "plot/text()");
            bodyTemplate = SafeGetText(generatorNode, "bodyTemplate/text()");
            delimiter = SafeGetText(generatorNode, "delimiter/text()");
            footer = SafeGetText(generatorNode, "footer/text()");
            exe = SafeGetText(resource, "exe/text()");
            arguments = SafeGetText(resource,  "params/text()");

        }

        private string header = null;
        private string history = null;
        private string plot = null;
        private string bodyTemplate = null;
        private string delimiter = null;
        private string footer = null;

        private string exe = null;
        private string arguments = null;

        public string Exe
        {
            get { return exe; }
        }

        public string Arguments
        {
            get { return arguments; }
        }

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

        public static GnuPlotTemplate Create(int dimension, bool needSave)
        {
            XmlNode resource = ResourceManager.Instance.GetXmlResource("gnuplot").SelectSingleNode(!needSave ? "show" : "save");
            string xpath = string.Format("templates/template[@dimension=\"{0}\"]", dimension);
            return new GnuPlotTemplate(resource.SelectSingleNode(xpath), resource);
        }
    }
}