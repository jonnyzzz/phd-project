using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using gui.Panels;
using gui.ProgressBar;
using gui.Serialization;
using gui.Tree;
using gui.Tree.Node;
using gui.Tree.Node.Forms;
using gui.Visualization.GnuPlot;
using MorseKernelATL;

namespace gui.Forms
{
	/// <summary>
	/// Summary description for ComputationForm.
	/// </summary>
	public class ComputationForm : Form
	{
		private MenuItem menuAssign;
		private MenuItem menuLoad;
		private MainMenu mainMenu;
		private MenuItem menuExit;
		private MenuItem menuSystem;
		private MenuItem menuStatic;
		private ComputationTree computatioinTree;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private MenuItem menuSelection;
		private MenuItem menuDeselectAll;
		private Label label1;
		private ImageList imageList1;
		private Panel panelRightDownInternal;
		private Panel panelRightDown;
		private Panel panelRightUp;
		private Panel panelRight;
		private Panel panelLeft;
		private Splitter splitterUD;
		private Splitter splitterLR;
		private MenuItem menuItemInternal;
		private MenuItem menuItemGC;
		private MenuItem menuItemStartGNUPlot;
		private Panel panelNodeInfo;
		private MenuItem menuItemShowSystemFunction;
		private MenuItem menuItemHelp;
		private MenuItem menuItemAbout;
		private System.Windows.Forms.MenuItem menuItemInvestigations;
		private System.Windows.Forms.MenuItem menuItemInvLoad;
		private System.Windows.Forms.MenuItem menuItemInvSave;
		private System.Windows.Forms.MenuItem menuItemDeselectGroup;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private gui.ProgressBar.SmartProgressBar smartProgressBar;
		private System.Windows.Forms.Panel panelProgressBarBorder;
		private IContainer components;

		public void updateProgressBar(int min, int max, int current)
		{
			Application.DoEvents();
		}

		public ComputationForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.computatioinTree.MouseMoveNode += new MouseMoveComponentEvent(computatioinTree_MouseMoveNode);
			this.menuItemInternal.Visible = Runner.IsInternal;
			//this.menuItemInvestigations.Visible = Runner.IsInternal;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ComputationForm));
			this.computatioinTree = new gui.Tree.ComputationTree();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItemInvestigations = new System.Windows.Forms.MenuItem();
			this.menuSystem = new System.Windows.Forms.MenuItem();
			this.menuAssign = new System.Windows.Forms.MenuItem();
			this.menuLoad = new System.Windows.Forms.MenuItem();
			this.menuStatic = new System.Windows.Forms.MenuItem();
			this.menuItemShowSystemFunction = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemInvLoad = new System.Windows.Forms.MenuItem();
			this.menuItemInvSave = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuSelection = new System.Windows.Forms.MenuItem();
			this.menuDeselectAll = new System.Windows.Forms.MenuItem();
			this.menuItemDeselectGroup = new System.Windows.Forms.MenuItem();
			this.menuItemInternal = new System.Windows.Forms.MenuItem();
			this.menuItemGC = new System.Windows.Forms.MenuItem();
			this.menuItemStartGNUPlot = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItemAbout = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelNodeInfo = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panelRightDownInternal = new System.Windows.Forms.Panel();
			this.smartProgressBar = new gui.ProgressBar.SmartProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panelRightDown = new System.Windows.Forms.Panel();
			this.panelRightUp = new System.Windows.Forms.Panel();
			this.panelRight = new System.Windows.Forms.Panel();
			this.splitterUD = new System.Windows.Forms.Splitter();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.splitterLR = new System.Windows.Forms.Splitter();
			this.panelProgressBarBorder = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panelRightDownInternal.SuspendLayout();
			this.panelRightDown.SuspendLayout();
			this.panelRightUp.SuspendLayout();
			this.panelRight.SuspendLayout();
			this.panelLeft.SuspendLayout();
			this.panelProgressBarBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// computatioinTree
			// 
			this.computatioinTree.BackColor = System.Drawing.SystemColors.Highlight;
			this.computatioinTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.computatioinTree.Location = new System.Drawing.Point(10, 10);
			this.computatioinTree.Name = "computatioinTree";
			this.computatioinTree.Root = null;
			this.computatioinTree.Size = new System.Drawing.Size(342, 471);
			this.computatioinTree.TabIndex = 0;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItemInvestigations,
																					 this.menuSelection,
																					 this.menuItemInternal,
																					 this.menuItemHelp});
			// 
			// menuItemInvestigations
			// 
			this.menuItemInvestigations.Index = 0;
			this.menuItemInvestigations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								   this.menuSystem,
																								   this.menuItem2,
																								   this.menuItemInvLoad,
																								   this.menuItemInvSave,
																								   this.menuItem1,
																								   this.menuExit});
			this.menuItemInvestigations.Text = "Investigations";
			// 
			// menuSystem
			// 
			this.menuSystem.Index = 0;
			this.menuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuAssign,
																					   this.menuLoad,
																					   this.menuStatic,
																					   this.menuItemShowSystemFunction});
			this.menuSystem.Text = "System";
			// 
			// menuAssign
			// 
			this.menuAssign.Index = 0;
			this.menuAssign.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuAssign.Text = "New";
			this.menuAssign.Click += new System.EventHandler(this.menuAssign_Click);
			// 
			// menuLoad
			// 
			this.menuLoad.Index = 1;
			this.menuLoad.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
			this.menuLoad.Text = "Open";
			this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
			// 
			// menuStatic
			// 
			this.menuStatic.Enabled = false;
			this.menuStatic.Index = 2;
			this.menuStatic.Text = "-";
			// 
			// menuItemShowSystemFunction
			// 
			this.menuItemShowSystemFunction.Enabled = false;
			this.menuItemShowSystemFunction.Index = 3;
			this.menuItemShowSystemFunction.Text = "ShowSystemFunction";
			this.menuItemShowSystemFunction.Click += new System.EventHandler(this.menuItemShowSystemFunction_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItemInvLoad
			// 
			this.menuItemInvLoad.Index = 2;
			this.menuItemInvLoad.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItemInvLoad.Text = "Open";
			this.menuItemInvLoad.Click += new System.EventHandler(this.menuItemInvLoad_Click);
			// 
			// menuItemInvSave
			// 
			this.menuItemInvSave.Index = 3;
			this.menuItemInvSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItemInvSave.Text = "Save";
			this.menuItemInvSave.Click += new System.EventHandler(this.menuItemInvSave_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 5;
			this.menuExit.Text = "Exit\tALT+F4";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuSelection
			// 
			this.menuSelection.Index = 1;
			this.menuSelection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuDeselectAll,
																						  this.menuItemDeselectGroup});
			this.menuSelection.Text = "Selection";
			// 
			// menuDeselectAll
			// 
			this.menuDeselectAll.Index = 0;
			this.menuDeselectAll.Text = "Deselect All";
			this.menuDeselectAll.Click += new System.EventHandler(this.menuDeselectAll_Click);
			// 
			// menuItemDeselectGroup
			// 
			this.menuItemDeselectGroup.Index = 1;
			this.menuItemDeselectGroup.Text = "Deselect Group";
			this.menuItemDeselectGroup.Click += new System.EventHandler(this.menuItemDeselectGroup_Click);
			// 
			// menuItemInternal
			// 
			this.menuItemInternal.Index = 2;
			this.menuItemInternal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuItemGC,
																							 this.menuItemStartGNUPlot});
			this.menuItemInternal.Text = "Internal";
			// 
			// menuItemGC
			// 
			this.menuItemGC.Index = 0;
			this.menuItemGC.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.menuItemGC.Text = "Collect Garbage";
			this.menuItemGC.Click += new System.EventHandler(this.menuItemGC_Click);
			// 
			// menuItemStartGNUPlot
			// 
			this.menuItemStartGNUPlot.Index = 1;
			this.menuItemStartGNUPlot.Text = "Start GNU plot";
			this.menuItemStartGNUPlot.Click += new System.EventHandler(this.menuItemStartGNUPlot_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = 3;
			this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemAbout});
			this.menuItemHelp.Text = "Help";
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Index = 0;
			this.menuItemAbout.Text = "About";
			this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panelNodeInfo);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(366, 355);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Node Information";
			// 
			// panelNodeInfo
			// 
			this.panelNodeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelNodeInfo.DockPadding.All = 1;
			this.panelNodeInfo.Location = new System.Drawing.Point(3, 16);
			this.panelNodeInfo.Name = "panelNodeInfo";
			this.panelNodeInfo.Size = new System.Drawing.Size(360, 336);
			this.panelNodeInfo.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panelRightDownInternal);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(10, 10);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(366, 90);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Computation Informtion";
			// 
			// panelRightDownInternal
			// 
			this.panelRightDownInternal.Controls.Add(this.panelProgressBarBorder);
			this.panelRightDownInternal.Controls.Add(this.label1);
			this.panelRightDownInternal.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRightDownInternal.DockPadding.All = 5;
			this.panelRightDownInternal.Location = new System.Drawing.Point(3, 16);
			this.panelRightDownInternal.Name = "panelRightDownInternal";
			this.panelRightDownInternal.Size = new System.Drawing.Size(360, 72);
			this.panelRightDownInternal.TabIndex = 2;
			// 
			// smartProgressBar
			// 
			this.smartProgressBar.BackColor = System.Drawing.SystemColors.Control;
			this.smartProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.smartProgressBar.Location = new System.Drawing.Point(0, 0);
			this.smartProgressBar.LowerBound = 0;
			this.smartProgressBar.Name = "smartProgressBar";
			this.smartProgressBar.Size = new System.Drawing.Size(350, 16);
			this.smartProgressBar.TabIndex = 2;
			this.smartProgressBar.UpperBound = 1000;
			this.smartProgressBar.Value = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(350, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Computation Progress";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panelRightDown
			// 
			this.panelRightDown.AutoScroll = true;
			this.panelRightDown.Controls.Add(this.groupBox2);
			this.panelRightDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelRightDown.DockPadding.All = 10;
			this.panelRightDown.Location = new System.Drawing.Point(3, 378);
			this.panelRightDown.Name = "panelRightDown";
			this.panelRightDown.Size = new System.Drawing.Size(386, 110);
			this.panelRightDown.TabIndex = 5;
			// 
			// panelRightUp
			// 
			this.panelRightUp.Controls.Add(this.groupBox1);
			this.panelRightUp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRightUp.DockPadding.All = 10;
			this.panelRightUp.Location = new System.Drawing.Point(3, 3);
			this.panelRightUp.Name = "panelRightUp";
			this.panelRightUp.Size = new System.Drawing.Size(386, 375);
			this.panelRightUp.TabIndex = 4;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.splitterUD);
			this.panelRight.Controls.Add(this.panelRightUp);
			this.panelRight.Controls.Add(this.panelRightDown);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.DockPadding.All = 3;
			this.panelRight.Location = new System.Drawing.Point(362, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(392, 491);
			this.panelRight.TabIndex = 7;
			// 
			// splitterUD
			// 
			this.splitterUD.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitterUD.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitterUD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.splitterUD.Location = new System.Drawing.Point(3, 370);
			this.splitterUD.Name = "splitterUD";
			this.splitterUD.Size = new System.Drawing.Size(386, 8);
			this.splitterUD.TabIndex = 6;
			this.splitterUD.TabStop = false;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.computatioinTree);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeft.DockPadding.All = 10;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(362, 491);
			this.panelLeft.TabIndex = 8;
			// 
			// splitterLR
			// 
			this.splitterLR.BackColor = System.Drawing.SystemColors.ControlLight;
			this.splitterLR.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitterLR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.splitterLR.Location = new System.Drawing.Point(354, 0);
			this.splitterLR.Name = "splitterLR";
			this.splitterLR.Size = new System.Drawing.Size(8, 491);
			this.splitterLR.TabIndex = 9;
			this.splitterLR.TabStop = false;
			// 
			// panelProgressBarBorder
			// 
			this.panelProgressBarBorder.Controls.Add(this.smartProgressBar);
			this.panelProgressBarBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelProgressBarBorder.Location = new System.Drawing.Point(5, 47);
			this.panelProgressBarBorder.Name = "panelProgressBarBorder";
			this.panelProgressBarBorder.Size = new System.Drawing.Size(350, 20);
			this.panelProgressBarBorder.TabIndex = 3;
			// 
			// ComputationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(754, 491);
			this.Controls.Add(this.splitterLR);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panelRight);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "ComputationForm";
			this.Text = "Dynamic System Investigation Tool";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panelRightDownInternal.ResumeLayout(false);
			this.panelRightDown.ResumeLayout(false);
			this.panelRightUp.ResumeLayout(false);
			this.panelRight.ResumeLayout(false);
			this.panelLeft.ResumeLayout(false);
			this.panelProgressBarBorder.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void menuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#region external control functions

		public void asColse()
		{
			this.Close();
		}

		#endregion

		private void menuAssign_Click(object sender, EventArgs e)
		{
			SystemAssignment assign = new SystemAssignment();
			showSystemAssignmentDialog(assign);
		}

		private void showSystemAssignmentDialog(SystemAssignment assign)
		{
			if (assign.ShowDialog(this) == DialogResult.OK)
			{
				Console.Out.WriteLine("Runner.Kernel.Function = {0}", Runner.Kernel.function == null);
				Runner.Kernel.function = assign.getFunction();

				IKernelNode root = Runner.Kernel.CreateRootSymbolicImage();
				computatioinTree.Root = ComputationNode.createComputationNode(root);

				this.menuItemShowSystemFunction.Enabled = true;
			}
		}

		private void menuDeselectAll_Click(object sender, EventArgs e)
		{
			computatioinTree.DeselectAll();
		}

		private void menuItemGC_Click(object sender, EventArgs e)
		{
			GC.Collect(GC.MaxGeneration);
		}

		public ComputationNode findNodeByKernelNode( IKernelNode node)
		{
			return computatioinTree.findNodeByKernelNode(node);
		}

		public void OnNewNode(IKernelNode parent, IKernelNode child)
		{
			ComputationNode node = findNodeByKernelNode(parent);
			Console.Out.WriteLine("Found node: {0}", node.Text);
			node.newNode(child);
		}

		public void OnNewComputationResult(IKernelNode parent, IComputationResult result)
		{
			Console.Out.WriteLine("here!");

			ComputationNode node = computatioinTree.findNodeByKernelNode(parent);

			Console.Out.WriteLine("Found node: {0}", node.Text);

			GraphOperationSelector go = new GraphOperationSelector();
			if (go.ShowModal(null, node, result) == DialogResult.OK)
			{
				go.DoSelected();
			}
		}

		public void noChilds(IKernelNode node)
		{
			MessageBox.Show("No strongs components were found.", "Computation results");
		}

		public void noImplementation(IKernelNode node)
		{
			MessageBox.Show("No implementation for that action. Sorry,", "Computation results");
		}

		private void menuItemStartGNUPlot_Click(object sender, EventArgs e)
		{
			GnuPlotView.Run();
		}

		private void computatioinTree_MouseMoveNode(ComputationNode anode)
		{
			if (computatioinTree.Selected != null) 
			{
				anode = computatioinTree.Selected;
			} 
			ShowNodeInfo(anode);
		}

		private ComputationNode currentNodeForInfo = null;
		private void ShowNodeInfo(ComputationNode anode)
		{
			if (currentNodeForInfo == anode) return;

			currentNodeForInfo = anode;

			if (anode == null)
			{
				panelNodeInfo.Controls.Clear();
				return;
			}

			IKernelNode node = anode.Node;
			if (node is IGraph)
			{
				IGraph gnode = (IGraph)node;
				setInfoPanel( new GraphNodeInfo(gnode.graphInfo()) );					
			} else if (node is IMorseSpectrum)
			{
				IMorseSpectrum mnode = (IMorseSpectrum)node;
				setInfoPanel( new MorseNodeInfo(mnode));
					
			}
		}

		private void setInfoPanel(Control control)
		{
			panelNodeInfo.Controls.Clear();
			control.Dock = DockStyle.Fill;
			panelNodeInfo.Controls.Add(control);
		}

		private void menuItemShowSystemFunction_Click(object sender, EventArgs e)
		{
			showSystemAssignmentDialog(new SystemAssignment(Runner.Kernel.function.SystemSource));
		}

		private void menuLoad_Click(object sender, EventArgs e)
		{
			showSystemAssignmentDialog(new SystemAssignment(true));
		}

		private void menuItemAbout_Click(object sender, EventArgs e)
		{
			About a = new About();
			a.ShowDialog(this);
		}

		private void menuItemInvLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = "system";
			dialog.Filter = "Systems (*.system)|*.system|All Files (*.*)|*.*";

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				if (!dialog.CheckFileExists)
				{
					MessageBox.Show(this, "File not found", "Error");
					return;
				}
				String fileName = dialog.FileName;
				String path = Path.GetDirectoryName(fileName) + "\\";
				TextReader reader = File.OpenText(fileName);

				Document document = Document.LoadDocument(reader);
				reader.Close();

				Runner.Kernel.function = document.CreateSystemFunction();

				this.computatioinTree.Root = document.BuildComputationNodeTree(path);
			}
		}

		private void menuItemDeselectGroup_Click(object sender, System.EventArgs e)
		{
			ComputationNodePlural.getCurrentGroup().dehighlightChildrens();
		}

		private void menuItemInvSave_Click(object sender, System.EventArgs e)
		{
			if (this.RootNode == null)
			{
				MessageBox.Show(this, "There is no tree to save.");
				return;
			}

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.DefaultExt = "system";
			dialog.Filter = "Systems (*.system)|*.system|All Files (*.*)|*.*";
			dialog.OverwritePrompt = true;

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{				
				String path = Path.GetDirectoryName(dialog.FileName) + "\\";
				String fileName = Path.GetFileName(dialog.FileName);
				
				Document document = new Document();
				document.SystemSource = Runner.Kernel.function.SystemSource;
				document.BuildRootFromComputationNode(this.RootNode, fileName, path);			
				
				TextWriter writer = File.CreateText(path + fileName);

				Document.SaveDocument(document, writer);
				writer.Close();			
			}		
		}

		public ComputationNode RootNode
		{
			get
			{
				return this.computatioinTree.Root;
			}
		}

		public IProgressBarNotification ProgressBarNotification
		{
			get
			{
				ProgressBarNotificationAdapter adapter = new ProgressBarNotificationAdapter(this.smartProgressBar);
				adapter.OnStart += new gui.ProgressBar.ProgressBarNotificationAdapter.OnStartDelegate(DisableMyControls);
				adapter.OnFinish +=new gui.ProgressBar.ProgressBarNotificationAdapter.OnFinishDelegate(EnableMyControls);

				return adapter;
			}
		}


		protected void DisableMyControls(ProgressBarNotificationAdapter adapter)
		{
			adapter.OnStart -= new gui.ProgressBar.ProgressBarNotificationAdapter.OnStartDelegate(DisableMyControls);
			this.Enabled = false;
		}

		protected void EnableMyControls(ProgressBarNotificationAdapter adapter)
		{
			adapter.OnFinish -= new gui.ProgressBar.ProgressBarNotificationAdapter.OnFinishDelegate(EnableMyControls);
			this.Enabled = true;
		}
	}
}