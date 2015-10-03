using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Controls.Control;

namespace EugenePetrenko.Gui2.Controls.Grid
{
  public delegate void ContentChanged();

  public class ExGrid : UserControl, ISubmittable
  {
    private DataGrid grid;
    private Container components = null;
    private DataTable currentTable = null;
    private Hashtable /*<DataRow, IExGridRow>*/ rowToExGrid = null;

    private IExGridRow[] rows;
    private int dimension;

    public event ContentChanged DataChanged;

    public ExGrid() : this(0)
    {
    }

    public ExGrid(int dimension, params IExGridRow[] rows)
    {
      this.rows = rows;
      this.dimension = dimension;
      InitializeComponent();
      grid.ChangeUICues += new UICuesEventHandler(grid_ChangeUICues);
      FillGrid();
    }

    public IExGridRow[] Rows
    {
      get { return rows; }
    }

    public void SetRows(int dimension, params IExGridRow[] value)
    {
      this.dimension = dimension;
      rows = value;
      FillGrid();
    }

    public void ReLoadData()
    {
      FillGrid();
      grid.Update();
    }

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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.grid = new System.Windows.Forms.DataGrid();
      ((System.ComponentModel.ISupportInitialize) (this.grid)).BeginInit();
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
      ((System.ComponentModel.ISupportInitialize) (this.grid)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    private void FillGrid()
    {
      if (currentTable != null)
        currentTable.RowChanged -= new DataRowChangeEventHandler(table_RowChanged);

      rowToExGrid = new Hashtable();
      currentTable = new DataTable();
      currentTable.RowChanged += new DataRowChangeEventHandler(table_RowChanged);

      DataColumn column = new DataColumn("Parameter", typeof (string));
      column.ReadOnly = true;
      currentTable.Columns.Add(column);

      for (int i = 1; i <= dimension; i++)
      {
        column = new DataColumn("x" + i);
        currentTable.Columns.Add(column);
      }


      foreach (IExGridRow info in rows)
      {
        DataRow row = currentTable.NewRow();
        row[0] = info.Caption;
        for (int j = 0; j < dimension; j++)
        {
          row[j + 1] = info[j];
        }
        currentTable.Rows.Add(row);
        rowToExGrid[row] = info;
      }

      DataView dataView = new DataView(currentTable);
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

      DataView view = (DataView) grid.DataSource;
      DataTable table = view.Table;

      for (int i = 0; i < rows.Length; i++)
      {
        DataRow row = table.Rows[i];
        IExGridRow info = rows[i];

        for (int j = 0; j < dimension; j++)
        {
          try
          {
            if (row[j + 1] != null)
            {
              info[j] = row[j + 1].ToString();
            }
            else
              throw new ExGridCellException(j, "Empty parameter at {0}.");
          }
          catch (ExGridCellException e)
          {
            string pos = string.Format("column {0}, row {1}", table.Columns[j + 1].Caption, row[0].ToString());
            throw new ExGridException(e.MessageTemplate, pos);
          }
        }
      }
    }

    private void grid_ChangeUICues(object sender, UICuesEventArgs e)
    {
      if (DataChanged != null)
      {
        DataChanged();
      }
    }

    private void table_RowChanged(object sender, DataRowChangeEventArgs e)
    {
      IExGridHandler h = rowToExGrid[e.Row] as IExGridHandler;
      if (h != null)
      {
        if (!h.NeedAcceptRowChanged())
        {
          //e.Row.RejectChanges();
        }
      }
    }
  }
}