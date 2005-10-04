using System.Xml;

namespace guiVisualization.KernelAction.GnuPlot
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
			return node == null? null : node.Value;
		}

		public GnuPlotTemplate(XmlNode node)
		{
			header = SafeGetText(node, "header/text()");
			bodyTemplate = SafeGetText(node, "bodyTemplate/text()");
			delimiter = SafeGetText(node, "delimiter/text()");
			footer = SafeGetText(node, "footer/text()");
		}

		private string header = null;
		private string bodyTemplate = null;
		private string delimiter = null;
		private string footer = null;

		public string Header
		{
			get { return header; }
			set { header = value; }
		}

		public string BodyTemplate
		{
			get { return bodyTemplate; }
			set { bodyTemplate = value; }
		}

		public string Delimiter
		{
			get { return delimiter; }
			set { delimiter = value; }
		}

		public string Footer 
		{
			get { return footer;}
		}
	}
}
