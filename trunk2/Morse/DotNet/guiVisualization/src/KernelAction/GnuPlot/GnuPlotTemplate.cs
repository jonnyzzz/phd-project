using System.Xml;

namespace guiVisualization.KernelAction.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotTemplate.
	/// </summary>
	/// 
	public class GnuPlotTemplate
	{
		public GnuPlotTemplate(XmlNode node)
		{
			header = node.SelectSingleNode("header/text()").Value;
			bodyTemplate = node.SelectSingleNode("bodyTemplate/text()").Value;
			delimiter = node.SelectSingleNode("delimiter/text()").Value;
		}

		private string header = null;
		private string bodyTemplate = null;
		private string delimiter = null;

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
	}
}
