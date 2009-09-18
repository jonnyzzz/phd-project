using EugenePetrenko.Core.FormGenerator.ErrorProvider;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  partial class DialogForm
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
      this.myContent = new System.Windows.Forms.Panel();
      this.myOk = new System.Windows.Forms.Button();
      this.myCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // myContent
      // 
      this.myContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myContent.Location = new System.Drawing.Point(12, 12);
      this.myContent.Name = "myContent";
      this.myContent.Size = new System.Drawing.Size(368, 243);
      this.myContent.TabIndex = 0;
      // 
      // myOk
      // 
      this.myOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.myOk.Location = new System.Drawing.Point(66, 261);
      this.myOk.Name = "myOk";
      this.myOk.Size = new System.Drawing.Size(75, 23);
      this.myOk.TabIndex = 1;
      this.myOk.Text = "Ok";
      this.myOk.UseVisualStyleBackColor = true;
      this.myOk.Click += new System.EventHandler(this.myOk_Click);
      // 
      // myCancel
      // 
      this.myCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.myCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.myCancel.Location = new System.Drawing.Point(235, 261);
      this.myCancel.Name = "myCancel";
      this.myCancel.Size = new System.Drawing.Size(75, 23);
      this.myCancel.TabIndex = 2;
      this.myCancel.Text = "Отмена";
      this.myCancel.UseVisualStyleBackColor = true;
      this.myCancel.Click += new System.EventHandler(this.myCancel_Click);
      // 
      // DialogForm
      // 
      this.AcceptButton = this.myOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.myCancel;
      this.ClientSize = new System.Drawing.Size(392, 296);
      this.Controls.Add(this.myCancel);
      this.Controls.Add(this.myOk);
      this.Controls.Add(this.myContent);
      this.MinimumSize = new System.Drawing.Size(400, 300);
      this.Name = "DialogForm";
      this.Text = "DialogForm";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel myContent;
    private System.Windows.Forms.Button myOk;
    private System.Windows.Forms.Button myCancel;    
  }
}