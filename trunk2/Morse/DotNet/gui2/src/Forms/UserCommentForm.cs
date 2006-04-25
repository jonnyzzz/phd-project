using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Application.Forms
{
  /// <summary>
  /// Summary description for UserComment.
  /// </summary>
  public class UserCommentForm : Form
  {
    private TextBox commentText;
    private GroupBox groupBox;
    private Panel panelButtons;
    private Button buttonOK;
    private Button buttonCancel;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    public UserCommentForm(string initialText)
    {
      InitializeComponent();

      commentText.Text = initialText;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (UserCommentForm));
      this.commentText = new System.Windows.Forms.TextBox();
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.panelButtons = new System.Windows.Forms.Panel();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOK = new System.Windows.Forms.Button();
      this.groupBox.SuspendLayout();
      this.panelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // commentText
      // 
      this.commentText.AcceptsReturn = true;
      this.commentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.commentText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.commentText.Location = new System.Drawing.Point(3, 16);
      this.commentText.Multiline = true;
      this.commentText.Name = "commentText";
      this.commentText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.commentText.Size = new System.Drawing.Size(352, 137);
      this.commentText.TabIndex = 0;
      this.commentText.Text = "";
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.commentText);
      this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox.Location = new System.Drawing.Point(5, 5);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(358, 156);
      this.groupBox.TabIndex = 1;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "Comment For Dynamical System";
      // 
      // panelButtons
      // 
      this.panelButtons.Controls.Add(this.buttonCancel);
      this.panelButtons.Controls.Add(this.buttonOK);
      this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelButtons.DockPadding.Bottom = 10;
      this.panelButtons.DockPadding.Left = 10;
      this.panelButtons.DockPadding.Right = 10;
      this.panelButtons.DockPadding.Top = 10;
      this.panelButtons.Location = new System.Drawing.Point(5, 161);
      this.panelButtons.Name = "panelButtons";
      this.panelButtons.Size = new System.Drawing.Size(358, 40);
      this.panelButtons.TabIndex = 2;
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
      this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonCancel.Location = new System.Drawing.Point(236, 10);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(112, 20);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      // 
      // buttonOK
      // 
      this.buttonOK.Dock = System.Windows.Forms.DockStyle.Left;
      this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonOK.Location = new System.Drawing.Point(10, 10);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(112, 20);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // UserComment
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(368, 206);
      this.Controls.Add(this.groupBox);
      this.Controls.Add(this.panelButtons);
      this.DockPadding.All = 5;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "UserComment";
      this.Text = "User Comment Editor";
      this.groupBox.ResumeLayout(false);
      this.panelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    #endregion

    private void buttonOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    public string UserCommentText
    {
      get { return commentText.Text; }
    }
  }
}