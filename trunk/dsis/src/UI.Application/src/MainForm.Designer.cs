namespace DSIS.UI.Application
{
  partial class MainForm
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
      System.Windows.Forms.ToolStripContainer myToolStrip;
      System.Windows.Forms.ToolStripStatusLabel myStatusBarLabel;
      System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
      this.myStatusBar = new System.Windows.Forms.StatusStrip();
      this.myMainMenu = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      myToolStrip = new System.Windows.Forms.ToolStripContainer();
      myStatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
      newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      myToolStrip.BottomToolStripPanel.SuspendLayout();
      myToolStrip.TopToolStripPanel.SuspendLayout();
      myToolStrip.SuspendLayout();
      this.myStatusBar.SuspendLayout();
      this.myMainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // myToolStrip
      // 
      // 
      // myToolStrip.BottomToolStripPanel
      // 
      myToolStrip.BottomToolStripPanel.Controls.Add(this.myStatusBar);
      // 
      // myToolStrip.ContentPanel
      // 
      myToolStrip.ContentPanel.Size = new System.Drawing.Size(834, 502);
      myToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
      myToolStrip.Location = new System.Drawing.Point(0, 0);
      myToolStrip.Name = "myToolStrip";
      myToolStrip.Size = new System.Drawing.Size(834, 548);
      myToolStrip.TabIndex = 1;
      myToolStrip.Text = "toolStripContainer1";
      // 
      // myToolStrip.TopToolStripPanel
      // 
      myToolStrip.TopToolStripPanel.Controls.Add(this.myMainMenu);
      // 
      // myStatusBar
      // 
      this.myStatusBar.Dock = System.Windows.Forms.DockStyle.None;
      this.myStatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.myStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            myStatusBarLabel});
      this.myStatusBar.Location = new System.Drawing.Point(0, 0);
      this.myStatusBar.Name = "myStatusBar";
      this.myStatusBar.Size = new System.Drawing.Size(834, 22);
      this.myStatusBar.TabIndex = 0;
      // 
      // myStatusBarLabel
      // 
      myStatusBarLabel.Name = "myStatusBarLabel";
      myStatusBarLabel.Size = new System.Drawing.Size(109, 17);
      myStatusBarLabel.Text = "toolStripStatusLabel1";
      // 
      // myMainMenu
      // 
      this.myMainMenu.Dock = System.Windows.Forms.DockStyle.None;
      this.myMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.myMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.myMainMenu.Location = new System.Drawing.Point(0, 0);
      this.myMainMenu.Name = "myMainMenu";
      this.myMainMenu.Size = new System.Drawing.Size(834, 24);
      this.myMainMenu.TabIndex = 0;
      this.myMainMenu.Text = "MainMenu";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newToolStripMenuItem
      // 
      newToolStripMenuItem.Name = "newToolStripMenuItem";
      newToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
      newToolStripMenuItem.Text = "New";
      newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(834, 548);
      this.Controls.Add(myToolStrip);
      this.MainMenuStrip = this.myMainMenu;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DSIS";
      myToolStrip.BottomToolStripPanel.ResumeLayout(false);
      myToolStrip.BottomToolStripPanel.PerformLayout();
      myToolStrip.TopToolStripPanel.ResumeLayout(false);
      myToolStrip.TopToolStripPanel.PerformLayout();
      myToolStrip.ResumeLayout(false);
      myToolStrip.PerformLayout();
      this.myStatusBar.ResumeLayout(false);
      this.myStatusBar.PerformLayout();
      this.myMainMenu.ResumeLayout(false);
      this.myMainMenu.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.MenuStrip myMainMenu;
    private System.Windows.Forms.StatusStrip myStatusBar;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
  }
}