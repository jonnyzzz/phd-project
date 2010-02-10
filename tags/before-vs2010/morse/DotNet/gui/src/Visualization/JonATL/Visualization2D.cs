using System;
using System.ComponentModel;
using System.Windows.Forms;
using AxMorseKernelVisualizationATL;

namespace gui.Visualization.JonATL
{
	/// <summary>
	/// Summary description for Visualization.
	/// </summary>
	public class Visualization2D : Form
	{
		private Button buttonUP;
		private Button buttonDown;
		private Button buttonOut;
		private Button buttonIn;
		private Button buttonLeft;
		private Button buttonRight;
		private Button buttonCenter;
		private Label label1;
		private AxCMorseKernelVisualizationDirectGraph2D d3d;
		private Button buttonTest;
		private Label label2;
		private StatusBar statusBar1;
		private StatusBarPanel statusBarPanel1;
		private Panel panelRight;
		private Panel panelRightUp;
		private Panel panelRightDown;
		private Panel panel1;
		private Panel panel2;
		private Panel panelDown;
		private Panel panel4;
		private Panel panel5;
		private Panel panel6;
		private Panel panel7;
		private Panel panel8;
		private Panel panel9;
		private Panel panel10;
		private Panel panelD3D;
		private Panel panelCenterBorder;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public Visualization2D()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			d3d.ActiveLoop += new _IMorseKernelVisualizationDirect3DEvents_ActiveLoopEventHandler(d3d_ActiveLoop);
			d3d.OnMouseMoveFloat += new _IMorseKernelVisualizationDirect3DEvents_OnMouseMoveFloatEventHandler(d3d_OnMouseMoveFloat);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			d3d.ActiveLoop -= new _IMorseKernelVisualizationDirect3DEvents_ActiveLoopEventHandler(d3d_ActiveLoop);
			d3d.OnMouseMoveFloat -= new _IMorseKernelVisualizationDirect3DEvents_OnMouseMoveFloatEventHandler(d3d_OnMouseMoveFloat);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (Visualization2D));
			this.buttonUP = new System.Windows.Forms.Button();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonOut = new System.Windows.Forms.Button();
			this.buttonIn = new System.Windows.Forms.Button();
			this.buttonLeft = new System.Windows.Forms.Button();
			this.buttonRight = new System.Windows.Forms.Button();
			this.buttonCenter = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.d3d = new AxMorseKernelVisualizationATL.AxCMorseKernelVisualizationDirectGraph2D();
			this.buttonTest = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.panelRight = new System.Windows.Forms.Panel();
			this.panelRightUp = new System.Windows.Forms.Panel();
			this.panelRightDown = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelDown = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panelD3D = new System.Windows.Forms.Panel();
			this.panelCenterBorder = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize) (this.d3d)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.statusBarPanel1)).BeginInit();
			this.panelRight.SuspendLayout();
			this.panelRightUp.SuspendLayout();
			this.panelRightDown.SuspendLayout();
			this.panelDown.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panelD3D.SuspendLayout();
			this.panelCenterBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonUP
			// 
			this.buttonUP.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonUP.Location = new System.Drawing.Point(10, 10);
			this.buttonUP.Name = "buttonUP";
			this.buttonUP.Size = new System.Drawing.Size(44, 40);
			this.buttonUP.TabIndex = 1;
			this.buttonUP.Text = "Up";
			this.buttonUP.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonDown
			// 
			this.buttonDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDown.Location = new System.Drawing.Point(10, 62);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(44, 40);
			this.buttonDown.TabIndex = 2;
			this.buttonDown.Text = "Down";
			this.buttonDown.Click += new System.EventHandler(this.button2_Click);
			// 
			// buttonOut
			// 
			this.buttonOut.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOut.Location = new System.Drawing.Point(10, 62);
			this.buttonOut.Name = "buttonOut";
			this.buttonOut.Size = new System.Drawing.Size(44, 40);
			this.buttonOut.TabIndex = 3;
			this.buttonOut.Text = "Out";
			this.buttonOut.Click += new System.EventHandler(this.button3_Click);
			// 
			// buttonIn
			// 
			this.buttonIn.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonIn.Location = new System.Drawing.Point(10, 10);
			this.buttonIn.Name = "buttonIn";
			this.buttonIn.Size = new System.Drawing.Size(44, 40);
			this.buttonIn.TabIndex = 4;
			this.buttonIn.Text = "In";
			this.buttonIn.Click += new System.EventHandler(this.button4_Click);
			// 
			// buttonLeft
			// 
			this.buttonLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLeft.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonLeft.Location = new System.Drawing.Point(10, 10);
			this.buttonLeft.Name = "buttonLeft";
			this.buttonLeft.Size = new System.Drawing.Size(40, 20);
			this.buttonLeft.TabIndex = 5;
			this.buttonLeft.Text = "Left";
			this.buttonLeft.Click += new System.EventHandler(this.button5_Click);
			// 
			// buttonRight
			// 
			this.buttonRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRight.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRight.Location = new System.Drawing.Point(62, 10);
			this.buttonRight.Name = "buttonRight";
			this.buttonRight.Size = new System.Drawing.Size(48, 20);
			this.buttonRight.TabIndex = 6;
			this.buttonRight.Text = "Right";
			this.buttonRight.Click += new System.EventHandler(this.button6_Click);
			// 
			// buttonCenter
			// 
			this.buttonCenter.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCenter.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonCenter.Location = new System.Drawing.Point(6, 10);
			this.buttonCenter.Name = "buttonCenter";
			this.buttonCenter.Size = new System.Drawing.Size(64, 20);
			this.buttonCenter.TabIndex = 7;
			this.buttonCenter.Text = "Center";
			this.buttonCenter.Click += new System.EventHandler(this.button7_Click);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(366, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "label1";
			// 
			// d3d
			// 
			this.d3d.ContainingControl = this;
			this.d3d.Dock = System.Windows.Forms.DockStyle.Fill;
			this.d3d.Enabled = true;
			this.d3d.Location = new System.Drawing.Point(0, 0);
			this.d3d.Name = "d3d";
			this.d3d.OcxState = ((System.Windows.Forms.AxHost.State) (resources.GetObject("d3d.OcxState")));
			this.d3d.Size = new System.Drawing.Size(626, 512);
			this.d3d.TabIndex = 0;
			// 
			// buttonTest
			// 
			this.buttonTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTest.Location = new System.Drawing.Point(10, 10);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new System.Drawing.Size(44, 40);
			this.buttonTest.TabIndex = 9;
			this.buttonTest.Text = "test";
			this.buttonTest.Click += new System.EventHandler(this.button8_Click);
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.label2.Location = new System.Drawing.Point(5, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(366, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "label2";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 574);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[]
				{
					this.statusBarPanel1
				});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(712, 16);
			this.statusBar1.TabIndex = 11;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.statusBarPanel1.Text = "statusBarPanel1";
			this.statusBarPanel1.Width = 696;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.panel8);
			this.panelRight.Controls.Add(this.panel9);
			this.panelRight.Controls.Add(this.panelRightDown);
			this.panelRight.Controls.Add(this.panelRightUp);
			this.panelRight.Controls.Add(this.panel1);
			this.panelRight.Controls.Add(this.panel2);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.Location = new System.Drawing.Point(648, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(64, 574);
			this.panelRight.TabIndex = 12;
			// 
			// panelRightUp
			// 
			this.panelRightUp.Controls.Add(this.buttonDown);
			this.panelRightUp.Controls.Add(this.buttonUP);
			this.panelRightUp.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRightUp.DockPadding.All = 10;
			this.panelRightUp.Location = new System.Drawing.Point(0, 72);
			this.panelRightUp.Name = "panelRightUp";
			this.panelRightUp.Size = new System.Drawing.Size(64, 112);
			this.panelRightUp.TabIndex = 0;
			// 
			// panelRightDown
			// 
			this.panelRightDown.Controls.Add(this.buttonOut);
			this.panelRightDown.Controls.Add(this.buttonIn);
			this.panelRightDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelRightDown.DockPadding.All = 10;
			this.panelRightDown.Location = new System.Drawing.Point(0, 374);
			this.panelRightDown.Name = "panelRightDown";
			this.panelRightDown.Size = new System.Drawing.Size(64, 112);
			this.panelRightDown.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 486);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(64, 88);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(64, 72);
			this.panel2.TabIndex = 2;
			// 
			// panelDown
			// 
			this.panelDown.Controls.Add(this.panel10);
			this.panelDown.Controls.Add(this.panel7);
			this.panelDown.Controls.Add(this.panel6);
			this.panelDown.Controls.Add(this.panel4);
			this.panelDown.Controls.Add(this.panel5);
			this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelDown.Location = new System.Drawing.Point(0, 534);
			this.panelDown.Name = "panelDown";
			this.panelDown.Size = new System.Drawing.Size(648, 40);
			this.panelDown.TabIndex = 13;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.buttonLeft);
			this.panel4.Controls.Add(this.buttonRight);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.DockPadding.All = 10;
			this.panel4.Location = new System.Drawing.Point(48, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(120, 40);
			this.panel4.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(48, 40);
			this.panel5.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel6.Location = new System.Drawing.Point(624, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(24, 40);
			this.panel6.TabIndex = 2;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.buttonCenter);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel7.DockPadding.All = 10;
			this.panel7.Location = new System.Drawing.Point(544, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(80, 40);
			this.panel7.TabIndex = 3;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.buttonTest);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.DockPadding.All = 10;
			this.panel8.Location = new System.Drawing.Point(0, 192);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(64, 56);
			this.panel8.TabIndex = 10;
			// 
			// panel9
			// 
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 184);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(64, 8);
			this.panel9.TabIndex = 11;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.label1);
			this.panel10.Controls.Add(this.label2);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel10.DockPadding.All = 5;
			this.panel10.Location = new System.Drawing.Point(168, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(376, 40);
			this.panel10.TabIndex = 14;
			// 
			// panelD3D
			// 
			this.panelD3D.Controls.Add(this.panelCenterBorder);
			this.panelD3D.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelD3D.DockPadding.All = 10;
			this.panelD3D.Location = new System.Drawing.Point(0, 0);
			this.panelD3D.Name = "panelD3D";
			this.panelD3D.Size = new System.Drawing.Size(648, 534);
			this.panelD3D.TabIndex = 14;
			// 
			// panelCenterBorder
			// 
			this.panelCenterBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCenterBorder.Controls.Add(this.d3d);
			this.panelCenterBorder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCenterBorder.Location = new System.Drawing.Point(10, 10);
			this.panelCenterBorder.Name = "panelCenterBorder";
			this.panelCenterBorder.Size = new System.Drawing.Size(628, 514);
			this.panelCenterBorder.TabIndex = 1;
			// 
			// Visualization2D
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(4, 11);
			this.ClientSize = new System.Drawing.Size(712, 590);
			this.Controls.Add(this.panelD3D);
			this.Controls.Add(this.panelDown);
			this.Controls.Add(this.panelRight);
			this.Controls.Add(this.statusBar1);
			this.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.Name = "Visualization2D";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize) (this.d3d)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.statusBarPanel1)).EndInit();
			this.panelRight.ResumeLayout(false);
			this.panelRightUp.ResumeLayout(false);
			this.panelRightDown.ResumeLayout(false);
			this.panelDown.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panelD3D.ResumeLayout(false);
			this.panelCenterBorder.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			d3d.MoveUpAtom();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			d3d.MoveDownAtom();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			d3d.ZoomInAtom();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			d3d.ZoomOutAtom();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			d3d.MoveRightAtom();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			d3d.MoveLeftAtom();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			d3d.CenterView();
		}

		public void ShowMe(IntPtr graph)
		{
			this.Show();
			d3d.SetGraph(ref graph);
			//this.ShowDialog();
		}

		private void d3d_ActiveLoop(object sender,
		                            _IMorseKernelVisualizationDirect3DEvents_ActiveLoopEvent e)
		{
			label1.Text = "Selected Length: " + e.length;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			d3d.SetTestGraph();
		}

		private void d3d_OnMouseMoveFloat(object sender,
		                                  _IMorseKernelVisualizationDirect3DEvents_OnMouseMoveFloatEvent e)
		{
			statusBarPanel1.Text = String.Format("[{0}; {1}; {2}]", e.x1, e.x2, e.x3);
		}
	}
}