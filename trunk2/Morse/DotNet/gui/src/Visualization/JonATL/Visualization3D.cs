using System;
using System.ComponentModel;
using System.Windows.Forms;
using AxMorseKernelVisualizationATL;

namespace gui.Visualization.JonATL
{
	/// <summary>
	/// Summary description for Visualization3D.
	/// </summary>
	public class Visualization3D : Form
	{
		private AxCMorseKernelVisualizationDirectGraph3D d3d;
		private Button buttonXPlus;
		private Button buttonXMinus;
		private Button buttonYMinus;
		private Button buttonYPlus;
		private Button buttonZMinus;
		private Button buttonZPlus;
		private TextBox inputX;
		private TextBox inputY;
		private TextBox inputZ;
		private Button buttonFrom;
		private Button buttonTo;
		private Button buttonRotate;
		private Button buttonCenter;
		private Button buttonZoomOut;
		private Button buttonZoomIn;
		private Button buttonRotateZMinus;
		private Button buttonRotateZPlus;
		private Button buttonRotateYMinus;
		private Button buttonRotateYPlus;
		private Button buttonRotateXMunis;
		private Button buttonRotateXPlus;
		private Panel panel2;
		private Panel panelX;
		private Panel panel3;
		private Panel panelY;
		private Panel panel4;
		private Panel panelZ;
		private Panel panel5;
		private Panel panelRight;
		private Panel panelRX;
		private Panel panel6;
		private Panel panelRY;
		private Panel panel7;
		private Panel panelRZ;
		private Panel panel8;
		private Panel panelZoom;
		private Panel panelDown;
		private Panel panel9;
		private Panel panel10;
		private Panel panel11;
		private StatusBar statusBar;
		private Panel panelCenter;
		private Panel panelCenterBorder;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public void ShowMe(IntPtr graph)
		{
			this.Show();
			d3d.SetGraph(ref graph);
		}

		public void ShowTest()
		{
			this.Show();
			d3d.SetTestGraph();
		}

		public Visualization3D(bool degub)
		{
			InitializeComponent();
			d3d.SetTestGraph();
		}


		public Visualization3D()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (Visualization3D));
			this.d3d = new AxMorseKernelVisualizationATL.AxCMorseKernelVisualizationDirectGraph3D();
			this.buttonXPlus = new System.Windows.Forms.Button();
			this.buttonXMinus = new System.Windows.Forms.Button();
			this.buttonYMinus = new System.Windows.Forms.Button();
			this.buttonYPlus = new System.Windows.Forms.Button();
			this.buttonZMinus = new System.Windows.Forms.Button();
			this.buttonZPlus = new System.Windows.Forms.Button();
			this.inputX = new System.Windows.Forms.TextBox();
			this.inputY = new System.Windows.Forms.TextBox();
			this.inputZ = new System.Windows.Forms.TextBox();
			this.buttonFrom = new System.Windows.Forms.Button();
			this.buttonTo = new System.Windows.Forms.Button();
			this.buttonRotate = new System.Windows.Forms.Button();
			this.buttonCenter = new System.Windows.Forms.Button();
			this.buttonZoomOut = new System.Windows.Forms.Button();
			this.buttonZoomIn = new System.Windows.Forms.Button();
			this.buttonRotateZMinus = new System.Windows.Forms.Button();
			this.buttonRotateZPlus = new System.Windows.Forms.Button();
			this.buttonRotateYMinus = new System.Windows.Forms.Button();
			this.buttonRotateYPlus = new System.Windows.Forms.Button();
			this.buttonRotateXMunis = new System.Windows.Forms.Button();
			this.buttonRotateXPlus = new System.Windows.Forms.Button();
			this.panelRight = new System.Windows.Forms.Panel();
			this.panelZoom = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panelRZ = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panelRY = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panelRX = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panelZ = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panelY = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panelX = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelDown = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.panelCenter = new System.Windows.Forms.Panel();
			this.panelCenterBorder = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize) (this.d3d)).BeginInit();
			this.panelRight.SuspendLayout();
			this.panelZoom.SuspendLayout();
			this.panelRZ.SuspendLayout();
			this.panelRY.SuspendLayout();
			this.panelRX.SuspendLayout();
			this.panelZ.SuspendLayout();
			this.panelY.SuspendLayout();
			this.panelX.SuspendLayout();
			this.panelDown.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panelCenter.SuspendLayout();
			this.panelCenterBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// d3d
			// 
			this.d3d.ContainingControl = this;
			this.d3d.Dock = System.Windows.Forms.DockStyle.Fill;
			this.d3d.Enabled = true;
			this.d3d.Location = new System.Drawing.Point(0, 0);
			this.d3d.Name = "d3d";
			this.d3d.OcxState = ((System.Windows.Forms.AxHost.State) (resources.GetObject("d3d.OcxState")));
			this.d3d.Size = new System.Drawing.Size(634, 520);
			this.d3d.TabIndex = 0;
			// 
			// buttonXPlus
			// 
			this.buttonXPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonXPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonXPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonXPlus.Location = new System.Drawing.Point(0, 32);
			this.buttonXPlus.Name = "buttonXPlus";
			this.buttonXPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonXPlus.TabIndex = 1;
			this.buttonXPlus.Text = "x+";
			this.buttonXPlus.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonXMinus
			// 
			this.buttonXMinus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonXMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonXMinus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonXMinus.Location = new System.Drawing.Point(0, 0);
			this.buttonXMinus.Name = "buttonXMinus";
			this.buttonXMinus.Size = new System.Drawing.Size(44, 32);
			this.buttonXMinus.TabIndex = 2;
			this.buttonXMinus.Text = "x-";
			this.buttonXMinus.Click += new System.EventHandler(this.button2_Click);
			// 
			// buttonYMinus
			// 
			this.buttonYMinus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonYMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonYMinus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonYMinus.Location = new System.Drawing.Point(0, 32);
			this.buttonYMinus.Name = "buttonYMinus";
			this.buttonYMinus.Size = new System.Drawing.Size(44, 32);
			this.buttonYMinus.TabIndex = 3;
			this.buttonYMinus.Text = "y-";
			this.buttonYMinus.Click += new System.EventHandler(this.button3_Click);
			// 
			// buttonYPlus
			// 
			this.buttonYPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonYPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonYPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonYPlus.Location = new System.Drawing.Point(0, 0);
			this.buttonYPlus.Name = "buttonYPlus";
			this.buttonYPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonYPlus.TabIndex = 4;
			this.buttonYPlus.Text = "y+";
			this.buttonYPlus.Click += new System.EventHandler(this.button4_Click);
			// 
			// buttonZMinus
			// 
			this.buttonZMinus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonZMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonZMinus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonZMinus.Location = new System.Drawing.Point(0, 32);
			this.buttonZMinus.Name = "buttonZMinus";
			this.buttonZMinus.Size = new System.Drawing.Size(44, 32);
			this.buttonZMinus.TabIndex = 5;
			this.buttonZMinus.Text = "z-";
			this.buttonZMinus.Click += new System.EventHandler(this.button5_Click);
			// 
			// buttonZPlus
			// 
			this.buttonZPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonZPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonZPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonZPlus.Location = new System.Drawing.Point(0, 0);
			this.buttonZPlus.Name = "buttonZPlus";
			this.buttonZPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonZPlus.TabIndex = 6;
			this.buttonZPlus.Text = "z+";
			this.buttonZPlus.Click += new System.EventHandler(this.button6_Click);
			// 
			// inputX
			// 
			this.inputX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.inputX.Location = new System.Drawing.Point(16, 8);
			this.inputX.Name = "inputX";
			this.inputX.Size = new System.Drawing.Size(40, 20);
			this.inputX.TabIndex = 7;
			this.inputX.Text = "0";
			// 
			// inputY
			// 
			this.inputY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.inputY.Location = new System.Drawing.Point(64, 8);
			this.inputY.Name = "inputY";
			this.inputY.Size = new System.Drawing.Size(40, 20);
			this.inputY.TabIndex = 8;
			this.inputY.Text = "0";
			// 
			// inputZ
			// 
			this.inputZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.inputZ.Location = new System.Drawing.Point(112, 8);
			this.inputZ.Name = "inputZ";
			this.inputZ.Size = new System.Drawing.Size(40, 20);
			this.inputZ.TabIndex = 9;
			this.inputZ.Text = "0";
			// 
			// buttonFrom
			// 
			this.buttonFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFrom.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonFrom.Location = new System.Drawing.Point(184, 8);
			this.buttonFrom.Name = "buttonFrom";
			this.buttonFrom.Size = new System.Drawing.Size(48, 24);
			this.buttonFrom.TabIndex = 10;
			this.buttonFrom.Text = "From";
			this.buttonFrom.Click += new System.EventHandler(this.button7_Click);
			// 
			// buttonTo
			// 
			this.buttonTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTo.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonTo.Location = new System.Drawing.Point(240, 8);
			this.buttonTo.Name = "buttonTo";
			this.buttonTo.Size = new System.Drawing.Size(48, 24);
			this.buttonTo.TabIndex = 11;
			this.buttonTo.Text = "To";
			this.buttonTo.Click += new System.EventHandler(this.button8_Click);
			// 
			// buttonRotate
			// 
			this.buttonRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotate.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotate.Location = new System.Drawing.Point(296, 8);
			this.buttonRotate.Name = "buttonRotate";
			this.buttonRotate.Size = new System.Drawing.Size(48, 24);
			this.buttonRotate.TabIndex = 12;
			this.buttonRotate.Text = "Rotate";
			this.buttonRotate.Click += new System.EventHandler(this.button9_Click);
			// 
			// buttonCenter
			// 
			this.buttonCenter.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.buttonCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCenter.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonCenter.Location = new System.Drawing.Point(8, 8);
			this.buttonCenter.Name = "buttonCenter";
			this.buttonCenter.Size = new System.Drawing.Size(96, 24);
			this.buttonCenter.TabIndex = 13;
			this.buttonCenter.Text = "CenterView";
			this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
			// 
			// buttonZoomOut
			// 
			this.buttonZoomOut.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonZoomOut.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonZoomOut.Location = new System.Drawing.Point(0, 32);
			this.buttonZoomOut.Name = "buttonZoomOut";
			this.buttonZoomOut.Size = new System.Drawing.Size(44, 32);
			this.buttonZoomOut.TabIndex = 16;
			this.buttonZoomOut.Text = "zoom out";
			this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
			// 
			// buttonZoomIn
			// 
			this.buttonZoomIn.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonZoomIn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonZoomIn.Location = new System.Drawing.Point(0, 0);
			this.buttonZoomIn.Name = "buttonZoomIn";
			this.buttonZoomIn.Size = new System.Drawing.Size(44, 32);
			this.buttonZoomIn.TabIndex = 15;
			this.buttonZoomIn.Text = "zoom in";
			this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
			// 
			// buttonRotateZMinus
			// 
			this.buttonRotateZMinus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateZMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateZMinus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateZMinus.Location = new System.Drawing.Point(0, 32);
			this.buttonRotateZMinus.Name = "buttonRotateZMinus";
			this.buttonRotateZMinus.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateZMinus.TabIndex = 18;
			this.buttonRotateZMinus.Text = "rot Z-";
			this.buttonRotateZMinus.Click += new System.EventHandler(this.buttonRotateZMinus_Click);
			// 
			// buttonRotateZPlus
			// 
			this.buttonRotateZPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateZPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateZPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateZPlus.Location = new System.Drawing.Point(0, 0);
			this.buttonRotateZPlus.Name = "buttonRotateZPlus";
			this.buttonRotateZPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateZPlus.TabIndex = 17;
			this.buttonRotateZPlus.Text = "rot Z+";
			this.buttonRotateZPlus.Click += new System.EventHandler(this.buttonRotateZPlus_Click);
			// 
			// buttonRotateYMinus
			// 
			this.buttonRotateYMinus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateYMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateYMinus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateYMinus.Location = new System.Drawing.Point(0, 32);
			this.buttonRotateYMinus.Name = "buttonRotateYMinus";
			this.buttonRotateYMinus.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateYMinus.TabIndex = 20;
			this.buttonRotateYMinus.Text = "rot Y-";
			this.buttonRotateYMinus.Click += new System.EventHandler(this.buttonRotateYMinus_Click);
			// 
			// buttonRotateYPlus
			// 
			this.buttonRotateYPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateYPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateYPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateYPlus.Location = new System.Drawing.Point(0, 0);
			this.buttonRotateYPlus.Name = "buttonRotateYPlus";
			this.buttonRotateYPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateYPlus.TabIndex = 19;
			this.buttonRotateYPlus.Text = "rot Y+";
			this.buttonRotateYPlus.Click += new System.EventHandler(this.buttonRotateYPlus_Click);
			// 
			// buttonRotateXMunis
			// 
			this.buttonRotateXMunis.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateXMunis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateXMunis.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateXMunis.Location = new System.Drawing.Point(0, 32);
			this.buttonRotateXMunis.Name = "buttonRotateXMunis";
			this.buttonRotateXMunis.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateXMunis.TabIndex = 22;
			this.buttonRotateXMunis.Text = "rot X-";
			this.buttonRotateXMunis.Click += new System.EventHandler(this.buttonRotateXMunis_Click);
			// 
			// buttonRotateXPlus
			// 
			this.buttonRotateXPlus.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonRotateXPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRotateXPlus.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.buttonRotateXPlus.Location = new System.Drawing.Point(0, 0);
			this.buttonRotateXPlus.Name = "buttonRotateXPlus";
			this.buttonRotateXPlus.Size = new System.Drawing.Size(44, 32);
			this.buttonRotateXPlus.TabIndex = 21;
			this.buttonRotateXPlus.Text = "rot X+";
			this.buttonRotateXPlus.Click += new System.EventHandler(this.buttonRotateXPlus_Click);
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.panelZoom);
			this.panelRight.Controls.Add(this.panel8);
			this.panelRight.Controls.Add(this.panelRZ);
			this.panelRight.Controls.Add(this.panel7);
			this.panelRight.Controls.Add(this.panelRY);
			this.panelRight.Controls.Add(this.panel6);
			this.panelRight.Controls.Add(this.panelRX);
			this.panelRight.Controls.Add(this.panel5);
			this.panelRight.Controls.Add(this.panelZ);
			this.panelRight.Controls.Add(this.panel4);
			this.panelRight.Controls.Add(this.panelY);
			this.panelRight.Controls.Add(this.panel3);
			this.panelRight.Controls.Add(this.panelX);
			this.panelRight.Controls.Add(this.panel2);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.DockPadding.All = 10;
			this.panelRight.Location = new System.Drawing.Point(656, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(64, 582);
			this.panelRight.TabIndex = 23;
			// 
			// panelZoom
			// 
			this.panelZoom.Controls.Add(this.buttonZoomOut);
			this.panelZoom.Controls.Add(this.buttonZoomIn);
			this.panelZoom.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelZoom.Location = new System.Drawing.Point(10, 450);
			this.panelZoom.Name = "panelZoom";
			this.panelZoom.Size = new System.Drawing.Size(44, 64);
			this.panelZoom.TabIndex = 13;
			// 
			// panel8
			// 
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(10, 442);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(44, 8);
			this.panel8.TabIndex = 12;
			// 
			// panelRZ
			// 
			this.panelRZ.Controls.Add(this.buttonRotateZMinus);
			this.panelRZ.Controls.Add(this.buttonRotateZPlus);
			this.panelRZ.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRZ.Location = new System.Drawing.Point(10, 378);
			this.panelRZ.Name = "panelRZ";
			this.panelRZ.Size = new System.Drawing.Size(44, 64);
			this.panelRZ.TabIndex = 11;
			// 
			// panel7
			// 
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(10, 370);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(44, 8);
			this.panel7.TabIndex = 10;
			// 
			// panelRY
			// 
			this.panelRY.Controls.Add(this.buttonRotateYMinus);
			this.panelRY.Controls.Add(this.buttonRotateYPlus);
			this.panelRY.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRY.Location = new System.Drawing.Point(10, 306);
			this.panelRY.Name = "panelRY";
			this.panelRY.Size = new System.Drawing.Size(44, 64);
			this.panelRY.TabIndex = 9;
			// 
			// panel6
			// 
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(10, 298);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(44, 8);
			this.panel6.TabIndex = 8;
			// 
			// panelRX
			// 
			this.panelRX.Controls.Add(this.buttonRotateXMunis);
			this.panelRX.Controls.Add(this.buttonRotateXPlus);
			this.panelRX.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRX.Location = new System.Drawing.Point(10, 234);
			this.panelRX.Name = "panelRX";
			this.panelRX.Size = new System.Drawing.Size(44, 64);
			this.panelRX.TabIndex = 7;
			// 
			// panel5
			// 
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 226);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(44, 8);
			this.panel5.TabIndex = 6;
			// 
			// panelZ
			// 
			this.panelZ.Controls.Add(this.buttonZMinus);
			this.panelZ.Controls.Add(this.buttonZPlus);
			this.panelZ.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelZ.Location = new System.Drawing.Point(10, 162);
			this.panelZ.Name = "panelZ";
			this.panelZ.Size = new System.Drawing.Size(44, 64);
			this.panelZ.TabIndex = 5;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 154);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(44, 8);
			this.panel4.TabIndex = 4;
			// 
			// panelY
			// 
			this.panelY.Controls.Add(this.buttonYMinus);
			this.panelY.Controls.Add(this.buttonYPlus);
			this.panelY.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelY.Location = new System.Drawing.Point(10, 90);
			this.panelY.Name = "panelY";
			this.panelY.Size = new System.Drawing.Size(44, 64);
			this.panelY.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 82);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(44, 8);
			this.panel3.TabIndex = 2;
			// 
			// panelX
			// 
			this.panelX.Controls.Add(this.buttonXPlus);
			this.panelX.Controls.Add(this.buttonXMinus);
			this.panelX.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelX.Location = new System.Drawing.Point(10, 18);
			this.panelX.Name = "panelX";
			this.panelX.Size = new System.Drawing.Size(44, 64);
			this.panelX.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(44, 8);
			this.panel2.TabIndex = 0;
			// 
			// panelDown
			// 
			this.panelDown.Controls.Add(this.panel11);
			this.panelDown.Controls.Add(this.panel10);
			this.panelDown.Controls.Add(this.panel9);
			this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelDown.Location = new System.Drawing.Point(0, 542);
			this.panelDown.Name = "panelDown";
			this.panelDown.Size = new System.Drawing.Size(656, 40);
			this.panelDown.TabIndex = 24;
			// 
			// panel9
			// 
			this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(40, 40);
			this.panel9.TabIndex = 0;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.inputZ);
			this.panel10.Controls.Add(this.buttonRotate);
			this.panel10.Controls.Add(this.buttonFrom);
			this.panel10.Controls.Add(this.buttonTo);
			this.panel10.Controls.Add(this.inputX);
			this.panel10.Controls.Add(this.inputY);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel10.Location = new System.Drawing.Point(40, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(352, 40);
			this.panel10.TabIndex = 1;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.buttonCenter);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel11.Location = new System.Drawing.Point(536, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(120, 40);
			this.panel11.TabIndex = 2;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 582);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(720, 16);
			this.statusBar.TabIndex = 25;
			this.statusBar.Text = "statusBar1";
			// 
			// panelCenter
			// 
			this.panelCenter.Controls.Add(this.panelCenterBorder);
			this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCenter.DockPadding.All = 10;
			this.panelCenter.Location = new System.Drawing.Point(0, 0);
			this.panelCenter.Name = "panelCenter";
			this.panelCenter.Size = new System.Drawing.Size(656, 542);
			this.panelCenter.TabIndex = 26;
			// 
			// panelCenterBorder
			// 
			this.panelCenterBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCenterBorder.Controls.Add(this.d3d);
			this.panelCenterBorder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCenterBorder.Location = new System.Drawing.Point(10, 10);
			this.panelCenterBorder.Name = "panelCenterBorder";
			this.panelCenterBorder.Size = new System.Drawing.Size(636, 522);
			this.panelCenterBorder.TabIndex = 1;
			// 
			// Visualization3D
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 598);
			this.Controls.Add(this.panelCenter);
			this.Controls.Add(this.panelDown);
			this.Controls.Add(this.panelRight);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Visualization3D";
			this.Text = "Visualization3D";
			((System.ComponentModel.ISupportInitialize) (this.d3d)).EndInit();
			this.panelRight.ResumeLayout(false);
			this.panelZoom.ResumeLayout(false);
			this.panelRZ.ResumeLayout(false);
			this.panelRY.ResumeLayout(false);
			this.panelRX.ResumeLayout(false);
			this.panelZ.ResumeLayout(false);
			this.panelY.ResumeLayout(false);
			this.panelX.ResumeLayout(false);
			this.panelDown.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panelCenter.ResumeLayout(false);
			this.panelCenterBorder.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(-0.3, 0, 0);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(+0.3, 0, 0);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(0, -0.3, 0);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(0, 0.3, 0);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(0, 0, -0.3);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			d3d.MoveFromEye(0, 0, 0.3);
		}

		private float[] getPoints()
		{
			float[] ret = new float[3];

			try
			{
				ret[0] = float.Parse(inputX.Text);
				ret[1] = float.Parse(inputY.Text);
				ret[2] = float.Parse(inputZ.Text);
			}
			catch (Exception)
			{
				return null;
			}
			Console.Out.WriteLine("X = {0}, {1}, {2}", ret[0], ret[1], ret[2]);

			return ret;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			float[] x = getPoints();
			if (x == null) return;

			d3d.SetEyeFrom(x[0], x[1], x[2]);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			float[] x = getPoints();
			if (x == null) return;

			d3d.SetEyeTo(x[0], x[1], x[2]);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			float[] x = getPoints();
			if (x == null) return;

			d3d.Rotate((float) (x[0]*Math.PI/180), (float) (x[1]*Math.PI/180), (float) (x[2]*Math.PI/180));
		}

		private void buttonCenter_Click(object sender, EventArgs e)
		{
			d3d.CenterView();
		}

		private void buttonZoomIn_Click(object sender, EventArgs e)
		{
			d3d.ZoomInAtom();
		}

		private void buttonZoomOut_Click(object sender, EventArgs e)
		{
			d3d.ZoomOutAtom();
		}

		private void buttonRotateXPlus_Click(object sender, EventArgs e)
		{
			d3d.Rotate((float) Math.PI/180, 0.0f, 0.0f);
		}

		private void buttonRotateXMunis_Click(object sender, EventArgs e)
		{
			d3d.Rotate((float) -Math.PI/180, 0.0f, 0.0f);
		}

		private void buttonRotateYPlus_Click(object sender, EventArgs e)
		{
			d3d.Rotate(0.0f, (float) Math.PI/180, 0.0f);
		}

		private void buttonRotateYMinus_Click(object sender, EventArgs e)
		{
			d3d.Rotate(0.0f, (float) -Math.PI/180, 0.0f);
		}

		private void buttonRotateZPlus_Click(object sender, EventArgs e)
		{
			d3d.Rotate(0.0f, 0.0f, (float) Math.PI/180);
		}

		private void buttonRotateZMinus_Click(object sender, EventArgs e)
		{
			d3d.Rotate(0.0f, 0.0f, (float) -Math.PI/180);
		}
	}
}