namespace DSIS.UI.Wizard
{
  partial class HeaderControl
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
      this.myMainTitle = new System.Windows.Forms.Label();
      this.mySecondaryTitle = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // myMainTitle
      // 
      this.myMainTitle.AutoSize = true;
      this.myMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.myMainTitle.Location = new System.Drawing.Point(4, 4);
      this.myMainTitle.Name = "myMainTitle";
      this.myMainTitle.Size = new System.Drawing.Size(159, 24);
      this.myMainTitle.TabIndex = 0;
      this.myMainTitle.Text = "Header Main Title";
      // 
      // mySecondaryTitle
      // 
      this.mySecondaryTitle.AutoSize = true;
      this.mySecondaryTitle.Location = new System.Drawing.Point(28, 32);
      this.mySecondaryTitle.Name = "mySecondaryTitle";
      this.mySecondaryTitle.Size = new System.Drawing.Size(81, 13);
      this.mySecondaryTitle.TabIndex = 1;
      this.mySecondaryTitle.Text = "Secondary Title";
      // 
      // HeaderControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.Controls.Add(this.mySecondaryTitle);
      this.Controls.Add(this.myMainTitle);
      this.Name = "HeaderControl";
      this.Size = new System.Drawing.Size(658, 67);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label myMainTitle;
    private System.Windows.Forms.Label mySecondaryTitle;
  }
}