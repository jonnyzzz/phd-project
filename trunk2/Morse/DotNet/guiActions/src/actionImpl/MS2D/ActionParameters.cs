using System;
using System.ComponentModel;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Grid;
using EugenePetrenko.Gui2.Controls.Grid.Rows;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D
{
  /// <summary>
  /// Summary description for ActionParameters.
  /// This class should be abstract
  /// </summary>
  public class ActionParameters : ParametersControl
  {
    private ExGrid exGrid;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    private IntPlusGridData data;

    public ActionParameters()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();

      data = new IntPlusGridData(ResourceManager.Strings.CellDivision, 3);
      exGrid.SetRows(3, data);
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.exGrid = new Controls.Grid.ExGrid();
      this.SuspendLayout();
      // 
      // exGrid
      // 
      this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exGrid.Location = new System.Drawing.Point(0, 0);
      this.exGrid.Name = "exGrid";
      this.exGrid.Size = new System.Drawing.Size(336, 336);
      this.exGrid.TabIndex = 0;
      // 
      // ActionParameters
      // 
      this.Controls.Add(this.exGrid);
      this.Name = "ActionParameters";
      this.Size = new System.Drawing.Size(336, 336);
      this.ResumeLayout(false);
    }

    #endregion

    public override string BoxCaption
    {
      get { return "Angle Method Projective Bundle Initial SI Creation"; }
    }

    protected virtual IParameters LoadParameters(int[] factor)
    {
      throw new NotImplementedException("Implement in inherotor");
    }

    protected override IParameters SubmitDataInternal()
    {
      exGrid.SubmitData();
      return LoadParameters(data.Data);
    }
  }
}