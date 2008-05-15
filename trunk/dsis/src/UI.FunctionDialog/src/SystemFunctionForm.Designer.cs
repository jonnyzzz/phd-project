namespace DSIS.UI.FunctionDialog.src
{
  partial class SystemFunctionForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mySpaceInfo = new DSIS.UI.FunctionDialog.SpaceControl();
      this.SuspendLayout();
      // 
      // mySpaceInfo
      // 
      this.mySpaceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.mySpaceInfo.Location = new System.Drawing.Point(12, 12);
      this.mySpaceInfo.Name = "mySpaceInfo";
      this.mySpaceInfo.Size = new System.Drawing.Size(494, 207);
      this.mySpaceInfo.TabIndex = 0;
      // 
      // SystemFunctionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(518, 231);
      this.Controls.Add(this.mySpaceInfo);
      this.MinimumSize = new System.Drawing.Size(520, 265);
      this.Name = "SystemFunctionForm";
      this.Text = "SystemFunctionForm";
      this.ResumeLayout(false);

    }

    #endregion

    private SpaceControl mySpaceInfo;
  }
}