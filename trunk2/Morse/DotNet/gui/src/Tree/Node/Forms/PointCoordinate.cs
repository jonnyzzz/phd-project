using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for PointCoordinate.
	/// </summary>
	public class PointCoordinate : Form
	{
		private GroupBox groupBoxGrid;
		private Button buttonOK;
		private Button buttonCancel;
		private DataGrid dataGrid;
		private Panel panelGrid;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private double[] array;

		public PointCoordinate(double[] initArray)
		{
			this.array = initArray;
			InitializeComponent();
			ShowArray();
		}

		private DataTable table;
		private DataRow row;

		private void ShowArray()
		{
			table = new DataTable();

			for (int i = 0; i < array.Length; i++)
			{
				table.Columns.Add(new DataColumn("x" + (i + 1), typeof (double)));
			}

			row = table.NewRow();
			for (int i = 0; i < array.Length; i++)
			{
				row[i] = array[i];
			}
			table.Rows.Add(row);


			DataView dw = new DataView(table);
			dw.AllowNew = false;
			dw.AllowDelete = false;

			dataGrid.DataSource = dw;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (PointCoordinate));
			this.groupBoxGrid = new System.Windows.Forms.GroupBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.panelGrid = new System.Windows.Forms.Panel();
			this.groupBoxGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.dataGrid)).BeginInit();
			this.panelGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxGrid
			// 
			this.groupBoxGrid.Controls.Add(this.panelGrid);
			this.groupBoxGrid.Location = new System.Drawing.Point(8, 8);
			this.groupBoxGrid.Name = "groupBoxGrid";
			this.groupBoxGrid.Size = new System.Drawing.Size(472, 168);
			this.groupBoxGrid.TabIndex = 0;
			this.groupBoxGrid.TabStop = false;
			this.groupBoxGrid.Text = "Set start point coordinates to continue";
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonOK.Location = new System.Drawing.Point(8, 184);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(160, 24);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "Ok";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonCancel.Location = new System.Drawing.Point(320, 184);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(160, 24);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			// 
			// dataGrid
			// 
			this.dataGrid.DataMember = "";
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(0, 0);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(466, 149);
			this.dataGrid.TabIndex = 0;
			// 
			// panelGrid
			// 
			this.panelGrid.Controls.Add(this.dataGrid);
			this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGrid.Location = new System.Drawing.Point(3, 16);
			this.panelGrid.Name = "panelGrid";
			this.panelGrid.Size = new System.Drawing.Size(466, 149);
			this.panelGrid.TabIndex = 1;
			// 
			// PointCoordinate
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(488, 214);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBoxGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.Name = "PointCoordinate";
			this.Text = "PointCoordinate";
			this.groupBoxGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.dataGrid)).EndInit();
			this.panelGrid.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public double[] Array
		{
			get { return array; }
		}


		private void buttonOK_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (double) row[i];
			}
			this.DialogResult = DialogResult.OK;
		}
	}
}