using System;
using System.IO;
using System.Xml.Serialization;
using gui.Logger;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for Resources.
	/// </summary>
	/// 
	public class Resources
	{
		public static readonly string variableFormat = "y{0} = ";
		private static readonly string configXML = "gui.xml";
		private string resourcePath = null; // = @"e:\projects\morse\DotNetProject\Morse\DotNet\resource\included";


		private ResourceData resourceData = null;

		#region resourses getters
	
		public string ResourcePath
		{
			get { return resourcePath; }
		}
		
		public string GnuplotTemplates
		{
			get { return ResourcePath + resourceData.GnuplotTemplates; }
		}
		
		public string GnuplotExe
		{
			get { return ResourcePath + resourceData.GnuplotExe; }
		}
		
		public string GnuplotParams
		{
			get { return resourceData.GnuplotParams; }
		}

		public string TempPath
		{
			get { return tempPath; }
			set { tempPath = value; }
		}

		public string GnuplotTemplate2D
		{
			get { return GnuplotTemplates + resourceData.GnuplotTemplate2D; }
		}

		public string GnuplotTemplate3D
		{
			get { return GnuplotTemplates + resourceData.GnuplotTemplate3D; }
		}

		public string FileCreateTemplate
		{
			get { return resourceData.FileCreateTemplate; }
		}

		private int i = 0;
		public string TempFile 
		{
			get 
			{
				return TempPath +  string.Format(FileCreateTemplate, (i++), DateTime.Now.GetHashCode());
			}
		}

		#endregion

		private string tempPath = Path.GetTempPath();


		public Resources(ResourceData data)
		{			
			this.resourceData = data;
		}
	

		#region static

		private static Resources instance = null;
		public static Resources Instance
		{
			get { return instance; }
		}

		public static void Create(string applicationPath)
		{
			instance = new Resources(ResourceData.LoadResourceData(applicationPath + @"\" + configXML ));			
			instance.resourcePath = applicationPath + @"\";
		}


		#endregion
	}
}