using System;
using System.IO;
using System.Windows.Forms;
using gui2.Forms;
using gui2.TreeNodes;
using guiExternalResource.Core;
using guiKernel2.Document;
using guiKernel2.Container;
using guiVisualization.actionImpl.GnuPlot;
using guiVisualization.KernelAction;
using guiVisualization.src.actionImpl.GnuPlot;

namespace gui2.Runner
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	public class Runner : IDisposable
	{
		private CommandLineParser commandLine;
		private ComputationForm computationForm;
		private Core core;
		private bool isInternal;
		private Document.Document document = null;
		private ResourceManager resourceManager = null;

		public Runner(CommandLineParser commandLine)
		{
			runner = this;
			this.commandLine = commandLine;
			isInternal = commandLine.hasKey("Internal");
			this.core = new Core(IsInternal);

			this.computationForm = new ComputationForm();						
			this.resourceManager = guiExternalResource.Core.ResourceManager.Instance;
		}

		public ResourceManager ResourceManager
		{
			get { return resourceManager; }
		}

		protected void Start()
		{
			if (commandLine.hasKey("resources"))
			{
				ResourceManager.SetResourcePath(commandLine.getValue("resources"));	
			} else
			{
				ResourceManager.SetResourcePath(Application.StartupPath + @"\resource\");
			}
			if (commandLine.hasKey("temporary"))
			{
				ResourceManager.SetTemporaryPath(commandLine.getValue("temporary"));
			} else
			{
				ResourceManager.SetTemporaryPath(Path.GetTempPath()+ "/");
			}
			
			ResourceManager.Start();

			if (!commandLine.hasKey("verbose")) 
			{
				Application.Run(computationForm);
			} 
			else if (commandLine.hasKey("testMode"))
			{
				TestMode();
			} else if (commandLine.hasKey("export"))
			{
				string[] files = commandLine.getValue("files").Split(';');
				string output = commandLine.getValue("out");
				string title = commandLine.getValue("title");

				Console.Out.WriteLine("Exporting file please wait...");
				CommandLineFileExporter.ExportFiles(files, output, title);
			}
		}

		public void Dispose()
		{
			commandLine = null;
			computationForm = null;
			core.Dispose();
			core = null;
            if (document != null)
			    document.Dispose();
			document = null;
		}

		public Core Core
		{
			get { return core; }
		}

		public Document.Document Document
		{
			get { return document; }
			set
			{
				if (document != null)
				{
					document.Dispose();
				}
				document = value;
			}
		}

		public CommandLineParser CommandLine
		{
			get { return commandLine; }
		}

		public ComputationForm ComputationForm
		{
			get { return computationForm; }
		}

		public bool IsInternal
		{
			get { return isInternal; }
		}

		public void TestMode()
		{
			Function f = Function.CreateTestFunction();
			KernelDocument doc = new KernelDocument(f);
			new Node(doc.CreateInitialNode(),f.Iterations);
		}

		#region static
		[STAThread]
		public static void Main(string[] args)
		{
			try {
				runner = new Runner(new CommandLineParser(args));
				using (runner)
				{
					runner.Start();
				}
				runner = null;
			} catch (CommandLineParseException e)
			{
				Console.Out.WriteLine("Wrong Command Line parameters");
				Console.Out.WriteLine(e.Message);
			}
		}

		private static Runner runner = null;
		public static Runner Instance
		{
			get
			{
				return runner;
			}
		}
		#endregion
	}
}
