using System.ComponentModel;
using System.Windows.Forms;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2;

namespace EugenePetrenko.Gui2.Visualization.src.actionImpl.GnuPlot2
{
  /// <summary>
  /// Summary description for ShowImageControl.
  /// </summary>
  public class ShowImageControl : UserControl
  {
    private Panel panelMain;
    private Panel panelImageSize;
    private ReduceImageSizeControl reduceImageSize;
    private AdditionalSettingsControl additionalSettings;
    private Panel panelAdditional;
    private Panel panelShowStyle;
    private ShowStyleControl showStyleControl;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    public ShowImageControl()
    {
      InitializeComponent();
      reduceImageSize.Visible = false;

      showStyleControl.SetControlData(ResourceManager.Instance.GetXmlResourceFromCommon("gnuplot"));
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

    public IParameters SubmitData()
    {
      return new GnuPlotParametersImpl(
        null,
        showStyleControl.SelectedValue,
        reduceImageSize.GetImageSize().Width,
        reduceImageSize.GetImageSize().Height,
        additionalSettings.IsShowHistoryChecked,
        false,
        true,
        additionalSettings.IsDrawBoxesChecked
        );
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.panelMain = new System.Windows.Forms.Panel();
      this.panelAdditional = new System.Windows.Forms.Panel();
      this.additionalSettings = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.AdditionalSettingsControl();
      this.panelImageSize = new System.Windows.Forms.Panel();
      this.reduceImageSize = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ReduceImageSizeControl();
      this.panelShowStyle = new System.Windows.Forms.Panel();
      this.showStyleControl = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ShowStyleControl();
      this.panelMain.SuspendLayout();
      this.panelAdditional.SuspendLayout();
      this.panelImageSize.SuspendLayout();
      this.panelShowStyle.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.panelShowStyle);
      this.panelMain.Controls.Add(this.panelAdditional);
      this.panelMain.Controls.Add(this.panelImageSize);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(360, 432);
      this.panelMain.TabIndex = 0;
      // 
      // panelAdditional
      // 
      this.panelAdditional.Controls.Add(this.additionalSettings);
      this.panelAdditional.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelAdditional.Location = new System.Drawing.Point(0, 120);
      this.panelAdditional.Name = "panelAdditional";
      this.panelAdditional.Size = new System.Drawing.Size(360, 64);
      this.panelAdditional.TabIndex = 0;
      // 
      // additionalSettings
      // 
      this.additionalSettings.Dock = System.Windows.Forms.DockStyle.Top;
      this.additionalSettings.DockPadding.All = 5;
      this.additionalSettings.IsDrawBoxesChecked = false;
      this.additionalSettings.IsShowHistoryChecked = true;
      this.additionalSettings.Location = new System.Drawing.Point(0, 0);
      this.additionalSettings.Name = "additionalSettings";
      this.additionalSettings.Size = new System.Drawing.Size(360, 55);
      this.additionalSettings.TabIndex = 2;
      // 
      // panelImageSize
      // 
      this.panelImageSize.Controls.Add(this.reduceImageSize);
      this.panelImageSize.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelImageSize.Location = new System.Drawing.Point(0, 0);
      this.panelImageSize.Name = "panelImageSize";
      this.panelImageSize.Size = new System.Drawing.Size(360, 120);
      this.panelImageSize.TabIndex = 0;
      // 
      // reduceImageSize
      // 
      this.reduceImageSize.AllowImageSizeWithoutReduse = false;
      this.reduceImageSize.Dock = System.Windows.Forms.DockStyle.Top;
      this.reduceImageSize.DockPadding.Bottom = 10;
      this.reduceImageSize.DockPadding.Left = 5;
      this.reduceImageSize.DockPadding.Right = 5;
      this.reduceImageSize.DockPadding.Top = 5;
      this.reduceImageSize.Location = new System.Drawing.Point(0, 0);
      this.reduceImageSize.Name = "reduceImageSize";
      this.reduceImageSize.NeedResizeInside = false;
      this.reduceImageSize.Reduse = false;
      this.reduceImageSize.Size = new System.Drawing.Size(360, 124);
      this.reduceImageSize.TabIndex = 0;
      // 
      // panelShowStyle
      // 
      this.panelShowStyle.Controls.Add(this.showStyleControl);
      this.panelShowStyle.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelShowStyle.DockPadding.All = 5;
      this.panelShowStyle.Location = new System.Drawing.Point(0, 184);
      this.panelShowStyle.Name = "panelShowStyle";
      this.panelShowStyle.Size = new System.Drawing.Size(360, 40);
      this.panelShowStyle.TabIndex = 1;
      // 
      // showStyleControl
      // 
      this.showStyleControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.showStyleControl.Location = new System.Drawing.Point(5, 5);
      this.showStyleControl.Name = "showStyleControl";
      this.showStyleControl.Size = new System.Drawing.Size(350, 30);
      this.showStyleControl.TabIndex = 0;
      // 
      // ShowImageControl
      // 
      this.AutoScroll = true;
      this.AutoScrollMinSize = new System.Drawing.Size(360, 0);
      this.Controls.Add(this.panelMain);
      this.Name = "ShowImageControl";
      this.Size = new System.Drawing.Size(360, 432);
      this.panelMain.ResumeLayout(false);
      this.panelAdditional.ResumeLayout(false);
      this.panelImageSize.ResumeLayout(false);
      this.panelShowStyle.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    #endregion
  }
}