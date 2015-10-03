using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2
{
  /// <summary>
  /// Summary description for AdditionalSettingsControl.
  /// </summary>
  public class AdditionalSettingsControl : UserControl
  {
    private GroupBox groupBoxAdditional;
    private CheckBox checkBoxDrawBoxes;
    private CheckBox checkBoxShowHistory;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    public bool IsShowHistoryChecked
    {
      get { return checkBoxShowHistory.Checked; }
      set { checkBoxShowHistory.Checked = value; }
    }

    public bool IsDrawBoxesChecked
    {
      get { return checkBoxDrawBoxes.Checked; }
      set { checkBoxDrawBoxes.Checked = value; }
    }

    public AdditionalSettingsControl()
    {
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

    private bool isInSizeChanged = false;

    protected override void OnSizeChanged(EventArgs e)
    {
      if (!isInSizeChanged)
      {
        isInSizeChanged = true;
        Size = new Size(Size.Width, groupBoxAdditional.Size.Height + DockPadding.Bottom + DockPadding.Top + 5);
        base.OnSizeChanged(e);
        isInSizeChanged = false;
      }
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBoxAdditional = new System.Windows.Forms.GroupBox();
      this.checkBoxDrawBoxes = new System.Windows.Forms.CheckBox();
      this.checkBoxShowHistory = new System.Windows.Forms.CheckBox();
      this.groupBoxAdditional.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBoxAdditional
      // 
      this.groupBoxAdditional.Controls.Add(this.checkBoxDrawBoxes);
      this.groupBoxAdditional.Controls.Add(this.checkBoxShowHistory);
      this.groupBoxAdditional.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBoxAdditional.Location = new System.Drawing.Point(5, 5);
      this.groupBoxAdditional.Name = "groupBoxAdditional";
      this.groupBoxAdditional.Size = new System.Drawing.Size(198, 40);
      this.groupBoxAdditional.TabIndex = 2;
      this.groupBoxAdditional.TabStop = false;
      this.groupBoxAdditional.Text = "Additional";
      // 
      // checkBoxDrawBoxes
      // 
      this.checkBoxDrawBoxes.Dock = System.Windows.Forms.DockStyle.Left;
      this.checkBoxDrawBoxes.Enabled = false;
      this.checkBoxDrawBoxes.Location = new System.Drawing.Point(96, 16);
      this.checkBoxDrawBoxes.Name = "checkBoxDrawBoxes";
      this.checkBoxDrawBoxes.Size = new System.Drawing.Size(88, 21);
      this.checkBoxDrawBoxes.TabIndex = 1;
      this.checkBoxDrawBoxes.Text = "Draw Boxes";
      this.checkBoxDrawBoxes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // checkBoxShowHistory
      // 
      this.checkBoxShowHistory.Dock = System.Windows.Forms.DockStyle.Left;
      this.checkBoxShowHistory.Location = new System.Drawing.Point(3, 16);
      this.checkBoxShowHistory.Name = "checkBoxShowHistory";
      this.checkBoxShowHistory.Size = new System.Drawing.Size(93, 21);
      this.checkBoxShowHistory.TabIndex = 0;
      this.checkBoxShowHistory.Text = "Show History";
      // 
      // AdditionalSettingsControl
      // 
      this.Controls.Add(this.groupBoxAdditional);
      this.DockPadding.All = 5;
      this.Name = "AdditionalSettingsControl";
      this.Size = new System.Drawing.Size(208, 72);
      this.groupBoxAdditional.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    #endregion
  }
}