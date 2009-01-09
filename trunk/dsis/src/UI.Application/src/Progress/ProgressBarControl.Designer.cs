namespace DSIS.UI.Application.Progress
{
  partial class ProgressBarControl
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
      this.myProgressBar = new System.Windows.Forms.ProgressBar();
      this.myMainLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // myProgressBar
      // 
      this.myProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myProgressBar.Location = new System.Drawing.Point(3, 18);
      this.myProgressBar.Name = "myProgressBar";
      this.myProgressBar.Size = new System.Drawing.Size(511, 23);
      this.myProgressBar.TabIndex = 0;
      // 
      // myMainLabel
      // 
      this.myMainLabel.Location = new System.Drawing.Point(3, 0);
      this.myMainLabel.Name = "myMainLabel";
      this.myMainLabel.Size = new System.Drawing.Size(511, 15);
      this.myMainLabel.TabIndex = 1;
      this.myMainLabel.Text = "Progress bar text";
      this.myMainLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      // 
      // ProgressBarControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.myMainLabel);
      this.Controls.Add(this.myProgressBar);
      this.Name = "ProgressBarControl";
      this.Size = new System.Drawing.Size(517, 47);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar myProgressBar;
    private System.Windows.Forms.Label myMainLabel;
  }
}