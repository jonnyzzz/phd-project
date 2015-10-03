namespace DSIS.UI.FunctionDialog.UI
{
  partial class CompilerErrorForm
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
      this.myRetry = new System.Windows.Forms.Button();
      this.myCancel = new System.Windows.Forms.Button();
      this.myText = new System.Windows.Forms.RichTextBox();
      this.lblTitle = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // myRetry
      // 
      this.myRetry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myRetry.Location = new System.Drawing.Point(244, 360);
      this.myRetry.MaximumSize = new System.Drawing.Size(75, 23);
      this.myRetry.MinimumSize = new System.Drawing.Size(75, 23);
      this.myRetry.Name = "myRetry";
      this.myRetry.Size = new System.Drawing.Size(75, 23);
      this.myRetry.TabIndex = 0;
      this.myRetry.Text = "Retry";
      this.myRetry.UseVisualStyleBackColor = true;
      this.myRetry.Click += new System.EventHandler(this.myRetry_Click);
      // 
      // myCancel
      // 
      this.myCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myCancel.Location = new System.Drawing.Point(325, 360);
      this.myCancel.MaximumSize = new System.Drawing.Size(75, 23);
      this.myCancel.MinimumSize = new System.Drawing.Size(75, 23);
      this.myCancel.Name = "myCancel";
      this.myCancel.Size = new System.Drawing.Size(75, 23);
      this.myCancel.TabIndex = 1;
      this.myCancel.Text = "Cancel";
      this.myCancel.UseVisualStyleBackColor = true;
      this.myCancel.Click += new System.EventHandler(this.myCancel_Click);
      // 
      // myText
      // 
      this.myText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.myText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.myText.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.myText.Location = new System.Drawing.Point(12, 25);
      this.myText.Name = "myText";
      this.myText.ReadOnly = true;
      this.myText.Size = new System.Drawing.Size(614, 329);
      this.myText.TabIndex = 2;
      this.myText.Text = "";
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(12, 9);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(93, 13);
      this.lblTitle.TabIndex = 3;
      this.lblTitle.Text = "Compilation errors:";
      // 
      // CompilerErrorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(638, 400);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.myText);
      this.Controls.Add(this.myCancel);
      this.Controls.Add(this.myRetry);
      this.MinimumSize = new System.Drawing.Size(600, 400);
      this.Name = "CompilerErrorForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "CompilerErrorForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button myRetry;
    private System.Windows.Forms.Button myCancel;
    private System.Windows.Forms.RichTextBox myText;
    private System.Windows.Forms.Label lblTitle;
  }
}