using System.Windows.Forms;
using DSIS.UI.Controls;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  partial class RepeatWhileControlBase
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
      this.myEnabled = new System.Windows.Forms.CheckBox();
      this.myValue = new LongValueTextBox();
      myLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // myEnabled
      // 
      this.myEnabled.AutoSize = true;
      this.myEnabled.Location = new System.Drawing.Point(3, 3);
      this.myEnabled.Name = "myEnabled";
      this.myEnabled.Size = new System.Drawing.Size(142, 17);
      this.myEnabled.TabIndex = 0;
      this.myEnabled.Text = "Repeat while there are <";
      this.myEnabled.UseVisualStyleBackColor = true;
      // 
      // myValue
      // 
      this.myValue.Location = new System.Drawing.Point(151, 0);
      this.myValue.Name = "myValue";
      this.myValue.Size = new System.Drawing.Size(44, 20);
      this.myValue.TabIndex = 1;
      // 
      // label
      // 
      myLabel.AutoSize = true;
      myLabel.Location = new System.Drawing.Point(201, 4);
      myLabel.Name = "label";
      myLabel.Size = new System.Drawing.Size(65, 13);
      myLabel.TabIndex = 2;
      myLabel.Text = "components";
      // 
      // RepeatWhileControlBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(myLabel);
      this.Controls.Add(this.myValue);
      this.Controls.Add(this.myEnabled);
      this.Name = "RepeatWhileControlBase";
      this.Size = new System.Drawing.Size(279, 23);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox myEnabled;
    private LongValueTextBox myValue;
    private Label myLabel;
  }
}