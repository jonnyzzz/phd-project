using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Application.ActionPerformer;
using EugenePetrenko.Gui2.Application.Document;
using EugenePetrenko.Gui2.Application.Progress;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Controls.Progress;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Serialization;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.Forms
{
    /// <summary>
    /// Summary description for ComputationForm.
    /// </summary>
    public class ComputationForm : Form
    {
        private Panel panelLeft;
        private ComputationTree tree;
        private MainMenu mainMenu;
        private MenuItem menuInternal;
        private MenuItem menuInvestigations;
        private MenuItem menuSystem;
        private MenuItem menuSystemNew;
        private Panel panelRightDown;
        private GroupBox groupBoxProgressBar;
        private Panel panelProgress;
        private SmartProgressBar progressBar;
        private MenuItem menuFunctionShow;
        private MenuItem menuHelp;
        private MenuItem menuHelpAbout;
        private MenuItem menuSave;
        private SaveFileDialog saveDocumentDialog;
        private OpenFileDialog openDocumentDialog;
        private MenuItem menuOpenDocument;
        private MenuItem menuSystemAnalisys;
        private MenuItem menuSystemIterations;
        private MenuItem menuSystemDelimiter1;
        private MenuItem menuSystemDelimiter2;
        private MenuItem menuSystemDelimiter3;
        private MenuItem menuSystemComment;
		private System.Windows.Forms.Panel panelLeftUp;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.MenuItem menuItemFileNew;
		private System.Windows.Forms.MenuItem menuItemFileSeparator;
		private System.Windows.Forms.MenuItem menuItemFileExit;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public ComputationForm()
        {
            InitializeComponent();

            menuInternal.Visible = Runner.Runner.Instance.IsInternal;

            progressBarInfo = new ProgressBarInfo();
            progressBarAdapter = new ProgressBarNotificationAdapter(progressBar, progressBarInfo);
            tree.OnBeforeCheckChanged += new BeforeCheckChanged(OnBeforeCheckChanged);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ComputationForm));
			this.panelLeft = new System.Windows.Forms.Panel();
			this.splitter = new System.Windows.Forms.Splitter();
			this.panelLeftUp = new System.Windows.Forms.Panel();
			this.tree = new EugenePetrenko.Gui2.Controls.TreeControl.ComputationTree();
			this.panelRightDown = new System.Windows.Forms.Panel();
			this.groupBoxProgressBar = new System.Windows.Forms.GroupBox();
			this.panelProgress = new System.Windows.Forms.Panel();
			this.progressBar = new EugenePetrenko.Gui2.Controls.Progress.SmartProgressBar();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuInvestigations = new System.Windows.Forms.MenuItem();
			this.menuOpenDocument = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuItemFileNew = new System.Windows.Forms.MenuItem();
			this.menuSystem = new System.Windows.Forms.MenuItem();
			this.menuSystemNew = new System.Windows.Forms.MenuItem();
			this.menuSystemDelimiter1 = new System.Windows.Forms.MenuItem();
			this.menuFunctionShow = new System.Windows.Forms.MenuItem();
			this.menuSystemAnalisys = new System.Windows.Forms.MenuItem();
			this.menuSystemDelimiter2 = new System.Windows.Forms.MenuItem();
			this.menuSystemIterations = new System.Windows.Forms.MenuItem();
			this.menuSystemDelimiter3 = new System.Windows.Forms.MenuItem();
			this.menuSystemComment = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.menuInternal = new System.Windows.Forms.MenuItem();
			this.saveDocumentDialog = new System.Windows.Forms.SaveFileDialog();
			this.openDocumentDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuItemFileSeparator = new System.Windows.Forms.MenuItem();
			this.menuItemFileExit = new System.Windows.Forms.MenuItem();
			this.panelLeft.SuspendLayout();
			this.panelLeftUp.SuspendLayout();
			this.panelRightDown.SuspendLayout();
			this.groupBoxProgressBar.SuspendLayout();
			this.panelProgress.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.splitter);
			this.panelLeft.Controls.Add(this.panelLeftUp);
			this.panelLeft.Controls.Add(this.panelRightDown);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeft.DockPadding.All = 10;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(648, 609);
			this.panelLeft.TabIndex = 0;
			// 
			// splitter
			// 
			this.splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter.Location = new System.Drawing.Point(10, 524);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(628, 3);
			this.splitter.TabIndex = 2;
			this.splitter.TabStop = false;
			// 
			// panelLeftUp
			// 
			this.panelLeftUp.Controls.Add(this.tree);
			this.panelLeftUp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeftUp.DockPadding.All = 5;
			this.panelLeftUp.Location = new System.Drawing.Point(10, 10);
			this.panelLeftUp.Name = "panelLeftUp";
			this.panelLeftUp.Size = new System.Drawing.Size(628, 517);
			this.panelLeftUp.TabIndex = 1;
			// 
			// tree
			// 
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.Location = new System.Drawing.Point(5, 5);
			this.tree.Name = "tree";
			this.tree.Root = null;
			this.tree.Size = new System.Drawing.Size(618, 507);
			this.tree.TabIndex = 0;
			// 
			// panelRightDown
			// 
			this.panelRightDown.Controls.Add(this.groupBoxProgressBar);
			this.panelRightDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelRightDown.DockPadding.Left = 5;
			this.panelRightDown.DockPadding.Right = 5;
			this.panelRightDown.DockPadding.Top = 5;
			this.panelRightDown.Location = new System.Drawing.Point(10, 527);
			this.panelRightDown.Name = "panelRightDown";
			this.panelRightDown.Size = new System.Drawing.Size(628, 72);
			this.panelRightDown.TabIndex = 1;
			// 
			// groupBoxProgressBar
			// 
			this.groupBoxProgressBar.Controls.Add(this.panelProgress);
			this.groupBoxProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxProgressBar.Location = new System.Drawing.Point(5, 5);
			this.groupBoxProgressBar.Name = "groupBoxProgressBar";
			this.groupBoxProgressBar.Size = new System.Drawing.Size(618, 67);
			this.groupBoxProgressBar.TabIndex = 0;
			this.groupBoxProgressBar.TabStop = false;
			this.groupBoxProgressBar.Text = "Computation Progress Bar";
			// 
			// panelProgress
			// 
			this.panelProgress.Controls.Add(this.progressBar);
			this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelProgress.DockPadding.Bottom = 5;
			this.panelProgress.DockPadding.Left = 5;
			this.panelProgress.DockPadding.Right = 5;
			this.panelProgress.DockPadding.Top = 5;
			this.panelProgress.Location = new System.Drawing.Point(3, 16);
			this.panelProgress.Name = "panelProgress";
			this.panelProgress.Size = new System.Drawing.Size(612, 48);
			this.panelProgress.TabIndex = 0;
			// 
			// progressBar
			// 
			this.progressBar.BackColor = System.Drawing.SystemColors.Control;
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar.Location = new System.Drawing.Point(5, 27);
			this.progressBar.LowerBound = 0;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(602, 16);
			this.progressBar.TabIndex = 0;
			this.progressBar.UpperBound = 10;
			this.progressBar.Value = 0;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuInvestigations,
																					 this.menuSystem,
																					 this.menuHelp,
																					 this.menuInternal});
			// 
			// menuInvestigations
			// 
			this.menuInvestigations.Index = 0;
			this.menuInvestigations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.menuItemFileNew,
																							   this.menuOpenDocument,
																							   this.menuSave,
																							   this.menuItemFileSeparator,
																							   this.menuItemFileExit});
			this.menuInvestigations.Text = "File";
			// 
			// menuOpenDocument
			// 
			this.menuOpenDocument.Index = 1;
			this.menuOpenDocument.Text = "Open";
			this.menuOpenDocument.Click += new System.EventHandler(this.menuOpenDocument_Click);
			// 
			// menuSave
			// 
			this.menuSave.Index = 2;
			this.menuSave.Text = "Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuItemFileNew
			// 
			this.menuItemFileNew.Index = 0;
			this.menuItemFileNew.Text = "New";			
			this.menuItemFileNew.Click += new System.EventHandler(this.menuSystemNew_Click);
			// 
			// menuSystem
			// 
			this.menuSystem.Index = 1;
			this.menuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuSystemNew,
																					   this.menuSystemDelimiter1,
																					   this.menuFunctionShow,
																					   this.menuSystemAnalisys,
																					   this.menuSystemDelimiter2,
																					   this.menuSystemIterations,
																					   this.menuSystemDelimiter3,
																					   this.menuSystemComment});
			this.menuSystem.Text = "Function";
			// 
			// menuSystemNew
			// 
			this.menuSystemNew.Index = 0;
			this.menuSystemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuSystemNew.Text = "New";
			this.menuSystemNew.Click += new System.EventHandler(this.menuSystemNew_Click);
			// 
			// menuSystemDelimiter1
			// 
			this.menuSystemDelimiter1.Index = 1;
			this.menuSystemDelimiter1.Text = "-";
			// 
			// menuFunctionShow
			// 
			this.menuFunctionShow.Index = 2;
			this.menuFunctionShow.Text = "Show";
			this.menuFunctionShow.Click += new System.EventHandler(this.MenuFunctionShowClick);
			// 
			// menuSystemAnalisys
			// 
			this.menuSystemAnalisys.Index = 3;
			this.menuSystemAnalisys.Text = "Analisys";
			this.menuSystemAnalisys.Click += new System.EventHandler(this.menuSystemAnalisys_Click);
			// 
			// menuSystemDelimiter2
			// 
			this.menuSystemDelimiter2.Index = 4;
			this.menuSystemDelimiter2.Text = "-";
			// 
			// menuSystemIterations
			// 
			this.menuSystemIterations.Index = 5;
			this.menuSystemIterations.Text = "Iterations";
			this.menuSystemIterations.Click += new System.EventHandler(this.menuSystemIterations_Click);
			// 
			// menuSystemDelimiter3
			// 
			this.menuSystemDelimiter3.Index = 6;
			this.menuSystemDelimiter3.Text = "-";
			// 
			// menuSystemComment
			// 
			this.menuSystemComment.Index = 7;
			this.menuSystemComment.Text = "Comment";
			this.menuSystemComment.Click += new System.EventHandler(this.menuSystemComment_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuHelpAbout});
			this.menuHelp.Text = "Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Text = "About";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// menuInternal
			// 
			this.menuInternal.Index = 3;
			this.menuInternal.Text = "Internal";
			// 
			// saveDocumentDialog
			// 
			this.saveDocumentDialog.DefaultExt = "dsif";
			this.saveDocumentDialog.Filter = "Dynamical System Investigations Files(*.dsif)|*.dsif|All files(*.*)|*.*";
			this.saveDocumentDialog.Title = "Select file to save project";
			// 
			// openDocumentDialog
			// 
			this.openDocumentDialog.DefaultExt = "dsif";
			this.openDocumentDialog.Filter = "Dynamical System Investigations Files(*.dsif)|*.dsif|All files(*.*)|*.*";
			this.openDocumentDialog.Title = "Select System to open";
			// 
			// menuItemFileSeparator
			// 
			this.menuItemFileSeparator.Index = 3;
			this.menuItemFileSeparator.Text = "-";
			// 
			// menuItemFileExit
			// 
			this.menuItemFileExit.Index = 4;
			this.menuItemFileExit.Text = "Exit";
			this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
			// 
			// ComputationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 609);
			this.Controls.Add(this.panelLeft);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "ComputationForm";
			this.Text = "Dynamical Systems Investigation Program";
			this.Click += new System.EventHandler(this.menuSystemNew_Click);
			this.panelLeft.ResumeLayout(false);
			this.panelLeftUp.ResumeLayout(false);
			this.panelRightDown.ResumeLayout(false);
			this.groupBoxProgressBar.ResumeLayout(false);
			this.panelProgress.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        #endregion

        private void menuSystemNew_Click(object sender, EventArgs e)
        {
            SystemAssignment assignment = new SystemAssignment();
            if (assignment.ShowDialog(this) == DialogResult.OK)
            {
                Function function = assignment.Function;
                Logger.LogMessage(function.ToString());

                OpenNewDocument(new Document.Document(function));
            }
        }

        public void OpenNewDocument(Document.Document document)
        {
			//TODO: Save Expand State
            Runner.Runner.Instance.Document = document;
			
            tree.Root = document.RootNode;
            tree.Root.ExpandAll();
        }


        private ProgressBarInfo progressBarInfo;
        private ProgressBarNotificationAdapter progressBarAdapter;

        public ProgressBarInfo ProgressBar
        {
            get { return progressBarInfo; }
        }


        public void AcceptActionChain(Node node, Action[] chain)
        {
            ChainPerformer performer = new ChainPerformer(node, chain, ProgressBar);
            performer.Started += new StateEvent(performer_Start);
            performer.Finished += new StateEvent(performer_Finish);
            performer.DoActionsWithDialog(this);
        }


        public void Lock()
        {
//            this.Enabled = false;
            tree.Enabled = false;
        }

        public void Unlock()
        {
//            this.Enabled = true;
            tree.Enabled = true;
        }


        public bool OnBeforeCheckChanged(ComputationNode computationNode)
        {
            if (computationNode is Node)
            {
                Node node = (Node) computationNode;
                try
                {
                    node.SelectionChanging();
                    return false;
                }
                catch (GroupException e)
                {
                    MessageBox.Show(this, e.Message, "Grouping Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            return true;
        }

        private void performer_Start()
        {
            Runner.Runner.Instance.Document.Lock();
        }

        private void performer_Finish()
        {
            Runner.Runner.Instance.Document.UnLock();
        }

        private void MenuFunctionShowClick(object sender, EventArgs e)
        {
            if (Runner.Runner.Instance.Document != null)
            {
				using(SystemAssignment assignment = new SystemAssignment(Runner.Runner.Instance.Document.KernelDocument.Function)) 
				{
					assignment.ShowDialog(this);
				}
            }
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
			using(About about = new About()) 
			{
				about.ShowDialog();
			}
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (Runner.Runner.Instance.Document == null) return;

            if (saveDocumentDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string filename = saveDocumentDialog.FileName;

                    string pathbase = Path.GetDirectoryName(filename);

                    XmlNode xml = DocumentSerializer.SaveDocument(Runner.Runner.Instance.Document, pathbase);

                    XmlDocument document = XmlUtil.CreateEmptyDocument();
                    XmlUtil.SetRootNode(document, xml);

                    using (TextWriter file = File.CreateText(filename))
                    {
                        document.Save(file);
                    }
                }
                catch (SerializationException ee)
                {
                    MessageBox.Show(this, "Failed to save file: " + ee.Message);
                    Logger.LogException(ee);
                }
            }
        }

        private void menuOpenDocument_Click(object sender, EventArgs e)
        {
            if (openDocumentDialog.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openDocumentDialog.FileName;
                string pathbase = Path.GetDirectoryName(filename);

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                OpenNewDocument(DocumentSerializer.LoadDocument(doc, pathbase));
            }
        }

        private void menuSystemAnalisys_Click(object sender, EventArgs e)
        {
            SystemFunctionAnalisys.ShowAnalisys();

        }

        private void menuSystemIterations_Click(object sender, EventArgs e)
        {
            if (Runner.Runner.Instance.Document != null)
            {
                FunctionIterations its = new FunctionIterations(Runner.Runner.Instance.Document.KernelDocument.Function.Iterations);

                if (its.ShowDialog(this) == DialogResult.OK)
                {
                    menuSystemIterations.Checked = true;
                    Runner.Runner.Instance.Document.KernelDocument.Function.Iterations = its.Iterations;
                }
            }
        }

        private void menuSystemComment_Click(object sender, EventArgs e)
        {
            Document.Document doc = Runner.Runner.Instance.Document;
            if (doc != null)
            {
                UserComment comment = new UserComment(doc.KernelDocument.Title);
                if (comment.ShowDialog(this) == DialogResult.OK)
                {
                    doc.KernelDocument.Title = comment.UserCommentText;
                }
            }
        }

		private void menuItemFileExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

    	protected override void OnClosing(CancelEventArgs e)   
		{
    	}		
    }
}