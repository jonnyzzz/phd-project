namespace DSIS.UI.Wizard
{
  partial class WizardForm
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Panel myHeaderPanel;
      System.Windows.Forms.Panel myButtonsPanel;
      this.myMiddleContainer = new System.Windows.Forms.Panel();
      this.myButtonsTimer = new System.Windows.Forms.Timer(this.components);
      this.myButtons = new DSIS.UI.Wizard.ButtonsControl();
      this.myHeader = new DSIS.UI.Wizard.HeaderControl();
      myHeaderPanel = new System.Windows.Forms.Panel();
      myButtonsPanel = new System.Windows.Forms.Panel();
      myHeaderPanel.SuspendLayout();
      myButtonsPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // myHeaderPanel
      // 
      myHeaderPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      myHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      myHeaderPanel.Controls.Add(this.myHeader);
      myHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
      myHeaderPanel.Location = new System.Drawing.Point(0, 0);
      myHeaderPanel.Name = "myHeaderPanel";
      myHeaderPanel.Size = new System.Drawing.Size(502, 72);
      myHeaderPanel.TabIndex = 0;
      // 
      // myButtonsPanel
      // 
      myButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      myButtonsPanel.Controls.Add(this.myButtons);
      myButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      myButtonsPanel.Location = new System.Drawing.Point(0, 490);
      myButtonsPanel.Name = "myButtonsPanel";
      myButtonsPanel.Size = new System.Drawing.Size(502, 64);
      myButtonsPanel.TabIndex = 2;
      // 
      // myMiddleContainer
      // 
      this.myMiddleContainer.AutoScroll = true;
      this.myMiddleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.myMiddleContainer.Location = new System.Drawing.Point(0, 72);
      this.myMiddleContainer.Name = "myMiddleContainer";
      this.myMiddleContainer.Padding = new System.Windows.Forms.Padding(5);
      this.myMiddleContainer.Size = new System.Drawing.Size(502, 418);
      this.myMiddleContainer.TabIndex = 1;
      // 
      // myButtonsTimer
      // 
      this.myButtonsTimer.Tick += new System.EventHandler(this.myButtonsTimer_Tick);
      // 
      // myButtons
      // 
      this.myButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.myButtons.AutoSize = true;
      this.myButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.myButtons.BackEnabled = true;
      this.myButtons.CancelEnabled = true;
      this.myButtons.FinishEnabled = true;
      this.myButtons.Location = new System.Drawing.Point(93, 22);
      this.myButtons.Name = "myButtons";
      this.myButtons.NextEnabled = true;
      this.myButtons.Size = new System.Drawing.Size(324, 29);
      this.myButtons.TabIndex = 0;
      // 
      // myHeader
      // 
      this.myHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.myHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.myHeader.Location = new System.Drawing.Point(0, 0);
      this.myHeader.MainTitle = "Header Main Title";
      this.myHeader.Name = "myHeader";
      this.myHeader.SecondaryTitle = "Secondary Title";
      this.myHeader.Size = new System.Drawing.Size(500, 71);
      this.myHeader.TabIndex = 0;
      // 
      // WizardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(502, 554);
      this.Controls.Add(this.myMiddleContainer);
      this.Controls.Add(myButtonsPanel);
      this.Controls.Add(myHeaderPanel);
      this.MinimumSize = new System.Drawing.Size(510, 450);
      this.Name = "WizardForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "WizardForm";
      myHeaderPanel.ResumeLayout(false);
      myButtonsPanel.ResumeLayout(false);
      myButtonsPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private HeaderControl myHeader;
    private ButtonsControl myButtons;
    private System.Windows.Forms.Panel myMiddleContainer;
    private System.Windows.Forms.Timer myButtonsTimer;

  }
}