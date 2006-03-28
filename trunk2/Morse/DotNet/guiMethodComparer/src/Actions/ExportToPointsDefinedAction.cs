using System;
using System.IO;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.KernelAction.GnuPlotGen;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
	/// <summary>
	/// Summary description for ExportToPointsDefinedAction.
	/// </summary>
	public class ExportToPointsDefinedAction : DefinedActionBase, IGnuPlotGenActionParameters
	{
	    private string name;
        private string fullPath;
	    private string namePath;

	    public ExportToPointsDefinedAction(IMethodParameters methodParameters, string name, string fullPath) : base(methodParameters)
	    {
	        this.name = name;
            namePath = name;
            this.fullPath = fullPath;
            if (!Directory.Exists(GlobalPath))
            {
                Directory.CreateDirectory(GlobalPath);
            }
	        
	    }

	    public override string Name
	    {
	        get { return "Result Exporter"; }
	    }

	    public string Title
	    {
	        get { return name; }
	    }

	    public int Width
	    {
	        get { return 1000; }
	    }

	    public int Height
	    {
	        get { return 1000; }
	    }

	    public bool ShowHistory
	    {
	        get { return false; }
	    }

	    public string FullPath
	    {
	        get { return fullPath; }
	    }

	    public string GlobalPath
	    {
	        get { return Path.Combine(fullPath, namePath); }
	    }

	    public string GnuPlotFile
	    {
	        get { return "_.gnuplot"; }
	    }

	    public string OutputFile
	    {
	        get { return "_.png"; }
	    }

	    public string CopyOutImageName
	    {
            get { return Path.Combine(FullPath, name + ".png"); }
	    }
	    
	    public string PointFileFormat
	    {
	        get { return "data{0}.pts"; }
	    }

	    public string ParametersFile
	    {
	        get { return "_.txt"; }
	    }

		public string ShowStyle(IResult result)
		{		
			return "dots";
		}

		public string LocalLogFile
	    {
	        get{ return Path.Combine(GlobalPath, "log.txt");}
	    }

		public string LocalXmlLogFile
		{
			get { return Path.Combine(GlobalPath, "log.xml");}
		}

	    public override IAction Action
	    {
	        get { return new GnuPlotGenAction(); }
	    }
	}
}
