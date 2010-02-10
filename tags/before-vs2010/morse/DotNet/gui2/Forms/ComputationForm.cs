using gui2.ActionPerformer;
using gui2.TreeNodes;
using guiActions.Actions;
using guiKernel2.Actions;
using guiKernel2.Document;

namespace gui2.Forms
{
	/// <summary>
	/// Summary description for ComputationForm.
	/// </summary>
	public class ComputationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Splitter splitter1;
		private guiControls.TreeControl.ComputationTree tree;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuInvestigations;
		private System.Windows.Forms.MenuItem menuSystem;
		private System.Windows.Forms.MenuItem menuSystemNew;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComputationForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.panelLeft = new System.Windows.Forms.Panel();
			this.tree = new guiControls.TreeControl.ComputationTree();
			this.panelRight = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuInvestigations = new System.Windows.Forms.MenuItem();
			this.menuSystem = new System.Windows.Forms.MenuItem();
			this.menuSystemNew = new System.Windows.Forms.MenuItem();
			this.panelLeft.SuspendLayout();
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
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.DockPadding.All = 10;
			this.panelRight.Location = new System.Drawing.Point(552, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(304, 609);
			this.panelRight.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(544, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 609);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuInvestigations});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Internal";
			// 
			// menuInvestigations
			// 
			this.menuInvestigations.Index = 1;
			this.menuInvestigations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.menuSystem});
			this.menuInvestigations.Text = "Investigations";
			// 
			// menuSystem
			// 
			this.menuSystem.Index = 0;
			this.menuSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuSystemNew});
			this.menuSystem.Text = "System";
			// 
			// menuSystemNew
			// 
			this.menuSystemNew.Index = 0;
			this.menuSystemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuSystemNew.Text = "New";
			this.menuSystemNew.Click += new System.EventHandler(this.menuSystemNew_Click);
			// 
			// ComputationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 609);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panelRight);
			this.Menu = this.mainMenu;
			this.Name = "ComputationForm";
			this.Text = "ComputationForm";
			this.panelLeft.ResumeLayout(false);
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

				Runner.Runner.Instance.Document = new Document.Document(function);

				tree.Root = Runner.Runner.Instance.Document.RootNode;

			}
		}

		private ProgressBarInfo progressBarInfo = new ProgressBarInfo();
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
			performer.DoActionsWithDialog(this);
		}
	}
}
