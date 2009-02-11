namespace DSIS.UI.ComputationDialogs.Constraints
{
  partial class RepeatCountToolControl
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
      System.Windows.Forms.Label label;
      this.myEnabled = new System.Windows.Forms.CheckBox();
      this.myTimes = new System.Windows.Forms.TextBox();
      label = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label
      // 
      label.AutoSize = true;
      label.Location = new System.Drawing.Point(132, 6);
      label.Name = "label";
      label.Size = new System.Drawing.Size(34, 13);
      label.TabIndex = 2;
      label.Text = "times.";
      // 
      // myEnabled
      // 
      this.myEnabled.AutoSize = true;
      this.myEnabled.Location = new System.Drawing.Point(3, 5);
      this.myEnabled.Name = "myEnabled";
      this.myEnabled.Size = new System.Drawing.Size(61, 17);
      this.myEnabled.TabIndex = 0;
      this.myEnabled.Text = "Repeat";
      this.myEnabled.UseVisualStyleBackColor = true;
      this.myEnabled.CheckedChanged += new System.EventHandler(this.myEnabled_CheckedChanged);
      // 
      // myTimes
      // 
      this.myTimes.Location = new System.Drawing.Point(70, 3);
      this.myTimes.Name = "myTimes";
      this.myTimes.Size = new System.Drawing.Size(56, 20);
      this.myTimes.TabIndex = 1;
      this.myTimes.TextChanged += new System.EventHandler(this.myTimes_TextChanged);
      // 
      // RepeatCountToolControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(label);
      this.Controls.Add(this.myTimes);
      this.Controls.Add(this.myEnabled);
      this.Name = "RepeatCountToolControl";
      this.Size = new System.Drawing.Size(182, 27);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox myEnabled;
    private System.Windows.Forms.TextBox myTimes;
  }
}