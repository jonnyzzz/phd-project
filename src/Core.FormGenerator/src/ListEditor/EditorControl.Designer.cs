namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  partial class EditorControl
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
      this.myAdd = new System.Windows.Forms.Button();
      this.myRemove = new System.Windows.Forms.Button();
      this.myEdit = new System.Windows.Forms.Button();
      this.myContent = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // myAdd
      // 
      this.myAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.myAdd.Location = new System.Drawing.Point(3, 170);
      this.myAdd.Name = "myAdd";
      this.myAdd.Size = new System.Drawing.Size(75, 23);
      this.myAdd.TabIndex = 0;
      this.myAdd.Text = "Добавить";
      this.myAdd.UseVisualStyleBackColor = true;
      // 
      // myRemove
      // 
      this.myRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.myRemove.Location = new System.Drawing.Point(191, 170);
      this.myRemove.Name = "myRemove";
      this.myRemove.Size = new System.Drawing.Size(75, 23);
      this.myRemove.TabIndex = 1;
      this.myRemove.Text = "Удалить";
      this.myRemove.UseVisualStyleBackColor = true;
      // 
      // myEdit
      // 
      this.myEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.myEdit.Location = new System.Drawing.Point(84, 170);
      this.myEdit.Name = "myEdit";
      this.myEdit.Size = new System.Drawing.Size(101, 23);
      this.myEdit.TabIndex = 2;
      this.myEdit.Text = "Редактировать";
      this.myEdit.UseVisualStyleBackColor = true;
      // 
      // myContent
      // 
      this.myContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                     | System.Windows.Forms.AnchorStyles.Left)
                                                                    | System.Windows.Forms.AnchorStyles.Right)));
      this.myContent.Location = new System.Drawing.Point(3, 3);
      this.myContent.Name = "myContent";
      this.myContent.Size = new System.Drawing.Size(266, 161);
      this.myContent.TabIndex = 3;
      // 
      // EditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.myContent);
      this.Controls.Add(this.myEdit);
      this.Controls.Add(this.myRemove);
      this.Controls.Add(this.myAdd);
      this.Name = "EditorControl";
      this.Size = new System.Drawing.Size(269, 196);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button myAdd;
    private System.Windows.Forms.Button myRemove;
    private System.Windows.Forms.Button myEdit;
    private System.Windows.Forms.Panel myContent;
  }
}