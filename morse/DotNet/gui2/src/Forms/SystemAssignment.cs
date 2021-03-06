using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EugenePetrenko.Gui2.Application.Document;
using EugenePetrenko.Gui2.Application.SystemFunctions;
using EugenePetrenko.Gui2.Kernel2.Document;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.Forms
{
  public class SystemAssignment : Form
  {
    private const string DIMENSION = "_dimension";
    private readonly bool isReadOnly;
    private readonly PredefinedFunctions predefinedFunctions = new PredefinedFunctions();


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
    private MenuItem menuPredefined;
    private Function function = null;

    public SystemAssignment() : this(false)
    {
      isReadOnly = false;
    }

    public SystemAssignment(bool showOpen)
    {
      InitializeComponent();

      menuItemGetSource.Visible = Runner.Runner.Instance.IsInternal;

      menuPredefined.MenuItems.Clear();
      menuPredefined.MenuItems.AddRange(BuildMenuItems(predefinedFunctions.PredefinedSystems));

      dimensionUpDown_ValueChanged(this, EventArgs.Empty);
      isReadOnly = false;

      RedesignGrid();

      if (showOpen)
      {
        menuLoad_Click(this, EventArgs.Empty);
      }
    }

    public SystemAssignment(Function function) : this()
    {
      SetSource(function.Equations);
      isReadOnly = true;
    }

    private void RedesignGrid()
    {
      DataGridTableStyle style;
      if (formulas.TableStyles.Count == 0)
      {
        style = new DataGridTableStyle();
        formulas.TableStyles.Add(style);
      }
      else
      {
        style = formulas.TableStyles[0];
      }

      if (!(formulas.DataSource is DataTable)) 
        return;

      var table = formulas.DataSource as DataTable;

      var w = (int) (formulas.ClientSize.Width*0.90);

      for (int i = 0; i < table.Columns.Count - 2; i++)
      {
        w -= style.GridColumnStyles[i].Width;
        style.GridColumnStyles[i].WidthChanged += SystemAssignment_WidthChanged;
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
      this.menuPredefined = new System.Windows.Forms.MenuItem();
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
      this.groupBox1.Text = "Discrete system";
      // 
      // label1
      // 
      this.label1.Font =
        new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold,
                                System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
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
      this.formulas.AlternatingBackColor = System.Drawing.Color.GhostWhite;
      this.formulas.BackColor = System.Drawing.Color.GhostWhite;
      this.formulas.BackgroundColor = System.Drawing.Color.Lavender;
      this.formulas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.formulas.CaptionBackColor = System.Drawing.Color.RoyalBlue;
      this.formulas.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
      this.formulas.CaptionForeColor = System.Drawing.Color.White;
      this.formulas.DataMember = "";
      this.formulas.FlatMode = true;
      this.formulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
      this.formulas.ForeColor = System.Drawing.Color.MidnightBlue;
      this.formulas.GridLineColor = System.Drawing.Color.RoyalBlue;
      this.formulas.HeaderBackColor = System.Drawing.Color.MidnightBlue;
      this.formulas.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
      this.formulas.HeaderForeColor = System.Drawing.Color.Lavender;
      this.formulas.ImeMode = System.Windows.Forms.ImeMode.Katakana;
      this.formulas.LinkColor = System.Drawing.Color.Teal;
      this.formulas.Location = new System.Drawing.Point(16, 56);
      this.formulas.Name = "formulas";
      this.formulas.ParentRowsBackColor = System.Drawing.Color.Lavender;
      this.formulas.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
      this.formulas.SelectionBackColor = System.Drawing.Color.Teal;
      this.formulas.SelectionForeColor = System.Drawing.Color.PaleGreen;
      this.formulas.Size = new System.Drawing.Size(464, 296);
      this.formulas.TabIndex = 0;
      // 
      // btnNext
      // 
      this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNext.Location = new System.Drawing.Point(376, 392);
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
      this.btnCancel.Location = new System.Drawing.Point(8, 392);
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
                                           this.menuPredefined,
                                           this.menuLoad,
                                           this.menuSave,
                                           this.menuItemGetSource
                                         });
      // 
      // menuLoad
      // 
      this.menuLoad.Index = 1;
      this.menuLoad.Text = "Load";
      this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
      // 
      // menuSave
      // 
      this.menuSave.Index = 2;
      this.menuSave.Text = "Save";
      this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
      // 
      // menuItemGetSource
      // 
      this.menuItemGetSource.Index = 3;
      this.menuItemGetSource.Text = "GetSource";
      this.menuItemGetSource.Click += new System.EventHandler(this.menuItemGetSource_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "equation";
      this.openFileDialog.Filter = "Equation files(*.equation)|*.equation|All files(*.*)|*.*";
      this.openFileDialog.Title = "Select equation to open";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "equation";
      this.saveFileDialog.FileName = "equation";
      this.saveFileDialog.Filter = "Equation files(*.equation)|*.equation|All files(*.*)|*.*";
      this.saveFileDialog.Title = "Save System Equation";
      // 
      // menuItem1
      // 
      this.menuPredefined.Index = 0;
      this.menuPredefined.Text = "Predefined";
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

    private static DataTable CreateDataTable()
    {
      var table = new DataTable();
      table.Columns.Add(new DataColumn("variable")
                          {
                            ReadOnly = false, 
                            DataType = typeof (string),
                            DefaultValue = ""
                          });

      table.Columns.Add(new DataColumn("expression")
                          {
                            ReadOnly = false, 
                            DataType = typeof (string), 
                            DefaultValue = "0"
                          });

      return table;
    }

    private void dimensionUpDown_ValueChanged(object sender, EventArgs e)
    {
      #region "table initalization"

      DataTable table = CreateDataTable();


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
      RedesignGrid();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private string[] CreateFunctionSource()
    {
      formulas.Refresh();
      formulas.Update();
      formulas.Focus();
      var table = (DataTable) formulas.DataSource;

      table.AcceptChanges();
      table.BeginLoadData();

      var strings = new List<string>();
      for (IEnumerator en = table.Rows.GetEnumerator(); en.MoveNext();)
      {
        var row = ((DataRow) en.Current);
        strings.Add(row[0] + "=" + row[1]);
      }

      strings.Add(DIMENSION + "=" + dimensionUpDown.Value);

      table.EndLoadData();
      return strings.ToArray();
    }

    private DataTable CreateFunctionTable(IEnumerable<string> source)
    {
      var table = CreateDataTable();

      foreach (var ss in source)
      {
        var st = ss.Split(new[]{'='},StringSplitOptions.RemoveEmptyEntries);

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

    private Function CreateFunction()
    {
      try
      {
        return new Function(CreateFunctionSource());
      }
      catch (FunctionExceptions ee)
      {
        Logger.LogException(ee);
        MessageBox.Show(this, ee.Message, "Error in Function");
        return null;
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (!isReadOnly)
      {
        function = CreateFunction();
        if (function != null)
        {
          DialogResult = DialogResult.OK;
        }
      }
      else
      {
        if (
          MessageBox.Show(this, "This dialog is started in readonly mode. Thats unable to save changes.\n Exit dialog?",
                          "Readonly Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          DialogResult = DialogResult.Cancel;
        }
      }
    }

    public Function Function
    {
      get { return function; }
    }

    private void SetSource(IEnumerable<string> result)
    {
      formulas.DataSource = CreateFunctionTable(result);
    }

    private void menuLoad_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        string fileName = openFileDialog.FileName;
        var document = new XmlDocument();
        document.Load(fileName);

        try
        {
          LoadFunctionFromXml(document);
        }
        catch (Exception ee)
        {
          MessageBox.Show(this, ee.Message, "Failed to load function", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void LoadFunctionFromXml(XmlNode document)
    {
      SetSource(FunctionSerializer.LoadFunction(document).Equations);
    }

    private void menuSave_Click(object sender, EventArgs e)
    {
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        string fileName = saveFileDialog.FileName;
        XmlDocument document = XmlUtil.CreateEmptyDocument();

        Function fun = CreateFunction();
        if (fun != null)
        {
          XmlNode newNode = FunctionSerializer.SaveFunction(fun);
          XmlUtil.SetRootNode(document, newNode);

          using (TextWriter writer = File.CreateText(fileName))
          {
            document.Save(writer);
          }
        }
      }
    }

    private void SystemAssignment_WidthChanged(object sender, EventArgs e)
    {
      RedesignGrid();
    }

    private void menuItemGetSource_Click(object sender, EventArgs e)
    {
      Clipboard.SetDataObject(CreateFunctionSource(), true);
    }

    private MenuItem[] BuildMenuItems(string[] names)
    {
      var items = new ArrayList(names.Length);
      foreach (string name in names)
      {
        items.Add(new MyMenuItem(this, name));
      }
      return (MenuItem[]) items.ToArray(typeof (MenuItem));
    }

    private void PerformPredefinedSelected(string name)
    {
      XmlNode node = predefinedFunctions.GetFunction(name);
      LoadFunctionFromXml(node);
    }

    private class MyMenuItem : MenuItem
    {
      private readonly SystemAssignment assignment;
      private readonly string name;

      public MyMenuItem(SystemAssignment assignment, string name) : base(name)
      {
        this.assignment = assignment;
        this.name = name;
      }

      protected override void OnClick(EventArgs e)
      {
        assignment.PerformPredefinedSelected(name);
      }
    }
  }
}