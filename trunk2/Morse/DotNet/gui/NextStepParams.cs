using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gui
{
	/// <summary>
	/// Summary description for NextStepParams.
	/// </summary>
	public class NextStepParams : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.DataGrid paramsGrid;
		private System.Windows.Forms.Button buttonOK;				
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonCancel;		
		private System.ComponentModel.Container components = null;

		public NextStepParams()
		{			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NextStepParams));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.paramsGrid = new System.Windows.Forms.DataGrid();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paramsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.paramsGrid);
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
			// paramsGrid
			// 
			this.paramsGrid.AccessibleDescription = resources.GetString("paramsGrid.AccessibleDescription");
			this.paramsGrid.AccessibleName = resources.GetString("paramsGrid.AccessibleName");
			this.paramsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("paramsGrid.Anchor")));
			this.paramsGrid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paramsGrid.BackgroundImage")));
			this.paramsGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.paramsGrid.CaptionFont = ((System.Drawing.Font)(resources.GetObject("paramsGrid.CaptionFont")));
			this.paramsGrid.CaptionText = resources.GetString("paramsGrid.CaptionText");
			this.paramsGrid.DataMember = "";
			this.paramsGrid.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("paramsGrid.Dock")));
			this.paramsGrid.Enabled = ((bool)(resources.GetObject("paramsGrid.Enabled")));
			this.paramsGrid.Font = ((System.Drawing.Font)(resources.GetObject("paramsGrid.Font")));
			this.paramsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.paramsGrid.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("paramsGrid.ImeMode")));
			this.paramsGrid.Location = ((System.Drawing.Point)(resources.GetObject("paramsGrid.Location")));
			this.paramsGrid.Name = "paramsGrid";
			this.paramsGrid.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("paramsGrid.RightToLeft")));
			this.paramsGrid.Size = ((System.Drawing.Size)(resources.GetObject("paramsGrid.Size")));
			this.paramsGrid.TabIndex = ((int)(resources.GetObject("paramsGrid.TabIndex")));
			this.paramsGrid.Visible = ((bool)(resources.GetObject("paramsGrid.Visible")));
			// 
			// buttonOK
			// 
			this.buttonOK.AccessibleDescription = resources.GetString("buttonOK.AccessibleDescription");
			this.buttonOK.AccessibleName = resources.GetString("buttonOK.AccessibleName");
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonOK.Anchor")));
			this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
			this.buttonOK.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonOK.Dock")));
			this.buttonOK.Enabled = ((bool)(resources.GetObject("buttonOK.Enabled")));
			this.buttonOK.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonOK.FlatStyle")));
			this.buttonOK.Font = ((System.Drawing.Font)(resources.GetObject("buttonOK.Font")));
			this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
			this.buttonOK.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonOK.ImageAlign")));
			this.buttonOK.ImageIndex = ((int)(resources.GetObject("buttonOK.ImageIndex")));
			this.buttonOK.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonOK.ImeMode")));
			this.buttonOK.Location = ((System.Drawing.Point)(resources.GetObject("buttonOK.Location")));
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonOK.RightToLeft")));
			this.buttonOK.Size = ((System.Drawing.Size)(resources.GetObject("buttonOK.Size")));
			this.buttonOK.TabIndex = ((int)(resources.GetObject("buttonOK.TabIndex")));
			this.buttonOK.Text = resources.GetString("buttonOK.Text");
			this.buttonOK.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonOK.TextAlign")));
			this.buttonOK.Visible = ((bool)(resources.GetObject("buttonOK.Visible")));
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AccessibleDescription = resources.GetString("buttonCancel.AccessibleDescription");
			this.buttonCancel.AccessibleName = resources.GetString("buttonCancel.AccessibleName");
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonCancel.Anchor")));
			this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonCancel.Dock")));
			this.buttonCancel.Enabled = ((bool)(resources.GetObject("buttonCancel.Enabled")));
			this.buttonCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonCancel.FlatStyle")));
			this.buttonCancel.Font = ((System.Drawing.Font)(resources.GetObject("buttonCancel.Font")));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonCancel.ImageAlign")));
			this.buttonCancel.ImageIndex = ((int)(resources.GetObject("buttonCancel.ImageIndex")));
			this.buttonCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonCancel.ImeMode")));
			this.buttonCancel.Location = ((System.Drawing.Point)(resources.GetObject("buttonCancel.Location")));
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonCancel.RightToLeft")));
			this.buttonCancel.Size = ((System.Drawing.Size)(resources.GetObject("buttonCancel.Size")));
			this.buttonCancel.TabIndex = ((int)(resources.GetObject("buttonCancel.TabIndex")));
			this.buttonCancel.Text = resources.GetString("buttonCancel.Text");
			this.buttonCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonCancel.TextAlign")));
			this.buttonCancel.Visible = ((bool)(resources.GetObject("buttonCancel.Visible")));
			// 
			// NextStepParams
			// 
			this.AcceptButton = this.buttonOK;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.buttonCancel;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "NextStepParams";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.paramsGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private int dimension;
		private DataTable table;
		private int[][] answer = null;
		private int[][] parentResult;

		public int[][] Result
		{
			get
			{
				return answer;
			}
		}

		public DialogResult ShowDialog(IWin32Window parent, int[][] old, int dimension)
		{
			this.dimension = dimension;
			this.initData(old);
			this.parentResult = old;

			return this.ShowDialog(parent);
		}

		private string[] RowName
		{
			get
			{
				return new string[] {
						"Cell branch", "Points in cell"
					};
			}
		}

		private DataRow createCol(string name, int[] param, int rowID)
		{
			DataRow row = table.NewRow();
			
			row[0] = RowName[rowID];
			for (int i=0; i<dimension; i++)
			{
				row[i+1] = param[i];
			}
			
			return row;
		}
		
		private void initData(int[][] data)
		{
			table = new DataTable();
			
			DataColumn cln = new DataColumn("Parameters", typeof(string));
			cln.ReadOnly = true;
			table.Columns.Add(cln);
			for (int i=0; i<dimension; i++)
			{
				cln = new DataColumn("x" + i, typeof(string));				
				table.Columns.Add(cln);
			}

			for (int i=0; i<data.Length; i++) 
			{
				table.Rows.Add( createCol(RowName[i], data[i], i));
			}
						
			DataView dw = new DataView(table);
			dw.AllowNew = false;
			dw.AllowDelete = false;
		
			paramsGrid.AllowSorting = false;
			paramsGrid.DataSource = dw;	
		}		
	
		private bool readArrayLine(int row, ref int[] data)
		{
			for (int i=0; i<dimension; i++) 
			{
				try 
				{
					String v = table.Rows[row].ItemArray[i+1] as String;
					if (v == null) throw new ArgumentNullException();
					data[i] = Int32.Parse(v);
					if (data[i] < 1) throw new ArgumentNullException();
					
				} catch (Exception) {
					showErrorMessage();
					return false;
				} 				
			}
			return true;
		}
        

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			answer = new int[parentResult.Length][];
			bool fail = false;
			for (int i=0; i<parentResult.Length; i++)
			{
				answer[i] = new int[dimension];
				if (!readArrayLine(i, ref answer[i]))
				{
					fail = true;
					break;
				}
			}

			if (fail)
			{
				return;
			}

			this.DialogResult = DialogResult.OK;
		}
	
		private void showErrorMessage()
		{
			MessageBox.Show("Error filling form. There sould be only positive integers");
		}
	}
}
