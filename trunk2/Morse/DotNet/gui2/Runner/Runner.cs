using System;
using System.Windows.Forms;
using gui2.Forms;

namespace gui2.Runner
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	public class Runner
	{
		private CommandLineParser commandLine;
		private ComputationForm computationForm;
		private bool isInternal;
		private Document.Document document = null;

		public Runner(CommandLineParser commandLine)
		{
			runner = this;
			this.commandLine = commandLine;
			this.computationForm = new ComputationForm();
			Application.Run(computationForm);

			isInternal = commandLine.hasKey("Internal");
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
