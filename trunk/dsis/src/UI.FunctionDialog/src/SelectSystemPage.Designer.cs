namespace DSIS.UI.FunctionDialog
{
  partial class SelectSystemPage
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      this.myRadioDefineSystem = new System.Windows.Forms.RadioButton();
      this.myRadioPredefined = new System.Windows.Forms.RadioButton();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(22, 23);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(296, 13);
      label1.TabIndex = 2;
      label1.Text = "Alows user to create new system and use it throuh the system";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(22, 59);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(173, 13);
      label2.TabIndex = 3;
      label2.Text = "Use one of the systems from the list";
      // 
      // myRadioDefineSystem
      // 
      this.myRadioDefineSystem.AutoSize = true;
      this.myRadioDefineSystem.Enabled = false;
      this.myRadioDefineSystem.Location = new System.Drawing.Point(3, 3);
      this.myRadioDefineSystem.Name = "myRadioDefineSystem";
      this.myRadioDefineSystem.Size = new System.Drawing.Size(93, 17);
      this.myRadioDefineSystem.TabIndex = 0;
      this.myRadioDefineSystem.Text = "Define System";
      this.myRadioDefineSystem.UseVisualStyleBackColor = true;
      // 
      // myRadioPredefined
      // 
      this.myRadioPredefined.AutoSize = true;
      this.myRadioPredefined.Checked = true;
      this.myRadioPredefined.Location = new System.Drawing.Point(3, 39);
      this.myRadioPredefined.Name = "myRadioPredefined";
      this.myRadioPredefined.Size = new System.Drawing.Size(111, 17);
      this.myRadioPredefined.TabIndex = 1;
      this.myRadioPredefined.TabStop = true;
      this.myRadioPredefined.Text = "Predefined system";
      this.myRadioPredefined.UseVisualStyleBackColor = true;
      // 
      // SelectSystemPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(label2);
      this.Controls.Add(label1);
      this.Controls.Add(this.myRadioPredefined);
      this.Controls.Add(this.myRadioDefineSystem);
      this.Name = "SelectSystemPage";
      this.Size = new System.Drawing.Size(663, 91);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton myRadioDefineSystem;
    private System.Windows.Forms.RadioButton myRadioPredefined;
  }
}