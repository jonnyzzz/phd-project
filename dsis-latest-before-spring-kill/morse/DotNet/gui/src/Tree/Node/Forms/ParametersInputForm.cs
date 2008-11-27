using System;
using System.Data;
using System.Windows.Forms;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for ParametersInputForm.
	/// </summary>
	public class ParametersInputForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panelGroupBox;
		private System.Windows.Forms.Panel panelGrid;
		private System.Windows.Forms.DataGrid data;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int dimension;
		private System.Windows.Forms.GroupBox groupBoxGrid;

		private IParametersRowInfo[] rowInfos;

		public ParametersInputForm(IParametersRowInfo[] infos)
		{
			dimension = infos[0].Dimension;
			foreach (IParametersRowInfo info in infos)
			{
				if (dimension != info.Dimension) throw new ArgumentException("Different dimension");
			}

			rowInfos = infos;


			InitializeComponent();

			FillGrid();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ParametersInputForm));
			this.panelMain = new System.Windows.Forms.Panel();
			this.panelGroupBox = new System.Windows.Forms.Panel();
			this.groupBoxGrid = new System.Windows.Forms.GroupBox();
			this.panelGrid = new System.Windows.Forms.Panel();
			this.data = new System.Windows.Forms.DataGrid();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.panelMain.SuspendLayout();
			this.panelGroupBox.SuspendLayout();
			this.groupBoxGrid.SuspendLayout();
			this.panelGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelGroupBox);
			this.panelMain.Controls.Add(this.panelButtons);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.DockPadding.All = 5;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(560, 254);
			this.panelMain.TabIndex = 0;
			// 
			// panelGroupBox
			// 
			this.panelGroupBox.Controls.Add(this.groupBoxGrid);
			this.panelGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGroupBox.Location = new System.Drawing.Point(5, 5);
			this.panelGroupBox.Name = "panelGroupBox";
			this.panelGroupBox.Size = new System.Drawing.Size(550, 212);
			this.panelGroupBox.TabIndex = 2;
			// 
			// groupBoxGrid
			// 
			this.groupBoxGrid.Controls.Add(this.panelGrid);
			this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxGrid.Location = new System.Drawing.Point(0, 0);
			this.groupBoxGrid.Name = "groupBoxGrid";
			this.groupBoxGrid.Size = new System.Drawing.Size(550, 212);
			this.groupBoxGrid.TabIndex = 0;
			this.groupBoxGrid.TabStop = false;
			this.groupBoxGrid.Text = "Input parameters";
			// 
			// panelGrid
			// 
			this.panelGrid.Controls.Add(this.data);
			this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGrid.DockPadding.All = 5;
			this.panelGrid.Location = new System.Drawing.Point(3, 16);
			this.panelGrid.Name = "panelGrid";
			this.panelGrid.Size = new System.Drawing.Size(544, 193);
			this.panelGrid.TabIndex = 0;
			// 
			// data
			// 
			this.data.AlternatingBackColor = System.Drawing.Color.GhostWhite;
			this.data.BackColor = System.Drawing.Color.GhostWhite;
			this.data.BackgroundColor = System.Drawing.Color.Lavender;
			this.data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.data.CaptionBackColor = System.Drawing.Color.RoyalBlue;
			this.data.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.data.CaptionForeColor = System.Drawing.Color.White;
			this.data.DataMember = "";
			this.data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.data.FlatMode = true;
			this.data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.data.ForeColor = System.Drawing.Color.MidnightBlue;
			this.data.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.data.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.data.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.data.HeaderForeColor = System.Drawing.Color.Lavender;
			this.data.LinkColor = System.Drawing.Color.Teal;
			this.data.Location = new System.Drawing.Point(5, 5);
			this.data.Name = "data";
			this.data.ParentRowsBackColor = System.Drawing.Color.Lavender;
			this.data.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.data.SelectionBackColor = System.Drawing.Color.Teal;
			this.data.SelectionForeColor = System.Drawing.Color.PaleGreen;
			this.data.Size = new System.Drawing.Size(534, 183);
			this.data.TabIndex = 0;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.buttonOK);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.DockPadding.Bottom = 2;
			this.panelButtons.DockPadding.Left = 30;
			this.panelButtons.DockPadding.Right = 30;
			this.panelButtons.DockPadding.Top = 2;
			this.panelButtons.Location = new System.Drawing.Point(5, 217);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(550, 32);
			this.panelButtons.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Location = new System.Drawing.Point(344, 2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(176, 28);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Location = new System.Drawing.Point(30, 2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(186, 28);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "Ok";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// ParametersInputForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(560, 254);
			this.Controls.Add(this.panelMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ParametersInputForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ParametersInputForm";
			this.panelMain.ResumeLayout(false);
			this.panelGroupBox.ResumeLayout(false);
			this.groupBoxGrid.ResumeLayout(false);
			this.panelGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FillGrid()
		{
			DataTable table = new DataTable();

			DataColumn column = new DataColumn("Parameter", typeof(string));
			column.ReadOnly = true;
			table.Columns.Add(column);

			for (int i=1; i<=dimension; i++ )
			{
				column = new DataColumn("x" + i);
				table.Columns.Add(column);
			}


			for (int i=0; i< rowInfos.Length; i++)
			{
				IParametersRowInfo info = rowInfos[i];

				DataRow row = table.NewRow();
				row[0] = info.Name;
				for (int j=0; j<dimension; j++)
				{
					row[j+1] = info.DefaultValue(j);
				}
				table.Rows.Add(row);
			}

			DataView dataView = new DataView(table);
			dataView.AllowNew = false;
			dataView.AllowDelete = false;
			
			data.AllowSorting = false;
			data.AllowNavigation = false;

			data.DataSource = dataView;
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			data.Refresh();
			data.Update();
			data.Focus();

			DataView view = (DataView)data.DataSource;
			DataTable table = view.Table;			

			bool success = true;

			for (int i=0; i<rowInfos.Length; i++ )
			{
				DataRow row = table.Rows[i];
				IParametersRowInfo info = rowInfos[i];

				for (int j=0; j<dimension; j++)
				{
					bool res = false;
					if (row[j+1] != null) 
					{
						res = info.Submit(row[j+1].ToString(), j);
					}

					if (!res)
					{
						MessageBox.Show("Incorrect input.");
						success = false;
						break;
					}
				}
				if (!success) break;
			}

			if (success) DialogResult = DialogResult.OK;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
