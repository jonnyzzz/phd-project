using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

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
		private guiControls.TreeControl.ComputationTree computationTree1;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
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
			this.computationTree1 = new guiControls.TreeControl.ComputationTree();
			this.panelRight = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.panelLeft.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.computationTree1);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeft.DockPadding.All = 10;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(552, 609);
			this.panelLeft.TabIndex = 0;
			// 
			// computationTree1
			// 
			this.computationTree1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.computationTree1.Location = new System.Drawing.Point(10, 10);
			this.computationTree1.Name = "computationTree1";
			this.computationTree1.Root = null;
			this.computationTree1.Size = new System.Drawing.Size(532, 589);
			this.computationTree1.TabIndex = 0;
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
																					 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Internal";
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
	}
}
