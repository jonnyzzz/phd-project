using System;
using System.Reflection;
using System.Windows.Forms;
using gui2.Document;
using gui2.Forms;
using gui2.TreeNodes;
using guiKernel2.Document;
using guiKernel2.Container;

namespace gui2.Runner
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	public class Runner
	{
		private CommandLineParser commandLine;
		private ComputationForm computationForm;
		private Core core;
		private bool isInternal;
		private Document.Document document = null;

		public Runner(CommandLineParser commandLine)
		{
			runner = this;
			this.commandLine = commandLine;
			this.core = Core.Instance;

			this.computationForm = new ComputationForm();			

			if (!commandLine.hasKey("verbose")) 
			{
				Application.Run(computationForm);
			} 
			else 
			{
				if (commandLine.hasKey("testMode"))
				{
					TestMode();
				}
			}

			isInternal = commandLine.hasKey("Internal");
		}

		public Core Core
		{
			get { return core; }
		}

		public Document.Document Document
		{
			get { return document; }
			set { document = value; }
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
			KernelDocument doc = new KernelDocument(Function.CreateTestFunction());
			new Node(doc.CreateInitialNode());
		}

		#region static
		[MTAThread]
		public static void Main(string[] args)
		{
			try {
				runner = new Runner(new CommandLineParser(args));
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
