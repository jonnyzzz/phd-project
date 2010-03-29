using System;
using System.Xml.Serialization;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for GnuPlotTemplate.
	/// </summary>
	/// 
	[Serializable]
	[XmlRoot("GnuPlotTemplate")]
	public class GnuPlotTemplate
	{
		public GnuPlotTemplate()
		{
		}


		[XmlElement("header")]
		private string header = null;
		[XmlElement("bodyTemplate")]
		private string bodyTemplate = null;
		[XmlElement("delimiter")]
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
