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
      this.myHost = new System.Windows.Forms.Panel();
      this.myErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.myTotal = new DSIS.UI.ComputationDialogs.TotalSubdivisionFieldControl();
      this.headerSubdivisionFieldControl1 = new DSIS.UI.ComputationDialogs.HeaderSubdivisionFieldControl();
      this.myUseUnsimmetricCheckbox = new System.Windows.Forms.CheckBox();
      this.myRepeatPluginsHost = new System.Windows.Forms.Panel();
      this.myRepeatCheckbox = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // myHost
      // 
      this.myHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myHost.Location = new System.Drawing.Point(3, 36);
      this.myHost.Name = "myHost";
      this.myHost.Size = new System.Drawing.Size(422, 49);
      this.myHost.TabIndex = 3;
      // 
      // myErrorProvider
      // 
      this.myErrorProvider.ContainerControl = this;
      // 
      // myTotal
      // 
      this.myTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myTotal.Location = new System.Drawing.Point(3, 91);
      this.myTotal.Name = "myTotal";
      this.myTotal.Size = new System.Drawing.Size(422, 27);
      this.myTotal.SubdivisionValue = ((long)(99));
      this.myTotal.TabIndex = 4;
      // 
      // headerSubdivisionFieldControl1
      // 
      this.headerSubdivisionFieldControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.headerSubdivisionFieldControl1.Location = new System.Drawing.Point(3, 3);
      this.headerSubdivisionFieldControl1.Name = "headerSubdivisionFieldControl1";
      this.headerSubdivisionFieldControl1.Size = new System.Drawing.Size(422, 27);
      this.headerSubdivisionFieldControl1.TabIndex = 0;
      // 
      // myUseUnsimmetricCheckbox
      // 
      this.myUseUnsimmetricCheckbox.AutoSize = true;
      this.myUseUnsimmetricCheckbox.Location = new System.Drawing.Point(29, 124);
      this.myUseUnsimmetricCheckbox.Name = "myUseUnsimmetricCheckbox";
      this.myUseUnsimmetricCheckbox.Size = new System.Drawing.Size(226, 17);
      this.myUseUnsimmetricCheckbox.TabIndex = 5;
      this.myUseUnsimmetricCheckbox.Text = "Construct with minimal possible subdivision";
      this.myUseUnsimmetricCheckbox.UseVisualStyleBackColor = true;
      // 
      // myRepeatPluginsHost
      // 
      this.myRepeatPluginsHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myRepeatPluginsHost.Location = new System.Drawing.Point(29, 170);
      this.myRepeatPluginsHost.Name = "myRepeatPluginsHost";
      this.myRepeatPluginsHost.Size = new System.Drawing.Size(396, 37);
      this.myRepeatPluginsHost.TabIndex = 6;
      // 
      // myRepeatCheckbox
      // 
      this.myRepeatCheckbox.AutoSize = true;
      this.myRepeatCheckbox.Location = new System.Drawing.Point(29, 147);
      this.myRepeatCheckbox.Name = "myRepeatCheckbox";
      this.myRepeatCheckbox.Size = new System.Drawing.Size(165, 17);
      this.myRepeatCheckbox.TabIndex = 7;
      this.myRepeatCheckbox.Text = "Repeat construction process:";
      this.myRepeatCheckbox.UseVisualStyleBackColor = true;
      this.myRepeatCheckbox.CheckedChanged += new System.EventHandler(this.myRepeatCheckbox_CheckedChanged);
      // 
      // SubdivisionEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.myRepeatCheckbox);
      this.Controls.Add(this.myRepeatPluginsHost);
      this.Controls.Add(this.myUseUnsimmetricCheckbox);
      this.Controls.Add(this.myTotal);
      this.Controls.Add(this.headerSubdivisionFieldControl1);
      this.Controls.Add(this.myHost);
      this.Name = "SubdivisionEditorControl";
      this.Size = new System.Drawing.Size(428, 218);
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel myHost;
    private HeaderSubdivisionFieldControl headerSubdivisionFieldControl1;
    private TotalSubdivisionFieldControl myTotal;
    private System.Windows.Forms.ErrorProvider myErrorProvider;
    private System.Windows.Forms.CheckBox myUseUnsimmetricCheckbox;
    private System.Windows.Forms.CheckBox myRepeatCheckbox;
    private System.Windows.Forms.Panel myRepeatPluginsHost;
  }
}