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
      System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
      this.myToolStrip = new System.Windows.Forms.ToolStripContainer();
      this.myStatusBar = new System.Windows.Forms.StatusStrip();
      this.myMainMenu = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.myToolStrip.BottomToolStripPanel.SuspendLayout();
      this.myToolStrip.TopToolStripPanel.SuspendLayout();
      this.myToolStrip.SuspendLayout();
      this.myStatusBar.SuspendLayout();
      this.myMainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // myToolStrip
      // 
      // 
      // myToolStrip.BottomToolStripPanel
      // 
      this.myToolStrip.BottomToolStripPanel.Controls.Add(this.myStatusBar);
      // 
      // myToolStrip.ContentPanel
      // 
      this.myToolStrip.ContentPanel.Size = new System.Drawing.Size(834, 502);
      this.myToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
      this.myToolStrip.Location = new System.Drawing.Point(0, 0);
      this.myToolStrip.Name = "myToolStrip";
      this.myToolStrip.Size = new System.Drawing.Size(834, 548);
      this.myToolStrip.TabIndex = 1;
      this.myToolStrip.Text = "toolStripContainer1";
      // 
      // myToolStrip.TopToolStripPanel
      // 
      this.myToolStrip.TopToolStripPanel.Controls.Add(this.myMainMenu);
      // 
      // myStatusBar
      // 
      this.myStatusBar.Dock = System.Windows.Forms.DockStyle.None;
      this.myStatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.myStatusBar.Location = new System.Drawing.Point(0, 0);
      this.myStatusBar.Name = "myStatusBar";
      this.myStatusBar.Size = new System.Drawing.Size(834, 22);
      this.myStatusBar.TabIndex = 0;
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
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(834, 548);
      this.Controls.Add(this.myToolStrip);
      this.MainMenuStrip = this.myMainMenu;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "DSIS";      
      this.myToolStrip.BottomToolStripPanel.ResumeLayout(false);
      this.myToolStrip.BottomToolStripPanel.PerformLayout();
      this.myToolStrip.TopToolStripPanel.ResumeLayout(false);
      this.myToolStrip.TopToolStripPanel.PerformLayout();
      this.myToolStrip.ResumeLayout(false);
      this.myToolStrip.PerformLayout();
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
    private System.Windows.Forms.ToolStripContainer myToolStrip;
  }
}