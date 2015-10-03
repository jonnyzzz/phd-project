namespace DSIS.UI.Wizard
{
  partial class ButtonsControl
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
      this.ButtonFinish = new System.Windows.Forms.Button();
      this.ButtonNext = new System.Windows.Forms.Button();
      this.ButtonBack = new System.Windows.Forms.Button();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ButtonFinish
      // 
      this.ButtonFinish.Location = new System.Drawing.Point(246, 3);
      this.ButtonFinish.Name = "ButtonFinish";
      this.ButtonFinish.Size = new System.Drawing.Size(75, 23);
      this.ButtonFinish.TabIndex = 5;
      this.ButtonFinish.Text = "Finish";
      this.ButtonFinish.UseVisualStyleBackColor = true;
      // 
      // ButtonNext
      // 
      this.ButtonNext.Location = new System.Drawing.Point(165, 3);
      this.ButtonNext.Name = "ButtonNext";
      this.ButtonNext.Size = new System.Drawing.Size(75, 23);
      this.ButtonNext.TabIndex = 4;
      this.ButtonNext.Text = "Next";
      this.ButtonNext.UseVisualStyleBackColor = true;
      // 
      // ButtonBack
      // 
      this.ButtonBack.Location = new System.Drawing.Point(84, 3);
      this.ButtonBack.Name = "ButtonBack";
      this.ButtonBack.Size = new System.Drawing.Size(75, 23);
      this.ButtonBack.TabIndex = 3;
      this.ButtonBack.Text = "Back";
      this.ButtonBack.UseVisualStyleBackColor = true;
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.Location = new System.Drawing.Point(3, 3);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.ButtonCancel.TabIndex = 6;
      this.ButtonCancel.Text = "Cancel";
      this.ButtonCancel.UseVisualStyleBackColor = true;
      // 
      // ButtonsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Controls.Add(this.ButtonCancel);
      this.Controls.Add(this.ButtonFinish);
      this.Controls.Add(this.ButtonNext);
      this.Controls.Add(this.ButtonBack);
      this.Name = "ButtonsControl";
      this.Size = new System.Drawing.Size(324, 29);
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.Button ButtonFinish;
    public System.Windows.Forms.Button ButtonNext;
    public System.Windows.Forms.Button ButtonBack;
    public System.Windows.Forms.Button ButtonCancel;

  }
}