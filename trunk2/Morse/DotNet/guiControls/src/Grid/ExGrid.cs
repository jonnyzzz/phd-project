using System;
using System.Data;
using guiControls.Control;

namespace guiControls.Grid
{
	public class ExGrid : System.Windows.Forms.UserControl, ISubmittable
	{
		private System.Windows.Forms.DataGrid grid;
		private System.ComponentModel.Container components = null;

		private IExGridRow[] rows;
		private int dimension;

		public ExGrid() : this(0)
		{
		}

		public ExGrid(int dimension, params IExGridRow[] rows)
		{
			this.rows = rows;
			this.dimension = dimension;
			InitializeComponent();
			FillGrid();
		}

		public IExGridRow[] Rows
		{
			get
			{
				return rows;
			}
		}

		public void SetRows(int dimension, params IExGridRow[] value)
		{
			this.dimension = dimension;
			rows = value;
			FillGrid();
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.AlternatingBackColor = System.Drawing.Color.GhostWhite;
			this.grid.BackColor = System.Drawing.Color.GhostWhite;
			this.grid.BackgroundColor = System.Drawing.Color.Lavender;
			this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.CaptionBackColor = System.Drawing.Color.RoyalBlue;
			this.grid.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.grid.CaptionForeColor = System.Drawing.Color.White;
			this.grid.DataMember = "";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.FlatMode = true;
			this.grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.grid.ForeColor = System.Drawing.Color.MidnightBlue;
			this.grid.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.grid.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.grid.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.grid.HeaderForeColor = System.Drawing.Color.Lavender;
			this.grid.LinkColor = System.Drawing.Color.Teal;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.Name = "grid";
			this.grid.ParentRowsBackColor = System.Drawing.Color.Lavender;
			this.grid.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.grid.SelectionBackColor = System.Drawing.Color.Teal;
			this.grid.SelectionForeColor = System.Drawing.Color.PaleGreen;
			this.grid.Size = new System.Drawing.Size(312, 264);
			this.grid.TabIndex = 0;
			// 
			// ExGrid
			// 
			this.Controls.Add(this.grid);
			this.Name = "ExGrid";
			this.Size = new System.Drawing.Size(312, 264);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
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


			for (int i=0; i< rows.Length; i++)
			{
				IExGridRow info = rows[i];

				DataRow row = table.NewRow();
				row[0] = info.Caption;
				for (int j=0; j<dimension; j++)
				{
					row[j+1] = info[j];
				}
				table.Rows.Add(row);
			}

			DataView dataView = new DataView(table);
			dataView.AllowNew = false;
			dataView.AllowDelete = false;
			
			
			grid.AllowSorting = false;
			grid.AllowNavigation = false;
			grid.DataSource = dataView;
		}


		public void SubmitData()
		{
			grid.Refresh();
			grid.Update();
			grid.Focus();

			DataView view = (DataView)grid.DataSource;
			DataTable table = view.Table;			

			for (int i=0; i<rows.Length; i++ )
			{
				DataRow row = table.Rows[i];
				IExGridRow info = rows[i];

				for (int j=0; j<dimension; j++)
				{					
					if (row[j+1] != null) 
					{
						info[j] = row[j+1].ToString();
					}
				}
			}
		}
	}
}
