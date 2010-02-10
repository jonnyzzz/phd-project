using System;
using System.IO;
using System.Xml.Serialization;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for ResourceData.
	/// </summary>
	/// 
	[Serializable]
	[XmlRoot("Resources")]
	public class ResourceData
	{
		public ResourceData()
		{
		}

		[XmlElement("gnuplotexe")]
		private string gnuplotExe = null; // = GNUPLOT_PATH + @"\bin\pgnuplot.exe";
		[XmlElement("gnuplotparams")]		
		private string gnuplotParams = null; // = @"-noend {0} -";
		[XmlElement("gnuplottemplate2d", typeof(GnuPlotTemplate))]
		private GnuPlotTemplate gnuplotTemplate2D = null; // = GNUPLOT_TEMPLATES + @"\2d.txt";
		[XmlElement("gnuplottemplate3d", typeof(GnuPlotTemplate))]
		private GnuPlotTemplate gnuplotTemplate3D = null; // = GNUPLOT_TEMPLATES + @"\3d.txt";
		[XmlElement("tempfilename")]
		private string fileCreateTemplate = "{0}.{1}.system.data";

		public string GnuplotExe
		{
			get { return gnuplotExe; }
			set { gnuplotExe = value; }
		}

		public string GnuplotParams
		{
			get { return gnuplotParams; }
			set { gnuplotParams = value; }
		}

		public GnuPlotTemplate GnuplotTemplate2D
		{
			get { return gnuplotTemplate2D; }
			set { gnuplotTemplate2D = value; }
		}

		public GnuPlotTemplate GnuplotTemplate3D
		{
			get { return gnuplotTemplate3D; }
			set { gnuplotTemplate3D = value; }
		}

		public string FileCreateTemplate
		{
			get { return fileCreateTemplate; }
			set { fileCreateTemplate = value; }
		}

		private static XmlSerializer CreateSerializer()
		{
			return new XmlSerializer(typeof(ResourceData), new Type[]{ typeof(GnuPlotTemplate)});
		}

		public static ResourceData LoadResourceData(string fileName)
		{
			TextReader reader = File.OpenText(fileName);
			XmlSerializer serializer = CreateSerializer();
			ResourceData data =  serializer.Deserialize(reader) as ResourceData;
			reader.Close();

			return data;
		}

		public static void SaveResourceData(ResourceData data,  string fileName)
		{
			TextWriter writer = File.CreateText(fileName);
			XmlSerializer serializer = CreateSerializer();
			serializer.Serialize(writer, data);
			writer.Close();
		}
	}
}
