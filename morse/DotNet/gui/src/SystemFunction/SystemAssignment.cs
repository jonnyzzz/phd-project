using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using gui.Tree;
using MorseKernelATL;

namespace gui.Forms
{
	/// <summary>
	/// Summary description for SystemAssignment.
	/// </summary>
	public class SystemAssignment : Form
	{
		private const string DIMENSION = "_dimension";
		private bool isReadOnly;


		private GroupBox groupBox1;
		private NumericUpDown dimensionUpDown;
		private Label label1;
		private DataGrid formulas;
		private Button btnNext;
		private Button btnCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private MainMenu mainMenu;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
		private MenuItem menuLoad;
		private MenuItem menuSave;
		private MenuItem menuItemGetSource;


		private CFunction function = new CFunctionClass();

		public SystemAssignment() : this(false)
		{
			isReadOnly = false;
		}

		public SystemAssignment(bool showOpen)
		{
			InitializeComponent();

			menuItemGetSource.Visible = Runner.IsInternal;
			
			dimensionUpDown_ValueChanged(this, EventArgs.Empty);
			isReadOnly = false;

			this.Closed += new EventHandler(onClose);
			registerEvents();

			redesignGrid();

			if (showOpen)
			{
				menuLoad_Click(this, EventArgs.Empty);
			}

		}

		public SystemAssignment(string source) : this()
		{
			this.setSource(source);
			isReadOnly = true;
		}


		private void registerEvents()
		{
			if (!isReadOnly)
			{
				function.FunctionAccepted += new IFunctionEvents_FunctionAcceptedEventHandler(function_FunctionAccepted);
				function.FunctionWrongInput += new IFunctionEvents_FunctionWrongInputEventHandler(function_FunctionWrongInput);
			}
		}

		private void unregisterEvents()
		{
			if (!isReadOnly)
			{
				function.FunctionAccepted -= new IFunctionEvents_FunctionAcceptedEventHandler(function_FunctionAccepted);
				function.FunctionWrongInput -= new IFunctionEvents_FunctionWrongInputEventHandler(function_FunctionWrongInput);
			}
		}

		private void onClose(object sender, EventArgs args)
		{
			unregisterEvents();
		}

		private void redesignGrid()
		{
			DataGridTableStyle style = null;
			if (formulas.TableStyles.Count == 0)
			{
				style = new DataGridTableStyle();
				formulas.TableStyles.Add(style);
			}
			else
			{
				style = formulas.TableStyles[0];
			}

			if (!(formulas.DataSource is DataTable)) return;

			DataTable table = formulas.DataSource as DataTable;

			int w = (int) (formulas.ClientSize.Width*0.95);

			for (int i = 0; i < table.Columns.Count - 2; i++)
			{
				w -= style.GridColumnStyles[i].Width;
				style.GridColumnStyles[i].WidthChanged += new EventHandler(SystemAssignment_WidthChanged);
			}
			style.RowHeaderWidth = 10;
			style.AllowSorting = false;
			w -= 100;
			if (w > 0)
			{
				style.GridColumnStyles[table.Columns.Count - 1].Width = w;
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (SystemAssignment));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dimensionUpDown = new System.Windows.Forms.NumericUpDown();
			this.formulas = new System.Windows.Forms.DataGrid();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuLoad = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuItemGetSource = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.dimensionUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.formulas)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dimensionUpDown);
			this.groupBox1.Controls.Add(this.formulas);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 376);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Descrete system";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Dimension:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dimensionUpDown
			// 
			this.dimensionUpDown.Location = new System.Drawing.Point(416, 24);
			this.dimensionUpDown.Maximum = new System.Decimal(new int[]
				{
					30,
					0,
					0,
					0
				});
			this.dimensionUpDown.Minimum = new System.Decimal(new int[]
				{
					1,
					0,
					0,
					0
				});
			this.dimensionUpDown.Name = "dimensionUpDown";
			this.dimensionUpDown.Size = new System.Drawing.Size(64, 20);
			this.dimensionUpDown.TabIndex = 1;
			this.dimensionUpDown.Value = new System.Decimal(new int[]
				{
					2,
					0,
					0,
					0
				});
			this.dimensionUpDown.ValueChanged += new System.EventHandler(this.dimensionUpDown_ValueChanged);
			// 
			// formulas
			// 
			this.formulas.AllowNavigation = false;
			this.formulas.AllowSorting = false;
			this.formulas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.formulas.DataMember = "";
			this.formulas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.formulas.ImeMode = System.Windows.Forms.ImeMode.Katakana;
			this.formulas.Location = new System.Drawing.Point(16, 56);
			this.formulas.Name = "formulas";
			this.formulas.Size = new System.Drawing.Size(464, 296);
			this.formulas.TabIndex = 0;
			// 
			// btnNext
			// 
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Location = new System.Drawing.Point(8, 392);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(128, 24);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(376, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[]
				{
					this.menuLoad,
					this.menuSave,
					this.menuItemGetSource
				});
			// 
			// menuLoad
			// 
			this.menuLoad.Index = 0;
			this.menuLoad.Text = "Load";
			this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
			// 
			// menuSave
			// 
			this.menuSave.Index = 1;
			this.menuSave.Text = "Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuItemGetSource
			// 
			this.menuItemGetSource.Index = 2;
			this.menuItemGetSource.Text = "GetSource";
			this.menuItemGetSource.Click += new System.EventHandler(this.menuItemGetSource_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "equation";
			this.openFileDialog.Filter = "Equation files|*.equation|All files|*.*";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "equation";
			this.saveFileDialog.FileName = "equation";
			this.saveFileDialog.Filter = "Equation files|*.equation|All files|*.*";
			this.saveFileDialog.Title = "Save System Equation";
			// 
			// SystemAssignment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(514, 421);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu;
			this.Name = "SystemAssignment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "System Equation";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.dimensionUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.formulas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataTable createDataTable()
		{
			DataTable table = new DataTable();
			DataColumn cln = new DataColumn("variable");
			cln.ReadOnly = false;
			cln.DataType = typeof (string);
			table.Columns.Add(cln);
			cln.DefaultValue = "";

			cln = new DataColumn("expression");
			cln.ReadOnly = false;
			cln.DataType = typeof (string);
			cln.DefaultValue = "0";

			table.Columns.Add(cln);

			return table;
		}

		private void dimensionUpDown_ValueChanged(object sender, EventArgs e)
		{
			#region "table initalization"

			DataTable table = createDataTable();


			for (int i = 0; i < dimensionUpDown.Value; i++)
			{
				DataRow row = table.NewRow();
				row[0] = String.Format("y{0}", i + 1);
				row[1] = "0";
				table.Rows.Add(row);
			}

			for (int i = 0; i < dimensionUpDown.Value; i++)
			{
				DataRow row = table.NewRow();
				row[0] = String.Format("space_min{0}", i + 1);
				row[1] = "-1";
				table.Rows.Add(row);
			}

			for (int i = 0; i < dimensionUpDown.Value; i++)
			{
				DataRow row = table.NewRow();
				row[0] = String.Format("space_max{0}", i + 1);
				row[1] = "1";
				table.Rows.Add(row);
			}

			for (int i = 0; i < dimensionUpDown.Value; i++)
			{
				DataRow row = table.NewRow();
				row[0] = String.Format("grid{0}", i + 1);
				row[1] = "10";
				table.Rows.Add(row);
			}

			DataRow dataRow = table.NewRow();
			dataRow[0] = "iteration";
			dataRow[1] = "1";
			table.Rows.Add(dataRow);

			#endregion

			formulas.DataSource = table;
			redesignGrid();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private string createFunctionSource()
		{
			formulas.Refresh();
			formulas.Update();
			formulas.Focus();
			DataTable table = (DataTable) formulas.DataSource;

			table.AcceptChanges();
			table.BeginLoadData();

			string s = "";

			for (IEnumerator en = table.Rows.GetEnumerator(); en.MoveNext(); )
			{
				DataRow row = ((DataRow) en.Current);
				s += row[0] + "=" + row[1] + ";\n";
			}

			s += DIMENSION + "=" + dimensionUpDown.Value + ";\n";

			//MessageBox.Show(s);

			table.EndLoadData();
			return s;
		}

		private DataTable createFunctionTable(string source)
		{
			DataTable table = createDataTable();
			string[] ss = source.Split(';');

			for (int i = 0; i < ss.Length; i++)
			{
				string[] st = ss[i].Split('=');

				if (st.Length != 2) continue;
				st[0] = st[0].Trim();
				st[1] = st[1].Trim();

				if (st[0] == DIMENSION)
				{
					dimensionUpDown.Value = (int) Double.Parse(st[1]);
				}
				else
				{
					DataRow r = table.NewRow();
					r[0] = st[0].Trim();
					r[1] = st[1].Trim();
					table.Rows.Add(r);
				}
			}
			return table;
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (!isReadOnly)
			{
				function.SystemSource = createFunctionSource();
			}
			else
			{
				if (MessageBox.Show(this, "This dialog is started in readonly mode. Thats unable to save changes.\n Exit dialog?", "Readonly Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.DialogResult = DialogResult.Cancel;
				}
			}
			//event as response
		}

		private void function_FunctionAccepted()
		{
			this.DialogResult = DialogResult.OK;
		}

		private void function_FunctionWrongInput(string description)
		{
			MessageBox.Show(this, description);
		}

		public CFunction getFunction()
		{
			return function;
		}


		private const string TABLE = "system equation";
		private const string XML_FUNCTION = "function";
		private const string XML_EQUATION = "equation";

		private void loadXML(XmlReader rd)
		{
			//XML:
			// <function>
			//	 <equation>
			//     a=b+c
			//   </equation>
			//   ...
			// </function>

			//<function>
			if (!rd.Read()) throw XmlParseException.UnexpectedEnd();
			if (rd.NodeType != XmlNodeType.Element || rd.Name != XML_FUNCTION) throw XmlParseException.NodeExpected(XML_FUNCTION);

			string result = "";

			while (true)
			{
				if (!rd.Read()) throw XmlParseException.UnexpectedEnd();
				if (rd.NodeType == XmlNodeType.EndElement && rd.Name == XML_FUNCTION) break;

				if (rd.NodeType != XmlNodeType.Element || rd.Name != XML_EQUATION) throw XmlParseException.NodeExpected(XML_EQUATION);

				if (!rd.Read()) throw XmlParseException.UnexpectedEnd();

				if (rd.NodeType == XmlNodeType.Text)
				{
					result += rd.Value.Trim() + ";";

					if (!rd.Read()) throw XmlParseException.UnexpectedEnd();
				}
				if (rd.NodeType != XmlNodeType.EndElement || rd.Name != XML_EQUATION) throw XmlParseException.NodeExpected("/" + XML_EQUATION);
			}

			//</function>
			if (rd.NodeType != XmlNodeType.EndElement || rd.Name != XML_FUNCTION) throw XmlParseException.NodeExpected("/" + XML_FUNCTION);

			setSource(result);
		}

		private void setSource(string result)
		{
			formulas.DataSource = createFunctionTable(result);
		}

		private void writeXML(XmlWriter wr)
		{
			wr.WriteWhitespace("\n");
			wr.WriteStartElement(XML_FUNCTION);

				string s = createFunctionSource();
			string[] ss = s.Split(';');

			for (int i = 0; i < ss.Length; i++)
			{
				wr.WriteWhitespace("\n\t");
				wr.WriteStartElement(XML_EQUATION);

				wr.WriteWhitespace("\n\t\t");
				wr.WriteString(ss[i].Trim());

				wr.WriteWhitespace("\n\t");
				wr.WriteEndElement();
			}
			wr.WriteWhitespace("\n");
			wr.WriteEndElement();
		}


		private void menuLoad_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(openFileDialog.FileName);

				try
				{
					loadXML(new XmlNodeReader(doc.DocumentElement));
				}
				catch (XmlParseException ex)
				{
					MessageBox.Show(ex.Message, "Error opening file");
					dimensionUpDown_ValueChanged(this, EventArgs.Empty);
				}
			}
		}

		private void menuSave_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				XmlTextWriter wr = new XmlTextWriter(saveFileDialog.FileName, Encoding.GetEncoding(1251));
				wr.WriteStartDocument(true);

				writeXML(wr);

				wr.WriteEndDocument();
				wr.Close();
			}
		}

		private void SystemAssignment_WidthChanged(object sender, EventArgs e)
		{
			redesignGrid();
		}

		private void menuItemGetSource_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(createFunctionSource(), true);
		}
	}
}