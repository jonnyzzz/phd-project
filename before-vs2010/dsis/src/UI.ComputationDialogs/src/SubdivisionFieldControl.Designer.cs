namespace DSIS.UI.ComputationDialogs
{
  partial class SubdivisionFieldControl
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
      System.Windows.Forms.Label lblX;
      System.Windows.Forms.Label lblEq;
      this.myLabel = new System.Windows.Forms.Label();
      this.myActualValueText = new System.Windows.Forms.TextBox();
      this.myEstimateText = new System.Windows.Forms.TextBox();
      this.mySubdivisionText = new System.Windows.Forms.TextBox();
      lblX = new System.Windows.Forms.Label();
      lblEq = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblX
      // 
      lblX.AutoSize = true;
      lblX.Location = new System.Drawing.Point(163, 6);
      lblX.Name = "lblX";
      lblX.Size = new System.Drawing.Size(14, 13);
      lblX.TabIndex = 4;
      lblX.Text = "X";
      // 
      // lblEq
      // 
      lblEq.AutoSize = true;
      lblEq.Location = new System.Drawing.Point(289, 6);
      lblEq.Name = "lblEq";
      lblEq.Size = new System.Drawing.Size(13, 13);
      lblEq.TabIndex = 5;
      lblEq.Text = "=";
      // 
      // myLabel
      // 
      this.myLabel.AutoSize = true;
      this.myLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.myLabel.Location = new System.Drawing.Point(3, 6);
      this.myLabel.Name = "myLabel";
      this.myLabel.Size = new System.Drawing.Size(41, 13);
      this.myLabel.TabIndex = 0;
      this.myLabel.Text = "label1";
      // 
      // myActualValueText
      // 
      this.myActualValueText.Location = new System.Drawing.Point(57, 3);
      this.myActualValueText.Name = "myActualValueText";
      this.myActualValueText.ReadOnly = true;
      this.myActualValueText.Size = new System.Drawing.Size(100, 20);
      this.myActualValueText.TabIndex = 1;
      this.myActualValueText.TabStop = false;
      // 
      // myEstimateText
      // 
      this.myEstimateText.Location = new System.Drawing.Point(308, 3);
      this.myEstimateText.Name = "myEstimateText";
      this.myEstimateText.ReadOnly = true;
      this.myEstimateText.Size = new System.Drawing.Size(100, 20);
      this.myEstimateText.TabIndex = 3;
      this.myEstimateText.TabStop = false;
      // 
      // mySubdivisionText
      // 
      this.mySubdivisionText.Location = new System.Drawing.Point(183, 3);
      this.mySubdivisionText.Name = "mySubdivisionText";
      this.mySubdivisionText.Size = new System.Drawing.Size(100, 20);
      this.mySubdivisionText.TabIndex = 2;
      // 
      // SubdivisionFieldControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(lblEq);
      this.Controls.Add(lblX);
      this.Controls.Add(this.mySubdivisionText);
      this.Controls.Add(this.myEstimateText);
      this.Controls.Add(this.myActualValueText);
      this.Controls.Add(this.myLabel);
      this.Name = "SubdivisionFieldControl";
      this.Size = new System.Drawing.Size(414, 27);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label myLabel;
    protected System.Windows.Forms.TextBox myActualValueText;
    protected System.Windows.Forms.TextBox myEstimateText;
    protected System.Windows.Forms.TextBox mySubdivisionText;
  }
}