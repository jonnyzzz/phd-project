using System;
using System.Windows.Forms;
using gui.Visualization.GnuPlot;
using gui.Tree.Node;
using gui.Tree.Node.Forms;
using MorseKernelATL;

namespace gui.Forms
{
	/// <summary>
	/// Summary description for ComputationForm.
	/// </summary>
	public class ComputationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuAssign;
		private System.Windows.Forms.MenuItem menuLoad;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuSystem;
		private System.Windows.Forms.MenuItem menuStatic;
		private Tree.ComputationTree computatioinTree;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.MenuItem menuSelection;
		private System.Windows.Forms.MenuItem menuDeselectAll;
		private System.Windows.Forms.Label label1;
		private AxMSComctlLib.AxProgressBar axProgressBar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panelRightDownInternal;
		private System.Windows.Forms.Panel panelRightDown;
		private System.Windows.Forms.Panel panelRightUp;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Splitter splitterUD;
		private System.Windows.Forms.Splitter splitterLR;
		private System.Windows.Forms.MenuItem menuItemInternal;
		private System.Windows.Forms.MenuItem menuItemGC;
        private System.Windows.Forms.MenuItem menuItemStartGNUPlot;
		private System.ComponentModel.IContainer components;

		public void updateProgressBar(int min, int max, int current)
		{
			axProgressBar1.Min = min;
			axProgressBar1.Max = max;
			axProgressBar1.Value = current;
		}

		public ComputationForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();					
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ComputationForm));
            this.computatioinTree = new gui.Tree.ComputationTree();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuSystem = new System.Windows.Forms.MenuItem();
            this.menuAssign = new System.Windows.Forms.MenuItem();
            this.menuLoad = new System.Windows.Forms.MenuItem();
            this.menuStatic = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuSelection = new System.Windows.Forms.MenuItem();
            this.menuDeselectAll = new System.Windows.Forms.MenuItem();
            this.menuItemInternal = new System.Windows.Forms.MenuItem();
            this.menuItemGC = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axProgressBar1 = new AxMSComctlLib.AxProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelRightDownInternal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelRightDown = new System.Windows.Forms.Panel();
            this.panelRightUp = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.splitterUD = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.splitterLR = new System.Windows.Forms.Splitter();
            this.menuItemStartGNUPlot = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axProgressBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelRightDownInternal.SuspendLayout();
            this.panelRightDown.SuspendLayout();
            this.panelRightUp.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // computatioinTree
            // 
            this.computatioinTree.AccessibleDescription = resources.GetString("computatioinTree.AccessibleDescription");
            this.computatioinTree.AccessibleName = resources.GetString("computatioinTree.AccessibleName");
            this.computatioinTree.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("computatioinTree.Anchor")));
            this.computatioinTree.AutoScroll = ((bool)(resources.GetObject("computatioinTree.AutoScroll")));
            this.computatioinTree.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("computatioinTree.AutoScrollMargin")));
            this.computatioinTree.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("computatioinTree.AutoScrollMinSize")));
            this.computatioinTree.BackColor = System.Drawing.SystemColors.Highlight;
            this.computatioinTree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("computatioinTree.BackgroundImage")));
            this.computatioinTree.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("computatioinTree.Dock")));
            this.computatioinTree.Enabled = ((bool)(resources.GetObject("computatioinTree.Enabled")));
            this.computatioinTree.Font = ((System.Drawing.Font)(resources.GetObject("computatioinTree.Font")));
            this.computatioinTree.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("computatioinTree.ImeMode")));
            this.computatioinTree.Location = ((System.Drawing.Point)(resources.GetObject("computatioinTree.Location")));
            this.computatioinTree.Name = "computatioinTree";
            this.computatioinTree.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("computatioinTree.RightToLeft")));
            this.computatioinTree.Root = null;
            this.computatioinTree.Size = ((System.Drawing.Size)(resources.GetObject("computatioinTree.Size")));
            this.computatioinTree.TabIndex = ((int)(resources.GetObject("computatioinTree.TabIndex")));
            this.computatioinTree.Visible = ((bool)(resources.GetObject("computatioinTree.Visible")));
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuSystem,
                                                                                     this.menuSelection,
                                                                                     this.menuItemInternal});
            this.mainMenu.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mainMenu.RightToLeft")));
            // 
            // menuSystem
            // 
            this.menuSystem.Enabled = ((bool)(resources.GetObject("menuSystem.Enabled")));
            this.menuSystem.Index = 0;
            this.menuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                       this.menuAssign,
                                                                                       this.menuLoad,
                                                                                       this.menuStatic,
                                                                                       this.menuExit});
            this.menuSystem.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuSystem.Shortcut")));
            this.menuSystem.ShowShortcut = ((bool)(resources.GetObject("menuSystem.ShowShortcut")));
            this.menuSystem.Text = resources.GetString("menuSystem.Text");
            this.menuSystem.Visible = ((bool)(resources.GetObject("menuSystem.Visible")));
            // 
            // menuAssign
            // 
            this.menuAssign.Enabled = ((bool)(resources.GetObject("menuAssign.Enabled")));
            this.menuAssign.Index = 0;
            this.menuAssign.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuAssign.Shortcut")));
            this.menuAssign.ShowShortcut = ((bool)(resources.GetObject("menuAssign.ShowShortcut")));
            this.menuAssign.Text = resources.GetString("menuAssign.Text");
            this.menuAssign.Visible = ((bool)(resources.GetObject("menuAssign.Visible")));
            this.menuAssign.Click += new System.EventHandler(this.menuAssign_Click);
            // 
            // menuLoad
            // 
            this.menuLoad.Enabled = ((bool)(resources.GetObject("menuLoad.Enabled")));
            this.menuLoad.Index = 1;
            this.menuLoad.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuLoad.Shortcut")));
            this.menuLoad.ShowShortcut = ((bool)(resources.GetObject("menuLoad.ShowShortcut")));
            this.menuLoad.Text = resources.GetString("menuLoad.Text");
            this.menuLoad.Visible = ((bool)(resources.GetObject("menuLoad.Visible")));
            // 
            // menuStatic
            // 
            this.menuStatic.Enabled = ((bool)(resources.GetObject("menuStatic.Enabled")));
            this.menuStatic.Index = 2;
            this.menuStatic.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuStatic.Shortcut")));
            this.menuStatic.ShowShortcut = ((bool)(resources.GetObject("menuStatic.ShowShortcut")));
            this.menuStatic.Text = resources.GetString("menuStatic.Text");
            this.menuStatic.Visible = ((bool)(resources.GetObject("menuStatic.Visible")));
            // 
            // menuExit
            // 
            this.menuExit.Enabled = ((bool)(resources.GetObject("menuExit.Enabled")));
            this.menuExit.Index = 3;
            this.menuExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuExit.Shortcut")));
            this.menuExit.ShowShortcut = ((bool)(resources.GetObject("menuExit.ShowShortcut")));
            this.menuExit.Text = resources.GetString("menuExit.Text");
            this.menuExit.Visible = ((bool)(resources.GetObject("menuExit.Visible")));
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuSelection
            // 
            this.menuSelection.Enabled = ((bool)(resources.GetObject("menuSelection.Enabled")));
            this.menuSelection.Index = 1;
            this.menuSelection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                          this.menuDeselectAll});
            this.menuSelection.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuSelection.Shortcut")));
            this.menuSelection.ShowShortcut = ((bool)(resources.GetObject("menuSelection.ShowShortcut")));
            this.menuSelection.Text = resources.GetString("menuSelection.Text");
            this.menuSelection.Visible = ((bool)(resources.GetObject("menuSelection.Visible")));
            // 
            // menuDeselectAll
            // 
            this.menuDeselectAll.Enabled = ((bool)(resources.GetObject("menuDeselectAll.Enabled")));
            this.menuDeselectAll.Index = 0;
            this.menuDeselectAll.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuDeselectAll.Shortcut")));
            this.menuDeselectAll.ShowShortcut = ((bool)(resources.GetObject("menuDeselectAll.ShowShortcut")));
            this.menuDeselectAll.Text = resources.GetString("menuDeselectAll.Text");
            this.menuDeselectAll.Visible = ((bool)(resources.GetObject("menuDeselectAll.Visible")));
            this.menuDeselectAll.Click += new System.EventHandler(this.menuDeselectAll_Click);
            // 
            // menuItemInternal
            // 
            this.menuItemInternal.Enabled = ((bool)(resources.GetObject("menuItemInternal.Enabled")));
            this.menuItemInternal.Index = 2;
            this.menuItemInternal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                             this.menuItemGC,
                                                                                             this.menuItemStartGNUPlot});
            this.menuItemInternal.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemInternal.Shortcut")));
            this.menuItemInternal.ShowShortcut = ((bool)(resources.GetObject("menuItemInternal.ShowShortcut")));
            this.menuItemInternal.Text = resources.GetString("menuItemInternal.Text");
            this.menuItemInternal.Visible = ((bool)(resources.GetObject("menuItemInternal.Visible")));
            // 
            // menuItemGC
            // 
            this.menuItemGC.Enabled = ((bool)(resources.GetObject("menuItemGC.Enabled")));
            this.menuItemGC.Index = 0;
            this.menuItemGC.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemGC.Shortcut")));
            this.menuItemGC.ShowShortcut = ((bool)(resources.GetObject("menuItemGC.ShowShortcut")));
            this.menuItemGC.Text = resources.GetString("menuItemGC.Text");
            this.menuItemGC.Visible = ((bool)(resources.GetObject("menuItemGC.Visible")));
            this.menuItemGC.Click += new System.EventHandler(this.menuItemGC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
            this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
            this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
            this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
            this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
            this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
            this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
            this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = resources.GetString("groupBox1.Text");
            this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
            // 
            // axProgressBar1
            // 
            this.axProgressBar1.AccessibleDescription = resources.GetString("axProgressBar1.AccessibleDescription");
            this.axProgressBar1.AccessibleName = resources.GetString("axProgressBar1.AccessibleName");
            this.axProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("axProgressBar1.Anchor")));
            this.axProgressBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("axProgressBar1.BackgroundImage")));
            this.axProgressBar1.ContainingControl = this;
            this.axProgressBar1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("axProgressBar1.Dock")));
            this.axProgressBar1.Font = ((System.Drawing.Font)(resources.GetObject("axProgressBar1.Font")));
            this.axProgressBar1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("axProgressBar1.ImeMode")));
            this.axProgressBar1.Location = ((System.Drawing.Point)(resources.GetObject("axProgressBar1.Location")));
            this.axProgressBar1.Name = "axProgressBar1";
            this.axProgressBar1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axProgressBar1.OcxState")));
            this.axProgressBar1.RightToLeft = ((bool)(resources.GetObject("axProgressBar1.RightToLeft")));
            this.axProgressBar1.Size = ((System.Drawing.Size)(resources.GetObject("axProgressBar1.Size")));
            this.axProgressBar1.TabIndex = ((int)(resources.GetObject("axProgressBar1.TabIndex")));
            this.axProgressBar1.Text = resources.GetString("axProgressBar1.Text");
            this.axProgressBar1.Visible = ((bool)(resources.GetObject("axProgressBar1.Visible")));
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = resources.GetString("groupBox2.AccessibleDescription");
            this.groupBox2.AccessibleName = resources.GetString("groupBox2.AccessibleName");
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.panelRightDownInternal);
            this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
            this.groupBox2.Enabled = ((bool)(resources.GetObject("groupBox2.Enabled")));
            this.groupBox2.Font = ((System.Drawing.Font)(resources.GetObject("groupBox2.Font")));
            this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
            this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
            this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
            this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = resources.GetString("groupBox2.Text");
            this.groupBox2.Visible = ((bool)(resources.GetObject("groupBox2.Visible")));
            // 
            // panelRightDownInternal
            // 
            this.panelRightDownInternal.AccessibleDescription = resources.GetString("panelRightDownInternal.AccessibleDescription");
            this.panelRightDownInternal.AccessibleName = resources.GetString("panelRightDownInternal.AccessibleName");
            this.panelRightDownInternal.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelRightDownInternal.Anchor")));
            this.panelRightDownInternal.AutoScroll = ((bool)(resources.GetObject("panelRightDownInternal.AutoScroll")));
            this.panelRightDownInternal.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelRightDownInternal.AutoScrollMargin")));
            this.panelRightDownInternal.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelRightDownInternal.AutoScrollMinSize")));
            this.panelRightDownInternal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRightDownInternal.BackgroundImage")));
            this.panelRightDownInternal.Controls.Add(this.label1);
            this.panelRightDownInternal.Controls.Add(this.axProgressBar1);
            this.panelRightDownInternal.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelRightDownInternal.Dock")));
            this.panelRightDownInternal.DockPadding.All = 5;
            this.panelRightDownInternal.Enabled = ((bool)(resources.GetObject("panelRightDownInternal.Enabled")));
            this.panelRightDownInternal.Font = ((System.Drawing.Font)(resources.GetObject("panelRightDownInternal.Font")));
            this.panelRightDownInternal.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelRightDownInternal.ImeMode")));
            this.panelRightDownInternal.Location = ((System.Drawing.Point)(resources.GetObject("panelRightDownInternal.Location")));
            this.panelRightDownInternal.Name = "panelRightDownInternal";
            this.panelRightDownInternal.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelRightDownInternal.RightToLeft")));
            this.panelRightDownInternal.Size = ((System.Drawing.Size)(resources.GetObject("panelRightDownInternal.Size")));
            this.panelRightDownInternal.TabIndex = ((int)(resources.GetObject("panelRightDownInternal.TabIndex")));
            this.panelRightDownInternal.Text = resources.GetString("panelRightDownInternal.Text");
            this.panelRightDownInternal.Visible = ((bool)(resources.GetObject("panelRightDownInternal.Visible")));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
            this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
            this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
            this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
            this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
            this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
            this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
            this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
            this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
            this.label1.Name = "label1";
            this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
            this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
            this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
            this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = ((System.Drawing.Size)(resources.GetObject("imageList1.ImageSize")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelRightDown
            // 
            this.panelRightDown.AccessibleDescription = resources.GetString("panelRightDown.AccessibleDescription");
            this.panelRightDown.AccessibleName = resources.GetString("panelRightDown.AccessibleName");
            this.panelRightDown.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelRightDown.Anchor")));
            this.panelRightDown.AutoScroll = ((bool)(resources.GetObject("panelRightDown.AutoScroll")));
            this.panelRightDown.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelRightDown.AutoScrollMargin")));
            this.panelRightDown.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelRightDown.AutoScrollMinSize")));
            this.panelRightDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRightDown.BackgroundImage")));
            this.panelRightDown.Controls.Add(this.groupBox2);
            this.panelRightDown.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelRightDown.Dock")));
            this.panelRightDown.DockPadding.All = 10;
            this.panelRightDown.Enabled = ((bool)(resources.GetObject("panelRightDown.Enabled")));
            this.panelRightDown.Font = ((System.Drawing.Font)(resources.GetObject("panelRightDown.Font")));
            this.panelRightDown.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelRightDown.ImeMode")));
            this.panelRightDown.Location = ((System.Drawing.Point)(resources.GetObject("panelRightDown.Location")));
            this.panelRightDown.Name = "panelRightDown";
            this.panelRightDown.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelRightDown.RightToLeft")));
            this.panelRightDown.Size = ((System.Drawing.Size)(resources.GetObject("panelRightDown.Size")));
            this.panelRightDown.TabIndex = ((int)(resources.GetObject("panelRightDown.TabIndex")));
            this.panelRightDown.Text = resources.GetString("panelRightDown.Text");
            this.panelRightDown.Visible = ((bool)(resources.GetObject("panelRightDown.Visible")));
            // 
            // panelRightUp
            // 
            this.panelRightUp.AccessibleDescription = resources.GetString("panelRightUp.AccessibleDescription");
            this.panelRightUp.AccessibleName = resources.GetString("panelRightUp.AccessibleName");
            this.panelRightUp.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelRightUp.Anchor")));
            this.panelRightUp.AutoScroll = ((bool)(resources.GetObject("panelRightUp.AutoScroll")));
            this.panelRightUp.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelRightUp.AutoScrollMargin")));
            this.panelRightUp.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelRightUp.AutoScrollMinSize")));
            this.panelRightUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRightUp.BackgroundImage")));
            this.panelRightUp.Controls.Add(this.groupBox1);
            this.panelRightUp.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelRightUp.Dock")));
            this.panelRightUp.DockPadding.All = 10;
            this.panelRightUp.Enabled = ((bool)(resources.GetObject("panelRightUp.Enabled")));
            this.panelRightUp.Font = ((System.Drawing.Font)(resources.GetObject("panelRightUp.Font")));
            this.panelRightUp.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelRightUp.ImeMode")));
            this.panelRightUp.Location = ((System.Drawing.Point)(resources.GetObject("panelRightUp.Location")));
            this.panelRightUp.Name = "panelRightUp";
            this.panelRightUp.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelRightUp.RightToLeft")));
            this.panelRightUp.Size = ((System.Drawing.Size)(resources.GetObject("panelRightUp.Size")));
            this.panelRightUp.TabIndex = ((int)(resources.GetObject("panelRightUp.TabIndex")));
            this.panelRightUp.Text = resources.GetString("panelRightUp.Text");
            this.panelRightUp.Visible = ((bool)(resources.GetObject("panelRightUp.Visible")));
            // 
            // panelRight
            // 
            this.panelRight.AccessibleDescription = resources.GetString("panelRight.AccessibleDescription");
            this.panelRight.AccessibleName = resources.GetString("panelRight.AccessibleName");
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelRight.Anchor")));
            this.panelRight.AutoScroll = ((bool)(resources.GetObject("panelRight.AutoScroll")));
            this.panelRight.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelRight.AutoScrollMargin")));
            this.panelRight.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelRight.AutoScrollMinSize")));
            this.panelRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelRight.BackgroundImage")));
            this.panelRight.Controls.Add(this.splitterUD);
            this.panelRight.Controls.Add(this.panelRightUp);
            this.panelRight.Controls.Add(this.panelRightDown);
            this.panelRight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelRight.Dock")));
            this.panelRight.DockPadding.All = 3;
            this.panelRight.Enabled = ((bool)(resources.GetObject("panelRight.Enabled")));
            this.panelRight.Font = ((System.Drawing.Font)(resources.GetObject("panelRight.Font")));
            this.panelRight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelRight.ImeMode")));
            this.panelRight.Location = ((System.Drawing.Point)(resources.GetObject("panelRight.Location")));
            this.panelRight.Name = "panelRight";
            this.panelRight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelRight.RightToLeft")));
            this.panelRight.Size = ((System.Drawing.Size)(resources.GetObject("panelRight.Size")));
            this.panelRight.TabIndex = ((int)(resources.GetObject("panelRight.TabIndex")));
            this.panelRight.Text = resources.GetString("panelRight.Text");
            this.panelRight.Visible = ((bool)(resources.GetObject("panelRight.Visible")));
            // 
            // splitterUD
            // 
            this.splitterUD.AccessibleDescription = resources.GetString("splitterUD.AccessibleDescription");
            this.splitterUD.AccessibleName = resources.GetString("splitterUD.AccessibleName");
            this.splitterUD.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("splitterUD.Anchor")));
            this.splitterUD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitterUD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitterUD.BackgroundImage")));
            this.splitterUD.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("splitterUD.Dock")));
            this.splitterUD.Enabled = ((bool)(resources.GetObject("splitterUD.Enabled")));
            this.splitterUD.Font = ((System.Drawing.Font)(resources.GetObject("splitterUD.Font")));
            this.splitterUD.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitterUD.ImeMode")));
            this.splitterUD.Location = ((System.Drawing.Point)(resources.GetObject("splitterUD.Location")));
            this.splitterUD.MinExtra = ((int)(resources.GetObject("splitterUD.MinExtra")));
            this.splitterUD.MinSize = ((int)(resources.GetObject("splitterUD.MinSize")));
            this.splitterUD.Name = "splitterUD";
            this.splitterUD.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitterUD.RightToLeft")));
            this.splitterUD.Size = ((System.Drawing.Size)(resources.GetObject("splitterUD.Size")));
            this.splitterUD.TabIndex = ((int)(resources.GetObject("splitterUD.TabIndex")));
            this.splitterUD.TabStop = false;
            this.splitterUD.Visible = ((bool)(resources.GetObject("splitterUD.Visible")));
            // 
            // panelLeft
            // 
            this.panelLeft.AccessibleDescription = resources.GetString("panelLeft.AccessibleDescription");
            this.panelLeft.AccessibleName = resources.GetString("panelLeft.AccessibleName");
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panelLeft.Anchor")));
            this.panelLeft.AutoScroll = ((bool)(resources.GetObject("panelLeft.AutoScroll")));
            this.panelLeft.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panelLeft.AutoScrollMargin")));
            this.panelLeft.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panelLeft.AutoScrollMinSize")));
            this.panelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLeft.BackgroundImage")));
            this.panelLeft.Controls.Add(this.computatioinTree);
            this.panelLeft.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panelLeft.Dock")));
            this.panelLeft.DockPadding.All = 10;
            this.panelLeft.Enabled = ((bool)(resources.GetObject("panelLeft.Enabled")));
            this.panelLeft.Font = ((System.Drawing.Font)(resources.GetObject("panelLeft.Font")));
            this.panelLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panelLeft.ImeMode")));
            this.panelLeft.Location = ((System.Drawing.Point)(resources.GetObject("panelLeft.Location")));
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panelLeft.RightToLeft")));
            this.panelLeft.Size = ((System.Drawing.Size)(resources.GetObject("panelLeft.Size")));
            this.panelLeft.TabIndex = ((int)(resources.GetObject("panelLeft.TabIndex")));
            this.panelLeft.Text = resources.GetString("panelLeft.Text");
            this.panelLeft.Visible = ((bool)(resources.GetObject("panelLeft.Visible")));
            // 
            // splitterLR
            // 
            this.splitterLR.AccessibleDescription = resources.GetString("splitterLR.AccessibleDescription");
            this.splitterLR.AccessibleName = resources.GetString("splitterLR.AccessibleName");
            this.splitterLR.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("splitterLR.Anchor")));
            this.splitterLR.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitterLR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitterLR.BackgroundImage")));
            this.splitterLR.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("splitterLR.Dock")));
            this.splitterLR.Enabled = ((bool)(resources.GetObject("splitterLR.Enabled")));
            this.splitterLR.Font = ((System.Drawing.Font)(resources.GetObject("splitterLR.Font")));
            this.splitterLR.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("splitterLR.ImeMode")));
            this.splitterLR.Location = ((System.Drawing.Point)(resources.GetObject("splitterLR.Location")));
            this.splitterLR.MinExtra = ((int)(resources.GetObject("splitterLR.MinExtra")));
            this.splitterLR.MinSize = ((int)(resources.GetObject("splitterLR.MinSize")));
            this.splitterLR.Name = "splitterLR";
            this.splitterLR.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("splitterLR.RightToLeft")));
            this.splitterLR.Size = ((System.Drawing.Size)(resources.GetObject("splitterLR.Size")));
            this.splitterLR.TabIndex = ((int)(resources.GetObject("splitterLR.TabIndex")));
            this.splitterLR.TabStop = false;
            this.splitterLR.Visible = ((bool)(resources.GetObject("splitterLR.Visible")));
            // 
            // menuItemStartGNUPlot
            // 
            this.menuItemStartGNUPlot.Enabled = ((bool)(resources.GetObject("menuItemStartGNUPlot.Enabled")));
            this.menuItemStartGNUPlot.Index = 1;
            this.menuItemStartGNUPlot.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemStartGNUPlot.Shortcut")));
            this.menuItemStartGNUPlot.ShowShortcut = ((bool)(resources.GetObject("menuItemStartGNUPlot.ShowShortcut")));
            this.menuItemStartGNUPlot.Text = resources.GetString("menuItemStartGNUPlot.Text");
            this.menuItemStartGNUPlot.Visible = ((bool)(resources.GetObject("menuItemStartGNUPlot.Visible")));
            this.menuItemStartGNUPlot.Click += new System.EventHandler(this.menuItemStartGNUPlot_Click);
            // 
            // ComputationForm
            // 
            this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
            this.AccessibleName = resources.GetString("$this.AccessibleName");
            this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
            this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
            this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
            this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
            this.Controls.Add(this.splitterLR);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
            this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
            this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
            this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
            this.Menu = this.mainMenu;
            this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
            this.Name = "ComputationForm";
            this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
            this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
            this.Text = resources.GetString("$this.Text");
            ((System.ComponentModel.ISupportInitialize)(this.axProgressBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelRightDownInternal.ResumeLayout(false);
            this.panelRightDown.ResumeLayout(false);
            this.panelRightUp.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		#region external control functions
		public void asColse()
		{
			this.Close();
		}
		#endregion

		private void menuAssign_Click(object sender, System.EventArgs e)
		{			
		    SystemAssignment assign = new SystemAssignment();
			if (assign.ShowDialog(this) == DialogResult.OK)
			{
				Console.Out.WriteLine("Runner.Kernel.Function = {0}", Runner.Kernel.Function == null);
                Runner.Kernel.Function = assign.getFunction();

				IKernelNode root = Runner.Kernel.CreateRootSymbolicImage();
				computatioinTree.Root = ComputationNode.createComputationNode(root);
			}
		}

		private void menuDeselectAll_Click(object sender, System.EventArgs e)
		{
			computatioinTree.DeselectAll();
		}

		private void menuItemGC_Click(object sender, System.EventArgs e)
		{
			System.GC.Collect(System.GC.MaxGeneration);			
		}

        public void OnNewNode(IKernelNode parent, IKernelNode child)
        {
            ComputationNode node = computatioinTree.findNodeByKernelNode(parent);
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

        private void menuItemStartGNUPlot_Click(object sender, System.EventArgs e)
        {
        }

	}
}
