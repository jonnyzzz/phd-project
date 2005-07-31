using System;
using System.Data;
using System.Windows.Forms;
using guiKernel2.Document;

namespace gui2.Forms
{
	/// <summary>
	/// Summary description for SystemFunctionAnalisys.
	/// </summary>
	public class SystemFunctionAnalisys : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelInGroup;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.DataGrid analisys;

		private IEvaluateFunction function;

		public static void ShowAnalisys()
		{
			Document.Document document = Runner.Runner.Instance.Document;
			if (document.AnalisysForm == null)
			{
				Runner.Runner.Instance.Document.AnalisysForm = new SystemFunctionAnalisys(document.KernelDocument.Function.EvaluateFunction);
			}
			document.AnalisysForm.Show();
		}

		protected SystemFunctionAnalisys(IEvaluateFunction function)
		{
			this.function = function;
			InitializeComponent();

			this.SizeChanged +=new EventHandler(OnRedesign);
			this.Resize += new EventHandler(OnRedesign);
			this.Closed +=new EventHandler(OnClosed);

			analisys.DataSource = FillDataTable();
			redesignGrid();
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
			
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.panelInGroup = new System.Windows.Forms.Panel();
			this.analisys = new System.Windows.Forms.DataGrid();
			this.groupBox.SuspendLayout();
			this.panelInGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.analisys)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.panelInGroup);
			this.groupBox.Location = new System.Drawing.Point(8, 8);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(400, 272);
			this.groupBox.TabIndex = 1;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "System Function Analisys";
			// 
			// panelInGroup
			// 
			this.panelInGroup.Controls.Add(this.analisys);
			this.panelInGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelInGroup.DockPadding.All = 5;
			this.panelInGroup.Location = new System.Drawing.Point(3, 16);
			this.panelInGroup.Name = "panelInGroup";
			this.panelInGroup.Size = new System.Drawing.Size(394, 253);
			this.panelInGroup.TabIndex = 0;
			// 
			// analisys
			// 
			this.analisys.AllowNavigation = false;
			this.analisys.AllowSorting = false;
			this.analisys.AlternatingBackColor = System.Drawing.Color.GhostWhite;
			this.analisys.BackColor = System.Drawing.Color.GhostWhite;
			this.analisys.BackgroundColor = System.Drawing.Color.Lavender;
			this.analisys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.analisys.CaptionBackColor = System.Drawing.Color.RoyalBlue;
			this.analisys.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.analisys.CaptionForeColor = System.Drawing.Color.White;
			this.analisys.DataMember = "";
			this.analisys.Dock = System.Windows.Forms.DockStyle.Fill;
			this.analisys.FlatMode = true;
			this.analisys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.analisys.ForeColor = System.Drawing.Color.MidnightBlue;
			this.analisys.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.analisys.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			this.analisys.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.analisys.HeaderForeColor = System.Drawing.Color.Lavender;
			this.analisys.ImeMode = System.Windows.Forms.ImeMode.Katakana;
			this.analisys.LinkColor = System.Drawing.Color.Teal;
			this.analisys.Location = new System.Drawing.Point(5, 5);
			this.analisys.Name = "analisys";
			this.analisys.ParentRowsBackColor = System.Drawing.Color.Lavender;
			this.analisys.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.analisys.SelectionBackColor = System.Drawing.Color.Teal;
			this.analisys.SelectionForeColor = System.Drawing.Color.PaleGreen;
			this.analisys.Size = new System.Drawing.Size(384, 243);
			this.analisys.TabIndex = 1;
			// 
			// SystemFunctionAnalisys
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 286);
			this.Controls.Add(this.groupBox);
			this.Name = "SystemFunctionAnalisys";
			this.Text = "SystemFunctionAnalisys";
			this.groupBox.ResumeLayout(false);
			this.panelInGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.analisys)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void redesignGrid()
		{
			DataGridTableStyle style = null;
			if (analisys.TableStyles.Count == 0)
			{
				style = new DataGridTableStyle();
				analisys.TableStyles.Add(style);
			}
			else
			{
				style = analisys.TableStyles[0];
			}

			if (!(analisys.DataSource is DataTable)) return;

			DataTable table = analisys.DataSource as DataTable;			

			int w = (int) (analisys.ClientSize.Width*0.90);

			for (int i = 0; i < table.Columns.Count - 2; i++)
			{
				w -= style.GridColumnStyles[i].Width;
				style.GridColumnStyles[i].WidthChanged += new EventHandler(OnRedesign);
			}
			style.RowHeaderWidth = 10;
			style.AllowSorting = false;
			style.ReadOnly = true;			

			w -= 100;
			if (w > 0)
			{
				style.GridColumnStyles[table.Columns.Count - 1].Width = w;
			}
		}

		private void OnRedesign(object sender, EventArgs e)
		{
			redesignGrid();
		}

		private DataTable CreateTable()
		{
			DataTable table = new DataTable();
			table.Columns.Add(new DataColumn("function"));
			table.Columns.Add(new DataColumn("Minimal"));
			table.Columns.Add(new DataColumn("Maximal"));
			table.Columns.Add(new DataColumn("Lipshitz"));

			return table;
		}

		private DataTable FillDataTable()
		{
			DataTable table = CreateTable();

			for (int i=0; i<function.Dimension; i++)
			{
				DataRow row = table.NewRow();
				row[0] = string.Format("y{0}",i+1);
				row[1] = function.MinimalValue[i];
				row[2] = function.MaximalValue[i];
				row[3] = function.LipshitzConstant[i];
				table.Rows.Add(row);
			}
			return table;
		}

		private void OnClosed(object sender, EventArgs e)
		{
			Runner.Runner.Instance.Document.AnalisysForm = null;
		}
	}
}
