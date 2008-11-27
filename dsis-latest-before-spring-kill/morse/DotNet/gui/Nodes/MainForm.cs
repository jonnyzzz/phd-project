using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using MorseKernelATL;


namespace gui
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItemSystem;
		private System.Windows.Forms.MenuItem menuItemNew;
		private System.Windows.Forms.MenuItem menuItemSystemOpen;
		private System.Windows.Forms.TreeView computationTree;
		private System.Windows.Forms.ImageList imageList;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.GroupBox infoBox;
		private System.Windows.Forms.GroupBox spaceBox;
		private System.Windows.Forms.Label label_3;
		private System.Windows.Forms.Label label_2;
		private System.Windows.Forms.Label label_1;
		private System.Windows.Forms.Label label_4;
		private System.Windows.Forms.Label label_5;
		private System.Windows.Forms.Label label_6;
		private System.Windows.Forms.MenuItem menuItemMultipleSelection;
		private System.Windows.Forms.MenuItem menuItemSingleSelection;
		private System.Windows.Forms.MenuItem menuItemSymbolicImage;
		private System.Windows.Forms.MenuItem menuItemProjectiveBundle;
		private System.Windows.Forms.MenuItem menuItemMorseSpectrum;
		private System.Windows.Forms.MenuItem menuItemMultiSymbolicImage;
		private System.Windows.Forms.MenuItem menuItemMultiProjectiveBundle;
		private System.Windows.Forms.MenuItem menuItemMultiMorseSpectrum;
		private System.Windows.Forms.TextBox labelComponentName;
		private System.Windows.Forms.TextBox labelNodes;
		private System.Windows.Forms.TextBox labelEdges;
		private System.Windows.Forms.TextBox labelSpace;
		private System.Windows.Forms.TextBox labelGridSize;
		private System.Windows.Forms.TextBox labelGridNumber;

		private CKernel kernel = Runner.Instance.Kernel;

		private ComputationNodeSymbolicImageGroup symbolicImageGroup = null;
		private System.Windows.Forms.MenuItem menuItemAutomation;
		private System.Windows.Forms.MenuItem menuItemAutomationCheck;
		private ComputationNodeProjectiveBundleGroup projectiveBundleGroup = null;


		private ComputationNodeProjectiveBundleGroup ProjectiveBundleGroup
		{
			get 
			{           	
				if (projectiveBundleGroup == null) 
				{
					projectiveBundleGroup = new ComputationNodeProjectiveBundleGroup();
					projectiveBundleGroup.actionEvent += new ComputationNodeGroupActionPerformedEventHandler(projectiveBundleGroup_actionEvent);
				}
				return projectiveBundleGroup;
			}
		}

		private void projectiveBundleGroup_actionEvent()
		{
			projectiveBundleGroup = null;
		}


		private ComputationNodeSymbolicImageGroup SymbolicImageGroup 
		{
			get 
			{
				if (symbolicImageGroup == null) 
				{
					symbolicImageGroup = new ComputationNodeSymbolicImageGroup();
					symbolicImageGroup.actionEvent += new ComputationNodeGroupActionPerformedEventHandler(symbolicImageGroup_actionEvent);
				}					
				return symbolicImageGroup;
			}
		}

		private void symbolicImageGroup_actionEvent()
		{
			symbolicImageGroup = null;
		}


		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Console.Out.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!WORKS!");


			computationTree_MouseLeave(this, EventArgs.Empty);
			setNodeInfoEmpty();
			setNodeMenu(null);

			ComputationNode.DefaultCheckedState = menuItemAutomationCheck.Checked;
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItemSystem = new System.Windows.Forms.MenuItem();
			this.menuItemNew = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemSystemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemSingleSelection = new System.Windows.Forms.MenuItem();
			this.menuItemSymbolicImage = new System.Windows.Forms.MenuItem();
			this.menuItemProjectiveBundle = new System.Windows.Forms.MenuItem();
			this.menuItemMorseSpectrum = new System.Windows.Forms.MenuItem();
			this.menuItemMultipleSelection = new System.Windows.Forms.MenuItem();
			this.menuItemMultiSymbolicImage = new System.Windows.Forms.MenuItem();
			this.menuItemMultiProjectiveBundle = new System.Windows.Forms.MenuItem();
			this.menuItemMultiMorseSpectrum = new System.Windows.Forms.MenuItem();
			this.computationTree = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.infoBox = new System.Windows.Forms.GroupBox();
			this.labelEdges = new System.Windows.Forms.TextBox();
			this.labelNodes = new System.Windows.Forms.TextBox();
			this.labelComponentName = new System.Windows.Forms.TextBox();
			this.label_3 = new System.Windows.Forms.Label();
			this.label_2 = new System.Windows.Forms.Label();
			this.label_1 = new System.Windows.Forms.Label();
			this.spaceBox = new System.Windows.Forms.GroupBox();
			this.labelGridNumber = new System.Windows.Forms.TextBox();
			this.labelGridSize = new System.Windows.Forms.TextBox();
			this.labelSpace = new System.Windows.Forms.TextBox();
			this.label_4 = new System.Windows.Forms.Label();
			this.label_5 = new System.Windows.Forms.Label();
			this.label_6 = new System.Windows.Forms.Label();
			this.menuItemAutomation = new System.Windows.Forms.MenuItem();
			this.menuItemAutomationCheck = new System.Windows.Forms.MenuItem();
			this.infoBox.SuspendLayout();
			this.spaceBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItemSystem,
																					 this.menuItemSingleSelection,
																					 this.menuItemMultipleSelection,
																					 this.menuItemAutomation});
			// 
			// menuItemSystem
			// 
			this.menuItemSystem.Index = 0;
			this.menuItemSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuItemNew,
																						   this.menuItem2,
																						   this.menuItemSystemOpen});
			this.menuItemSystem.Text = "Equation";
			// 
			// menuItemNew
			// 
			this.menuItemNew.Index = 0;
			this.menuItemNew.Text = "Assign system";
			this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItemSystemOpen
			// 
			this.menuItemSystemOpen.Index = 2;
			this.menuItemSystemOpen.Text = "Load system";
			this.menuItemSystemOpen.Click += new System.EventHandler(this.menuItemSystemOpen_Click);
			// 
			// menuItemSingleSelection
			// 
			this.menuItemSingleSelection.Index = 1;
			this.menuItemSingleSelection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									this.menuItemSymbolicImage,
																									this.menuItemProjectiveBundle,
																									this.menuItemMorseSpectrum});
			this.menuItemSingleSelection.Text = "Single Selection";
			// 
			// menuItemSymbolicImage
			// 
			this.menuItemSymbolicImage.Enabled = false;
			this.menuItemSymbolicImage.Index = 0;
			this.menuItemSymbolicImage.Text = "Symbolic Image";
			// 
			// menuItemProjectiveBundle
			// 
			this.menuItemProjectiveBundle.Enabled = false;
			this.menuItemProjectiveBundle.Index = 1;
			this.menuItemProjectiveBundle.Text = "Extended Symbolic Image";
			// 
			// menuItemMorseSpectrum
			// 
			this.menuItemMorseSpectrum.Enabled = false;
			this.menuItemMorseSpectrum.Index = 2;
			this.menuItemMorseSpectrum.Text = "Morse Spectrum Estimation";
			// 
			// menuItemMultipleSelection
			// 
			this.menuItemMultipleSelection.Index = 2;
			this.menuItemMultipleSelection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									  this.menuItemMultiSymbolicImage,
																									  this.menuItemMultiProjectiveBundle,
																									  this.menuItemMultiMorseSpectrum});
			this.menuItemMultipleSelection.Text = "Multiple Selection";
			// 
			// menuItemMultiSymbolicImage
			// 
			this.menuItemMultiSymbolicImage.Enabled = false;
			this.menuItemMultiSymbolicImage.Index = 0;
			this.menuItemMultiSymbolicImage.Text = "Symbolic Image";
			// 
			// menuItemMultiProjectiveBundle
			// 
			this.menuItemMultiProjectiveBundle.Enabled = false;
			this.menuItemMultiProjectiveBundle.Index = 1;
			this.menuItemMultiProjectiveBundle.Text = "Extended Symbolic Image";
			// 
			// menuItemMultiMorseSpectrum
			// 
			this.menuItemMultiMorseSpectrum.Enabled = false;
			this.menuItemMultiMorseSpectrum.Index = 2;
			this.menuItemMultiMorseSpectrum.Text = "Morse Spectrum Estimation";
			// 
			// computationTree
			// 
			this.computationTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.computationTree.CheckBoxes = true;
			this.computationTree.ImageList = this.imageList;
			this.computationTree.Location = new System.Drawing.Point(8, 16);
			this.computationTree.Name = "computationTree";
			this.computationTree.Size = new System.Drawing.Size(456, 368);
			this.computationTree.TabIndex = 0;
			this.computationTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.computationTree_MouseDown);
			this.computationTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.computationTree_AfterCheck);
			this.computationTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.computationTree_MouseMove);
			this.computationTree.MouseLeave += new System.EventHandler(this.computationTree_MouseLeave);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// infoBox
			// 
			this.infoBox.Controls.Add(this.labelEdges);
			this.infoBox.Controls.Add(this.labelNodes);
			this.infoBox.Controls.Add(this.labelComponentName);
			this.infoBox.Controls.Add(this.label_3);
			this.infoBox.Controls.Add(this.label_2);
			this.infoBox.Controls.Add(this.label_1);
			this.infoBox.Location = new System.Drawing.Point(472, 16);
			this.infoBox.Name = "infoBox";
			this.infoBox.Size = new System.Drawing.Size(288, 184);
			this.infoBox.TabIndex = 1;
			this.infoBox.TabStop = false;
			this.infoBox.Text = "Info";
			// 
			// labelEdges
			// 
			this.labelEdges.AcceptsTab = true;
			this.labelEdges.BackColor = System.Drawing.SystemColors.Control;
			this.labelEdges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelEdges.HideSelection = false;
			this.labelEdges.Location = new System.Drawing.Point(8, 128);
			this.labelEdges.Name = "labelEdges";
			this.labelEdges.ReadOnly = true;
			this.labelEdges.Size = new System.Drawing.Size(272, 20);
			this.labelEdges.TabIndex = 9;
			this.labelEdges.Text = "textBox1";
			// 
			// labelNodes
			// 
			this.labelNodes.AcceptsTab = true;
			this.labelNodes.BackColor = System.Drawing.SystemColors.Control;
			this.labelNodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelNodes.HideSelection = false;
			this.labelNodes.Location = new System.Drawing.Point(8, 80);
			this.labelNodes.Name = "labelNodes";
			this.labelNodes.ReadOnly = true;
			this.labelNodes.Size = new System.Drawing.Size(272, 20);
			this.labelNodes.TabIndex = 8;
			this.labelNodes.Text = "textBox1";
			// 
			// labelComponentName
			// 
			this.labelComponentName.AcceptsTab = true;
			this.labelComponentName.BackColor = System.Drawing.SystemColors.Control;
			this.labelComponentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelComponentName.HideSelection = false;
			this.labelComponentName.Location = new System.Drawing.Point(8, 40);
			this.labelComponentName.Name = "labelComponentName";
			this.labelComponentName.ReadOnly = true;
			this.labelComponentName.Size = new System.Drawing.Size(272, 20);
			this.labelComponentName.TabIndex = 7;
			this.labelComponentName.Text = "textBox1";
			// 
			// label_3
			// 
			this.label_3.Location = new System.Drawing.Point(8, 104);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(128, 16);
			this.label_3.TabIndex = 2;
			this.label_3.Text = "Edges";
			// 
			// label_2
			// 
			this.label_2.Location = new System.Drawing.Point(8, 64);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(128, 16);
			this.label_2.TabIndex = 1;
			this.label_2.Text = "Nodes";
			// 
			// label_1
			// 
			this.label_1.Location = new System.Drawing.Point(8, 24);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(128, 16);
			this.label_1.TabIndex = 0;
			this.label_1.Text = "Component Name";
			// 
			// spaceBox
			// 
			this.spaceBox.Controls.Add(this.labelGridNumber);
			this.spaceBox.Controls.Add(this.labelGridSize);
			this.spaceBox.Controls.Add(this.labelSpace);
			this.spaceBox.Controls.Add(this.label_4);
			this.spaceBox.Controls.Add(this.label_5);
			this.spaceBox.Controls.Add(this.label_6);
			this.spaceBox.Location = new System.Drawing.Point(472, 208);
			this.spaceBox.Name = "spaceBox";
			this.spaceBox.Size = new System.Drawing.Size(288, 176);
			this.spaceBox.TabIndex = 2;
			this.spaceBox.TabStop = false;
			this.spaceBox.Text = "Space";
			// 
			// labelGridNumber
			// 
			this.labelGridNumber.AcceptsTab = true;
			this.labelGridNumber.BackColor = System.Drawing.SystemColors.Control;
			this.labelGridNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelGridNumber.HideSelection = false;
			this.labelGridNumber.Location = new System.Drawing.Point(8, 120);
			this.labelGridNumber.Name = "labelGridNumber";
			this.labelGridNumber.ReadOnly = true;
			this.labelGridNumber.Size = new System.Drawing.Size(272, 20);
			this.labelGridNumber.TabIndex = 12;
			this.labelGridNumber.Text = "textBox1";
			// 
			// labelGridSize
			// 
			this.labelGridSize.AcceptsTab = true;
			this.labelGridSize.BackColor = System.Drawing.SystemColors.Control;
			this.labelGridSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelGridSize.HideSelection = false;
			this.labelGridSize.Location = new System.Drawing.Point(8, 80);
			this.labelGridSize.Name = "labelGridSize";
			this.labelGridSize.ReadOnly = true;
			this.labelGridSize.Size = new System.Drawing.Size(272, 20);
			this.labelGridSize.TabIndex = 11;
			this.labelGridSize.Text = "textBox1";
			// 
			// labelSpace
			// 
			this.labelSpace.AcceptsTab = true;
			this.labelSpace.BackColor = System.Drawing.SystemColors.Control;
			this.labelSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelSpace.HideSelection = false;
			this.labelSpace.Location = new System.Drawing.Point(8, 40);
			this.labelSpace.Name = "labelSpace";
			this.labelSpace.ReadOnly = true;
			this.labelSpace.Size = new System.Drawing.Size(272, 20);
			this.labelSpace.TabIndex = 10;
			this.labelSpace.Text = "textBox1";
			// 
			// label_4
			// 
			this.label_4.Location = new System.Drawing.Point(8, 104);
			this.label_4.Name = "label_4";
			this.label_4.Size = new System.Drawing.Size(128, 16);
			this.label_4.TabIndex = 2;
			this.label_4.Text = "Grid number";
			// 
			// label_5
			// 
			this.label_5.Location = new System.Drawing.Point(8, 64);
			this.label_5.Name = "label_5";
			this.label_5.Size = new System.Drawing.Size(128, 16);
			this.label_5.TabIndex = 1;
			this.label_5.Text = "Grid size";
			// 
			// label_6
			// 
			this.label_6.Location = new System.Drawing.Point(8, 24);
			this.label_6.Name = "label_6";
			this.label_6.Size = new System.Drawing.Size(128, 16);
			this.label_6.TabIndex = 0;
			this.label_6.Text = "Space";
			// 
			// menuItemAutomation
			// 
			this.menuItemAutomation.Enabled = false;
			this.menuItemAutomation.Index = 3;
			this.menuItemAutomation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.menuItemAutomationCheck});
			this.menuItemAutomation.Text = "Automation";
			this.menuItemAutomation.Visible = false;
			// 
			// menuItemAutomationCheck
			// 
			this.menuItemAutomationCheck.Index = 0;
			this.menuItemAutomationCheck.Text = "Auto check newly added nodes";
			this.menuItemAutomationCheck.Click += new System.EventHandler(this.menuItemAutomationCheck_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(770, 395);
			this.Controls.Add(this.spaceBox);
			this.Controls.Add(this.infoBox);
			this.Controls.Add(this.computationTree);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.infoBox.ResumeLayout(false);
			this.spaceBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void showSystemAssignmentDialog(SystemAssignment sas) 
		{			
			Console.Out.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!WORKS!");

			if (sas.ShowDialog(this) == DialogResult.OK) 
			{
				kernel.Function = sas.getFunction();
				CSymbolicImageGraph g = (CSymbolicImageGraph) kernel.CreateRootSymbolicImage();

				Console.Out.WriteLine("g.getType() = {0}", g.GetType());
				Console.Out.WriteLine(
					(g is IGraph) + " " +
					(g is ISubdevidable) + " " +
					(g is ISubdevidablePoint) + " " + 
					(g is IExtendable) + (g is IMorsable)
					);


				addRootNode(new ComputationNodeSymbolicImage(g));
			}			
		}


		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			showSystemAssignmentDialog(new SystemAssignment());			
		}


		private void addRootNode(TreeNode rootNode) 
		{
			computationTree.Nodes.Clear();
			computationTree.Nodes.Add(rootNode);
		}

		private void computationTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeNode node = computationTree.GetNodeAt(e.X, e.Y);
			if (node is ComputationNode && e.Button == MouseButtons.Right) 
			{
				Console.WriteLine("NodeText : {0}", node.Text);

				ComputationNode cnode = node as ComputationNode;

				ContextMenu cm = new ContextMenu();

				appendMenuItems(cm.MenuItems, updateNodeMenu(cnode));
								
				cm.Show(computationTree, new Point(e.X, e.Y));
			}
		}

		private void menuItemSystemOpen_Click(object sender, System.EventArgs e)
		{
			showSystemAssignmentDialog(new SystemAssignment(true));
		}

		private bool hasInfo(TreeNode node) 
		{
			return node is ComputationNode;
		}

		private void computationTree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (hasInfo(computationTree.SelectedNode)) 
			{
				setInfo(computationTree.SelectedNode);
			} 
			else 
			{
				TreeNode node = computationTree.GetNodeAt(e.X, e.Y);
				setInfo(node);
			}
		}

		private void computationTree_MouseLeave(object sender, System.EventArgs e)
		{
			setInfo(computationTree.SelectedNode);
		}


		private const string INFO_EMPTY = "";

		private TreeNode currentNode = null;

		private void setInfo(TreeNode node) 
		{
			if (currentNode != node) 
			{
				currentNode = node;
				if (hasInfo(node)) 
				{
					setNodeInfo(node as ComputationNode);
					setNodeMenu(node as ComputationNode);
				} 
				else 
				{
					setNodeInfoEmpty();
					setNodeMenu(null);
				}
			}
		}

		private void setNodeInfo(ComputationNode node) 
		{
			labelComponentName.Text = node.getInfoName();
			labelNodes.Text = node.getInfoNodes();
			labelEdges.Text = node.getInfoEdges();
            
			labelSpace.Text = node.getInfoSpace();
			labelGridSize.Text = node.getInfoGridSize();
			labelGridNumber.Text = node.getInfoGridNumber();
		}

		private void setNodeInfoEmpty() 
		{
			labelComponentName.Text = INFO_EMPTY;
			labelNodes.Text = INFO_EMPTY;
			labelEdges.Text = INFO_EMPTY;

			labelSpace.Text = INFO_EMPTY;
			labelGridSize.Text = INFO_EMPTY;
			labelGridNumber.Text = INFO_EMPTY;
		}

		private void appendMenuItems(Menu.MenuItemCollection col, IEnumerator items) 
		{
			col.Clear();
			for (items.Reset(); items.MoveNext(); col.Add(items.Current as MenuItem));
		}

		private void setNodeMenu(ComputationNode node) 
		{					
			if (node is ComputationNodeSymbolicImage) 
			{
				IEnumerator action = node.getActions();
				appendMenuItems(menuItemSymbolicImage.MenuItems, action);
				menuItemSymbolicImage.Enabled = true;
				menuItemMorseSpectrum.Enabled = false;
				menuItemProjectiveBundle.Enabled = false;

			} 
			else if (node is ComputationNodeProjectiveBundle) 
			{
				IEnumerator action = node.getActions();
				appendMenuItems(menuItemProjectiveBundle.MenuItems, action);
				menuItemProjectiveBundle.Enabled = true;
				menuItemMorseSpectrum.Enabled = false;
				menuItemSymbolicImage.Enabled = false;

			} 
			else if (node is ComputationNodeMorseSpectrum) 
			{
				IEnumerator action = node.getActions();
				appendMenuItems(menuItemProjectiveBundle.MenuItems, action);
				menuItemMorseSpectrum.Enabled = true;
				menuItemProjectiveBundle.Enabled = false;
				menuItemSymbolicImage.Enabled = false;
			} 
			else 
			{
				menuItemMorseSpectrum.Enabled = false;
				menuItemProjectiveBundle.Enabled = false;
				menuItemSymbolicImage.Enabled = false;
			}
		}

		private IEnumerator updateNodeMenu(ComputationNode node) 
		{
			if (node == null) return new ArrayList().GetEnumerator();

			if (node is ComputationNodeProjectiveBundle && node.Checked) 
			{
				ArrayList al = new ArrayList();
				al.Add(new ComputationNode.Delimiter());
				al.AddRange (menuItemMultiProjectiveBundle.MenuItems);
				return ComputationNode.merge(node.getActions(), al.GetEnumerator());
			} 
			else if (node is ComputationNodeSymbolicImage && node.Checked) 
			{
				ArrayList al = new ArrayList();
				al.Add(new ComputationNode.Delimiter());
				al.AddRange (menuItemMultiSymbolicImage.MenuItems);
				return ComputationNode.merge(node.getActions(), al.GetEnumerator());
			} 
			else return node.getActions();
		}



		private void computationTree_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node is ComputationNodeSymbolicImage) 
			{
				if (SymbolicImageGroup.updateNode(e.Node as ComputationNode)) 
				{
					appendMenuItems(menuItemMultiSymbolicImage.MenuItems, (SymbolicImageGroup.getActions()));					
					menuItemMultiMorseSpectrum.Enabled = false;
					menuItemMultiProjectiveBundle.Enabled = false;
					menuItemMultiSymbolicImage.Enabled = SymbolicImageGroup.menuEnabled;
				}
			} 
			else if (e.Node is ComputationNodeProjectiveBundle) 
			{
				if (ProjectiveBundleGroup.updateNode(e.Node as ComputationNode))
				{
					appendMenuItems(menuItemMultiProjectiveBundle.MenuItems, (ProjectiveBundleGroup.getActions()));					
					menuItemMultiMorseSpectrum.Enabled = false;
					menuItemMultiProjectiveBundle.Enabled = ProjectiveBundleGroup.menuEnabled;
					menuItemMultiSymbolicImage.Enabled = false;
				}			
			}
			else if (e.Node.Checked == true) 
			{
				MessageBox.Show("Unable to add such node to group");
				e.Node.Checked = false;
			}
		}

		private void menuItemAutomationCheck_Click(object sender, System.EventArgs e)
		{
			menuItemAutomationCheck.Checked = !menuItemAutomationCheck.Checked;
			ComputationNode.DefaultCheckedState = menuItemAutomationCheck.Checked;
		}
	}
}
