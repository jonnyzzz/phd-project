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
      System.Windows.Forms.Panel myHeaderPanel;
      System.Windows.Forms.Panel myMiddleContainer;
      System.Windows.Forms.Panel myButtonsPanel;
      this.myButtonBack = new System.Windows.Forms.Button();
      this.myButtonNext = new System.Windows.Forms.Button();
      myHeaderPanel = new System.Windows.Forms.Panel();
      myMiddleContainer = new System.Windows.Forms.Panel();
      myButtonsPanel = new System.Windows.Forms.Panel();
      myButtonsPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // myHeaderPanel
      // 
      myHeaderPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      myHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      myHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
      myHeaderPanel.Location = new System.Drawing.Point(0, 0);
      myHeaderPanel.Name = "myHeaderPanel";
      myHeaderPanel.Size = new System.Drawing.Size(499, 72);
      myHeaderPanel.TabIndex = 0;
      // 
      // myMiddleContainer
      // 
      myMiddleContainer.AutoScroll = true;
      myMiddleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      myMiddleContainer.Location = new System.Drawing.Point(0, 72);
      myMiddleContainer.Name = "myMiddleContainer";
      myMiddleContainer.Size = new System.Drawing.Size(499, 482);
      myMiddleContainer.TabIndex = 1;
      // 
      // myButtonsPanel
      // 
      myButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      myButtonsPanel.Controls.Add(this.myButtonNext);
      myButtonsPanel.Controls.Add(this.myButtonBack);
      myButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      myButtonsPanel.Location = new System.Drawing.Point(0, 490);
      myButtonsPanel.Name = "myButtonsPanel";
      myButtonsPanel.Size = new System.Drawing.Size(499, 64);
      myButtonsPanel.TabIndex = 2;
      // 
      // myButtonBack
      // 
      this.myButtonBack.Location = new System.Drawing.Point(163, 28);
      this.myButtonBack.Name = "myButtonBack";
      this.myButtonBack.Size = new System.Drawing.Size(75, 23);
      this.myButtonBack.TabIndex = 0;
      this.myButtonBack.Text = "Back";
      this.myButtonBack.UseVisualStyleBackColor = true;
      // 
      // myButtonNext
      // 
      this.myButtonNext.Location = new System.Drawing.Point(265, 28);
      this.myButtonNext.Name = "myButtonNext";
      this.myButtonNext.Size = new System.Drawing.Size(75, 23);
      this.myButtonNext.TabIndex = 1;
      this.myButtonNext.Text = "Next";
      this.myButtonNext.UseVisualStyleBackColor = true;
      // 
      // WizardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.AutoScrollMinSize = new System.Drawing.Size(380, 450);
      this.ClientSize = new System.Drawing.Size(499, 554);
      this.Controls.Add(myButtonsPanel);
      this.Controls.Add(myMiddleContainer);
      this.Controls.Add(myHeaderPanel);
      this.Name = "WizardForm";
      this.Text = "WizardForm";
      myButtonsPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button myButtonBack;
    private System.Windows.Forms.Button myButtonNext;

  }
}