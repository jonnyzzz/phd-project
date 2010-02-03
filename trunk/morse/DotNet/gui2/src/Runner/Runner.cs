using System;
using System.IO;
using System.Threading;
using EugenePetrenko.Gui2.Application.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot;

namespace EugenePetrenko.Gui2.Application.Runner
{
    public delegate void RunInThread(object[] data);

    /// <summary>
    /// Summary description for Runner.
    /// </summary>
    public class Runner : IDisposable
    {
        private CommandLineParser commandLine;
        private ComputationForm computationForm;
        private Core core;
        private Document.Document document;
        private readonly bool isInternal;
        private readonly ResourceManager resourceManager;

        public Runner(CommandLineParser commandLine)
        {
            runner = this;
            this.commandLine = commandLine;
            isInternal = commandLine.HasKey("Internal");
            core = new Core(IsInternal);

            computationForm = new ComputationForm();
            resourceManager = ResourceManager.Instance;
        }

        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
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

                if (ComputationForm != null)
                    computationForm.OnDocumentCreated(value);

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

        #region IDisposable Members

        public void Dispose()
        {
            commandLine = null;
            computationForm = null;
            core.Dispose();
            core = null;
            if (document != null)
                document.DisposeOnExit();
            document = null;
        }

        #endregion

        private void Start()
        {
            if (commandLine.HasKey("resources"))
            {
                ResourceManager.SetResourcePath(commandLine.GetValue("resources"));
            }
            else
            {
                ResourceManager.SetResourcePath(System.Windows.Forms.Application.StartupPath + @"\resource\");
            }
            if (commandLine.HasKey("temporary"))
            {
                ResourceManager.SetTemporaryPath(commandLine.GetValue("temporary"));
            }
            else
            {
                ResourceManager.SetTemporaryPath(Path.GetTempPath() + "/");
            }

            ResourceManager.Start();

            if (!commandLine.HasKey("verbose"))
            {
                System.Windows.Forms.Application.Run(computationForm);
            }
            else if (commandLine.HasKey("testMode"))
            {
                TestMode();
            }
            else if (commandLine.HasKey("export"))
            {
                string[] files = commandLine.GetValue("files").Split(';');
                string output = commandLine.GetValue("out");
                string title = commandLine.GetValue("title");

                Console.Out.WriteLine("Exporting file please wait...");
                CommandLineFileExporter.ExportFiles(files, output, title);
            }
        }

        public void RunThread(RunInThread start, params object[] data)
        {
          start(data);
          //start.BeginInvoke(data, null, null);
          /*ThreadStart threadStart = ()=> start(data);
           * var thread = new Thread(threadStart);
//            thread.TrySetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Name = "COM computations";
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();*/
        }

        public void TestMode()
        {
            Function f = Function.CreateTestFunction();
            var doc = new KernelDocument(f);
            new Node(doc.CreateInitialNode(), f.Iterations);
        }

        #region static

        private static Runner runner;

        public static Runner Instance
        {
            get { return runner; }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                runner = new Runner(new CommandLineParser(args));
                using (runner)
                {
                    runner.Start();
                }
                runner = null;
            }
            catch (CommandLineParseException e)
            {
                Console.Out.WriteLine("Wrong Command Line parameters");
                Console.Out.WriteLine(e.Message);
            }
        }

        #endregion
    }
}