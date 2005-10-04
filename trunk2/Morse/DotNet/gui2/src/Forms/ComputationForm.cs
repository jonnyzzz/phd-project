using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using gui2.ActionPerformer;
using gui2.Progress;
using gui2.src.Document;
using gui2.src.TreeNodes;
using gui2.TreeNodes;
using guiActions.Actions;
using guiControls.TreeControl;
using guiKernel2.Actions;
using guiKernel2.Document;
using guiKernel2.Serialization;

namespace gui2.Forms
{
	/// <summary>
	/// Summary description for ComputationForm.
	/// </summary>
	public class ComputationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelRight;
		private guiControls.TreeControl.ComputationTree tree;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuInternal;
		private System.Windows.Forms.MenuItem menuInvestigations;
		private System.Windows.Forms.MenuItem menuSystem;
		private System.Windows.Forms.MenuItem menuSystemNew;
		private System.Windows.Forms.Splitter splitterLR;
		private System.Windows.Forms.Panel panelRightUp;
		private System.Windows.Forms.Panel panelRightDown;
		private System.Windows.Forms.GroupBox groupBoxProgressBar;
		private System.Windows.Forms.Panel panelProgress;
		private guiControls.Progress.SmartProgressBar progressBar;
		private System.Windows.Forms.GroupBox groupBoxControlInfo;
		private System.Windows.Forms.Panel panelInfo;
		private System.Windows.Forms.MenuItem menuFunctionShow;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.MenuItem menuDelimeter;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.SaveFileDialog saveDocumentDialog;
		private System.Windows.Forms.OpenFileDialog openDocumentDialog;
		private System.Windows.Forms.MenuItem menuOpenDocument;
		private System.Windows.Forms.MenuItem menuSystemAnalisys;
		private System.Windows.Forms.MenuItem menuSystemIterations;
		private System.Windows.Forms.MenuItem menuSystemDelimiter1;
		private System.Windows.Forms.MenuItem menuSystemDelimiter2;
		private System.Windows.Forms.MenuItem menuSystemDelimiter3;
		private System.Windows.Forms.MenuItem menuSystemComment;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
			this.tree = new guiControls.TreeControl.ComputationTree();
			this.panelRight = new System.Windows.Forms.Panel();
			this.panelRightUp = new System.Windows.Forms.Panel();
			this.groupBoxControlInfo = new System.Windows.Forms.GroupBox();
			this.panelInfo = new System.Windows.Forms.Panel();
			this.panelRightDown = new System.Windows.Forms.Panel();
			this.groupBoxProgressBar = new System.Windows.Forms.GroupBox();
			this.panelProgress = new System.Windows.Forms.Panel();
			this.progressBar = new guiControls.Progress.SmartProgressBar();
			this.splitterLR = new System.Windows.Forms.Splitter();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuInternal = new System.Windows.Forms.MenuItem();
			this.menuInvestigations = new System.Windows.Forms.MenuItem();
			this.menuSystem = new System.Windows.Forms.MenuItem();
			this.menuSystemNew = new System.Windows.Forms.MenuItem();
			this.menuFunctionShow = new System.Windows.Forms.MenuItem();
			this.menuSystemAnalisys = new System.Windows.Forms.MenuItem();
			this.menuSystemIterations = new System.Windows.Forms.MenuItem();
			this.menuDelimeter = new System.Windows.Forms.MenuItem();
			this.menuOpenDocument = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.saveDocumentDialog = new System.Windows.Forms.SaveFileDialog();
			this.openDocumentDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuSystemDelimiter1 = new System.Windows.Forms.MenuItem();
			this.menuSystemDelimiter2 = new System.Windows.Forms.MenuItem();
			this.menuSystemDelimiter3 = new System.Windows.Forms.MenuItem();
			this.menuSystemComment = new System.Windows.Forms.MenuItem();
			this.panelLeft.SuspendLayout();
			this.panelRight.SuspendLayout();
			this.panelRightUp.SuspendLayout();
			this.groupBoxControlInfo.SuspendLayout();
			this.panelRightDown.SuspendLayout();
			this.groupBoxProgressBar.SuspendLayout();
			this.panelProgress.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.tree);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeft.DockPadding.All = 10;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(552, 609);
			this.panelLeft.TabIndex = 0;
			// 
			// tree
			// 
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.Location = new System.Drawing.Point(10, 10);
			this.tree.Name = "tree";
			this.tree.Root = null;
			this.tree.Size = new System.Drawing.Size(532, 589);
			this.tree.TabIndex = 0;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.panelRightUp);
			this.panelRight.Controls.Add(this.panelRightDown);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.DockPadding.Bottom = 10;
			this.panelRight.DockPadding.Right = 10;
			this.panelRight.DockPadding.Top = 10;
			this.panelRight.Location = new System.Drawing.Point(552, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(304, 609);
			this.panelRight.TabIndex = 1;
			// 
			// panelRightUp
			// 
			this.panelRightUp.Controls.Add(this.groupBoxControlInfo);
			this.panelRightUp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRightUp.DockPadding.All = 5;
			this.panelRightUp.Location = new System.Drawing.Point(0, 10);
			this.panelRightUp.Name = "panelRightUp";
			this.panelRightUp.Size = new System.Drawing.Size(294, 517);
			this.panelRightUp.TabIndex = 0;
			// 
			// groupBoxControlInfo
			// 
			this.groupBoxControlInfo.Controls.Add(this.panelInfo);
			this.groupBoxControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxControlInfo.Location = new System.Drawing.Point(5, 5);
			this.groupBoxControlInfo.Name = "groupBoxControlInfo";
			this.groupBoxControlInfo.Size = new System.Drawing.Size(284, 507);
			this.groupBoxControlInfo.TabIndex = 0;
			this.groupBoxControlInfo.TabStop = false;
			this.groupBoxControlInfo.Text = "Selected Node Information";
			// 
			// panelInfo
			// 
			this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new System.Drawing.Point(3, 16);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new System.Drawing.Size(278, 488);
			this.panelInfo.TabIndex = 0;
			// 
			// panelRightDown
			// 
			this.panelRightDown.Controls.Add(this.groupBoxProgressBar);
			this.panelRightDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelRightDown.DockPadding.Left = 5;
			this.panelRightDown.DockPadding.Right = 5;
			this.panelRightDown.DockPadding.Top = 5;
			this.panelRightDown.Location = new System.Drawing.Point(0, 527);
			this.panelRightDown.Name = "panelRightDown";
			this.panelRightDown.Size = new System.Drawing.Size(294, 72);
			this.panelRightDown.TabIndex = 1;
			// 
			// groupBoxProgressBar
			// 
			this.groupBoxProgressBar.Controls.Add(this.panelProgress);
			this.groupBoxProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxProgressBar.Location = new System.Drawing.Point(5, 5);
			this.groupBoxProgressBar.Name = "groupBoxProgressBar";
			this.groupBoxProgressBar.Size = new System.Drawing.Size(284, 67);
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
			this.panelProgress.Size = new System.Drawing.Size(278, 48);
			this.panelProgress.TabIndex = 0;
			// 
			// progressBar
			// 
			this.progressBar.BackColor = System.Drawing.SystemColors.Control;
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar.Location = new System.Drawing.Point(5, 27);
			this.progressBar.LowerBound = 0;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(268, 16);
			this.progressBar.TabIndex = 0;
			this.progressBar.UpperBound = 10;
			this.progressBar.Value = 0;
			// 
			// splitterLR
			// 
			this.splitterLR.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitterLR.Location = new System.Drawing.Point(544, 0);
			this.splitterLR.Name = "splitterLR";
			this.splitterLR.Size = new System.Drawing.Size(8, 609);
			this.splitterLR.TabIndex = 2;
			this.splitterLR.TabStop = false;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuInternal,
																					 this.menuInvestigations,
																					 this.menuHelp});
			// 
			// menuInternal
			// 
			this.menuInternal.Index = 0;
			this.menuInternal.Text = "Internal";
			// 
			// menuInvestigations
			// 
			this.menuInvestigations.Index = 1;
			this.menuInvestigations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.menuSystem,
																							   this.menuDelimeter,
																							   this.menuOpenDocument,
																							   this.menuSave});
			this.menuInvestigations.Text = "Investigations";
			// 
			// menuSystem
			// 
			this.menuSystem.Index = 0;
			this.menuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuSystemNew,
																					   this.menuSystemDelimiter1,
																					   this.menuFunctionShow,
																					   this.menuSystemAnalisys,
																					   this.menuSystemDelimiter2,
																					   this.menuSystemIterations,
																					   this.menuSystemDelimiter3,
																					   this.menuSystemComment});
			this.menuSystem.Text = "System";
			// 
			// menuSystemNew
			// 
			this.menuSystemNew.Index = 0;
			this.menuSystemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuSystemNew.Text = "New";
			this.menuSystemNew.Click += new System.EventHandler(this.menuSystemNew_Click);
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
			// menuSystemIterations
			// 
			this.menuSystemIterations.Index = 5;
			this.menuSystemIterations.Text = "Iterations";
			this.menuSystemIterations.Click += new System.EventHandler(this.menuSystemIterations_Click);
			// 
			// menuDelimeter
			// 
			this.menuDelimeter.Enabled = false;
			this.menuDelimeter.Index = 1;
			this.menuDelimeter.Text = "-";
			// 
			// menuOpenDocument
			// 
			this.menuOpenDocument.Index = 2;
			this.menuOpenDocument.Text = "Open";
			this.menuOpenDocument.Click += new System.EventHandler(this.menuOpenDocument_Click);
			// 
			// menuSave
			// 
			this.menuSave.Index = 3;
			this.menuSave.Text = "Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
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
			// saveDocumentDialog
			// 
			this.saveDocumentDialog.DefaultExt = "dsif";
			this.saveDocumentDialog.Filter = "Dynamical System Investigations Files|*.dsif|All files|*.*";
			this.saveDocumentDialog.Title = "Select file to save project";
			// 
			// openDocumentDialog
			// 
			this.openDocumentDialog.DefaultExt = "dsif";
			this.openDocumentDialog.Filter = "Dynamical System Investigations Files|*.dsif|All files|*.*";
			this.openDocumentDialog.Title = "Select System to open";
			// 
			// menuSystemDelimiter1
			// 
			this.menuSystemDelimiter1.Index = 1;
			this.menuSystemDelimiter1.Text = "-";
			// 
			// menuSystemDelimiter2
			// 
			this.menuSystemDelimiter2.Index = 4;
			this.menuSystemDelimiter2.Text = "-";
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
			// ComputationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 609);
			this.Controls.Add(this.splitterLR);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panelRight);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "ComputationForm";
			this.Text = "ComputationForm";
			this.panelLeft.ResumeLayout(false);
			this.panelRight.ResumeLayout(false);
			this.panelRightUp.ResumeLayout(false);
			this.groupBoxControlInfo.ResumeLayout(false);
			this.panelRightDown.ResumeLayout(false);
			this.groupBoxProgressBar.ResumeLayout(false);
			this.panelProgress.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void menuSystemNew_Click(object sender, System.EventArgs e)
		{
			SystemAssignment assignment = new SystemAssignment();
			if (assignment.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				Function function = assignment.Function;
				Logger.Logger.LogMessage(function.ToString());

				OpenNewDocument(new Document.Document(function));				
			}
		}

		public void OpenNewDocument(Document.Document document)
		{
			Runner.Runner.Instance.Document = document;
			tree.Root = document.RootNode;
			tree.Root.ExpandAll();
		}


		private ProgressBarInfo progressBarInfo;
		private ProgressBarNotificationAdapter progressBarAdapter;

		public ProgressBarInfo ProgressBar 
		{
			get
			{				
				return progressBarInfo;
			}
		}


		public void AcceptActionChain(Node node, Action[] chain)
		{
			ChainPerformer performer = new ChainPerformer(node, chain, ProgressBar);
			performer.Start += new ChainStart(performer_Start);
			performer.Finish += new ChainFinish(performer_Finish);
			performer.DoActionsWithDialog(this);
		}


		public void Lock()
		{
			this.Enabled = false;
			tree.Enabled = false;
		}

		public void Unlock()
		{
			this.Enabled = true;
			tree.Enabled = true;
		}


		public bool OnBeforeCheckChanged(ComputationNode computationNode)
		{
			if (computationNode is Node)
			{
				Node node = (Node)computationNode;
				try 
				{
					node.SelectionChanging();
					return false;
				} catch (GroupException e)
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

		private void MenuFunctionShowClick(object sender, System.EventArgs e)
		{
			if (Runner.Runner.Instance.Document != null)
			{
				SystemAssignment assignment = new SystemAssignment(Runner.Runner.Instance.Document.KernelDocument.Function);
				assignment.ShowDialog(this);
			}
		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			new About().ShowDialog();
		}

		private void menuSave_Click(object sender, System.EventArgs e)
		{
			if (Runner.Runner.Instance.Document == null) return;

			if (saveDocumentDialog.ShowDialog( this) == System.Windows.Forms.DialogResult.OK)
			{
				try 
				{
					string filename = saveDocumentDialog.FileName;

					string pathbase = Path.GetDirectoryName(filename);

					XmlNode xml = DocumentSerializer.SaveDocument(Runner.Runner.Instance.Document, pathbase);

					XmlDocument document = XmlUtil.CreateEmptyDocument();
					XmlUtil.SetRootNode(document, xml);

					using( TextWriter file = File.CreateText(filename))
					{
						document.Save(file);
					}
				} catch (SerializationException ee)
				{
					MessageBox.Show(this, "Failed to save file: " + ee.Message);
				    Logger.Logger.LogException(ee);
				}
			}
		}

		private void menuOpenDocument_Click(object sender, System.EventArgs e)
		{
			if (openDocumentDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				string filename = openDocumentDialog.FileName;
				string pathbase = Path.GetDirectoryName(filename);

				XmlDocument doc = new XmlDocument();
				doc.Load(filename);

				OpenNewDocument(DocumentSerializer.LoadDocument(doc, pathbase));
			}
		}

		private void menuSystemAnalisys_Click(object sender, System.EventArgs e)
		{
			SystemFunctionAnalisys.ShowAnalisys();
			
		}

		private void menuSystemIterations_Click(object sender, System.EventArgs e)
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

		private void menuSystemComment_Click(object sender, System.EventArgs e)
		{
			Document.Document doc = Runner.Runner.Instance.Document;
			if ( doc != null) 
			{							
				UserComment comment = new UserComment(doc.KernelDocument.Title);
				if (comment.ShowDialog(this) == DialogResult.OK) 
				{
					doc.KernelDocument.Title = comment.UserCommentText;
				}
			}
		}
	}
}
