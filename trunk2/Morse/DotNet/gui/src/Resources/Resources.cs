using System;
using System.IO;
using System.Xml;
using gui.Logger;
using gui.Tree;

namespace gui.Resource
{
	/// <summary>
	/// Summary description for Resources.
	/// </summary>
	public class Resources
	{
		public static string VARIABLE_FORMAT = "y{0} = ";

        #region resourses getters
	    public string Resource_Path
	    {
	        get { return RESOURCE_PATH; }
	    }

	    public string Gnuplot_Templates
	    {
	        get { return Resource_Path + GNUPLOT_TEMPLATES; }
	    }

	    public string Gnuplot_Exe
	    {
	        get { return Resource_Path + GNUPLOT_EXE; }
	    }

	    public string Gnuplot_Exe_Params
	    {
	        get { return GNUPLOT_EXE_PARAMS; }
	    }

	    public string Temp_Path
	    {
	        get { return TEMP_PATH; }
	    }

	    public string Gnuplot_Template_2D
	    {
	        get { return Gnuplot_Templates +  GNUPLOT_TEMPLATE_2D; }
	    }

	    public string Gnuplot_Template_3D
	    {
	        get { return Gnuplot_Templates + GNUPLOT_TEMPLATE_3D; }
	    }
        #endregion

	    private string RESOURCE_PATH;// = @"e:\projects\morse\DotNetProject\Morse\DotNet\resource\included";        
        private const string CONFIG_XML = "gui.ini";       
        
        private string GNUPLOT_TEMPLATES;// = RESOURCE_PATH + @"\gnuplottemplate";
        private string GNUPLOT_EXE;// = GNUPLOT_PATH + @"\bin\pgnuplot.exe";
        private string GNUPLOT_EXE_PARAMS;// = @"-noend {0} -";
        
        private string TEMP_PATH = Path.GetTempPath();
        
        private string GNUPLOT_TEMPLATE_2D;// = GNUPLOT_TEMPLATES + @"\2d.txt";
        private string GNUPLOT_TEMPLATE_3D;// = GNUPLOT_TEMPLATES + @"\3d.txt";


        protected Resources(string basePath)
        {
            RESOURCE_PATH = basePath + "\\";

            Log.LogMessage(this, "Starting from {0}", RESOURCE_PATH);

            string config = RESOURCE_PATH + CONFIG_XML;

            if (!File.Exists(config))
            {
                Log.LogException(this, new FileNotFoundException(), "Unable to open config file");
            }
            
            TextReader tr = File.OpenText(config);

            string s;
            while ((s = tr.ReadLine()) != null)
            {
                string[] data = s.Trim().Split('=');
                if (data.Length != 2) continue;//throw new ArgumentException("File format error!");

                string key = data[0].Trim();
                string val = data[1].Trim();

                if (key == "gnuplot_template")
                {
                    GNUPLOT_TEMPLATES = val;
                } else if (key == "gnuplot_exe")
                {
                    GNUPLOT_EXE = val;
                } else if (key == "gnuplot_params")
                {
                    GNUPLOT_EXE_PARAMS = val;
                } else if (key == "gnuplot_template_2d")
                {
                    GNUPLOT_TEMPLATE_2D = val;
                } else if (key == "gnuplot_template_3d")
                {
                    GNUPLOT_TEMPLATE_3D = val;
                } else Log.LogMessage(this, "Unexpected key {0}={1} Ignoring", key, val);
            }                        
            tr.Close();
        }

        protected Resources(string basePath, string tempPath) : this(basePath)
        {
            this.TEMP_PATH = tempPath;
        }


        #region functiononality
        public int i=0;
        public string TempFile()
        {
            return TEMP_PATH + "jonny." + (i++).ToString() + ".temporary";//DateTime.UtcNow.Millisecond + "." + DateTime.UtcNow.Second + "." + DateTime.UtcNow.Minute + "." + DateTime.UtcNow.Hour;
        }
        #endregion


        #region static
        private static Resources instance = null;

        public static Resources Instance
        {
            get
            {
                return instance;
            }
        }

        public static void SetBasePath(string path)
        {
            instance = new Resources(path);
        }
        public static void SetBasePath(string path, string temppath)
        {
            instance = new Resources(path, temppath);
        }
        #endregion
	}
}
