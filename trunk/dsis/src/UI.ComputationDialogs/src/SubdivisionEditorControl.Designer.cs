namespace DSIS.UI.ComputationDialogs
{
  partial class SubdivisionEditorControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Panel panelHeader;
      System.Windows.Forms.Panel panelTotal;
      DSIS.UI.ComputationDialogs.HeaderSubdivisionFieldControl headerSubdivisionFieldControl1;
      this.myHost = new System.Windows.Forms.Panel();
      this.myErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.myUseUnsimmetricCheckbox = new System.Windows.Forms.CheckBox();
      this.myRepeatPluginsHost = new System.Windows.Forms.Panel();
      this.myRepeatCheckbox = new System.Windows.Forms.CheckBox();
      this.panelCheckBoxes = new System.Windows.Forms.Panel();
      this.myTotal = new DSIS.UI.ComputationDialogs.TotalSubdivisionFieldControl();
      panelHeader = new System.Windows.Forms.Panel();
      panelTotal = new System.Windows.Forms.Panel();
      headerSubdivisionFieldControl1 = new DSIS.UI.ComputationDialogs.HeaderSubdivisionFieldControl();
      panelHeader.SuspendLayout();
      panelTotal.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).BeginInit();
      this.panelCheckBoxes.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelHeader
      // 
      panelHeader.Controls.Add(headerSubdivisionFieldControl1);
      panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
      panelHeader.Location = new System.Drawing.Point(0, 0);
      panelHeader.Name = "panelHeader";
      panelHeader.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      panelHeader.Size = new System.Drawing.Size(419, 30);
      panelHeader.TabIndex = 8;
      // 
      // panelTotal
      // 
      panelTotal.Controls.Add(this.myTotal);
      panelTotal.Dock = System.Windows.Forms.DockStyle.Top;
      panelTotal.Location = new System.Drawing.Point(0, 50);
      panelTotal.Name = "panelTotal";
      panelTotal.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
      panelTotal.Size = new System.Drawing.Size(419, 37);
      panelTotal.TabIndex = 9;
      // 
      // myHost
      // 
      this.myHost.Dock = System.Windows.Forms.DockStyle.Top;
      this.myHost.Location = new System.Drawing.Point(0, 30);
      this.myHost.Name = "myHost";
      this.myHost.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.myHost.Size = new System.Drawing.Size(419, 20);
      this.myHost.TabIndex = 1;
      // 
      // myErrorProvider
      // 
      this.myErrorProvider.ContainerControl = this;
      // 
      // myUseUnsimmetricCheckbox
      // 
      this.myUseUnsimmetricCheckbox.AutoSize = true;
      this.myUseUnsimmetricCheckbox.Location = new System.Drawing.Point(63, 13);
      this.myUseUnsimmetricCheckbox.Name = "myUseUnsimmetricCheckbox";
      this.myUseUnsimmetricCheckbox.Size = new System.Drawing.Size(226, 17);
      this.myUseUnsimmetricCheckbox.TabIndex = 3;
      this.myUseUnsimmetricCheckbox.Text = "Construct with minimal possible subdivision";
      this.myUseUnsimmetricCheckbox.UseVisualStyleBackColor = true;
      // 
      // myRepeatPluginsHost
      // 
      this.myRepeatPluginsHost.Dock = System.Windows.Forms.DockStyle.Top;
      this.myRepeatPluginsHost.Location = new System.Drawing.Point(0, 141);
      this.myRepeatPluginsHost.Name = "myRepeatPluginsHost";
      this.myRepeatPluginsHost.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
      this.myRepeatPluginsHost.Size = new System.Drawing.Size(419, 30);
      this.myRepeatPluginsHost.TabIndex = 5;
      this.myRepeatPluginsHost.TabStop = true;
      // 
      // myRepeatCheckbox
      // 
      this.myRepeatCheckbox.AutoSize = true;
      this.myRepeatCheckbox.Location = new System.Drawing.Point(63, 36);
      this.myRepeatCheckbox.Name = "myRepeatCheckbox";
      this.myRepeatCheckbox.Size = new System.Drawing.Size(165, 17);
      this.myRepeatCheckbox.TabIndex = 4;
      this.myRepeatCheckbox.Text = "Repeat construction process:";
      this.myRepeatCheckbox.UseVisualStyleBackColor = true;
      this.myRepeatCheckbox.CheckedChanged += new System.EventHandler(this.RepeatCheckedChanged);
      // 
      // panelCheckBoxes
      // 
      this.panelCheckBoxes.Controls.Add(this.myUseUnsimmetricCheckbox);
      this.panelCheckBoxes.Controls.Add(this.myRepeatCheckbox);
      this.panelCheckBoxes.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelCheckBoxes.Location = new System.Drawing.Point(0, 87);
      this.panelCheckBoxes.Name = "panelCheckBoxes";
      this.panelCheckBoxes.Padding = new System.Windows.Forms.Padding(60, 10, 0, 0);
      this.panelCheckBoxes.Size = new System.Drawing.Size(419, 54);
      this.panelCheckBoxes.TabIndex = 10;
      // 
      // myTotal
      // 
      this.myTotal.Dock = System.Windows.Forms.DockStyle.Top;
      this.myTotal.Location = new System.Drawing.Point(5, 5);
      this.myTotal.Name = "myTotal";
      this.myTotal.Size = new System.Drawing.Size(414, 27);
      this.myTotal.SubdivisionValue = ((long)(99));
      this.myTotal.TabIndex = 2;
      this.myTotal.TabStop = false;
      // 
      // headerSubdivisionFieldControl1
      // 
      headerSubdivisionFieldControl1.Dock = System.Windows.Forms.DockStyle.Top;
      headerSubdivisionFieldControl1.Location = new System.Drawing.Point(5, 0);
      headerSubdivisionFieldControl1.Name = "headerSubdivisionFieldControl1";
      headerSubdivisionFieldControl1.Size = new System.Drawing.Size(414, 27);
      headerSubdivisionFieldControl1.TabIndex = 0;
      headerSubdivisionFieldControl1.TabStop = false;
      // 
      // SubdivisionEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.myRepeatPluginsHost);
      this.Controls.Add(this.panelCheckBoxes);
      this.Controls.Add(panelTotal);
      this.Controls.Add(this.myHost);
      this.Controls.Add(panelHeader);
      this.Name = "SubdivisionEditorControl";
      this.Size = new System.Drawing.Size(419, 182);
      panelHeader.ResumeLayout(false);
      panelTotal.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).EndInit();
      this.panelCheckBoxes.ResumeLayout(false);
      this.panelCheckBoxes.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel myHost;
    private TotalSubdivisionFieldControl myTotal;
    private System.Windows.Forms.ErrorProvider myErrorProvider;
    private System.Windows.Forms.CheckBox myUseUnsimmetricCheckbox;
    private System.Windows.Forms.CheckBox myRepeatCheckbox;
    private System.Windows.Forms.Panel myRepeatPluginsHost;
    private System.Windows.Forms.Panel panelCheckBoxes;
  }
}