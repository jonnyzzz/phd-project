namespace DSIS.UI.FunctionDialog
{
  partial class SapceControl
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
      System.Windows.Forms.GroupBox myGroupBoxSpaceInformation;
      this.mySpaceInformationPanel = new System.Windows.Forms.Panel();
      this.myDimension = new System.Windows.Forms.NumericUpDown();
      label1 = new System.Windows.Forms.Label();
      myGroupBoxSpaceInformation = new System.Windows.Forms.GroupBox();
      myGroupBoxSpaceInformation.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.myDimension)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(0, 8);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(93, 13);
      label1.TabIndex = 0;
      label1.Text = "System Dimension";
      // 
      // myGroupBoxSpaceInformation
      // 
      myGroupBoxSpaceInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      myGroupBoxSpaceInformation.Controls.Add(this.mySpaceInformationPanel);
      myGroupBoxSpaceInformation.Location = new System.Drawing.Point(3, 32);
      myGroupBoxSpaceInformation.Name = "myGroupBoxSpaceInformation";
      myGroupBoxSpaceInformation.Size = new System.Drawing.Size(475, 242);
      myGroupBoxSpaceInformation.TabIndex = 2;
      myGroupBoxSpaceInformation.TabStop = false;
      myGroupBoxSpaceInformation.Text = "Space Information";
      // 
      // mySpaceInformationPanel
      // 
      this.mySpaceInformationPanel.AutoScroll = true;
      this.mySpaceInformationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mySpaceInformationPanel.Location = new System.Drawing.Point(3, 16);
      this.mySpaceInformationPanel.Name = "mySpaceInformationPanel";
      this.mySpaceInformationPanel.Size = new System.Drawing.Size(469, 223);
      this.mySpaceInformationPanel.TabIndex = 0;
      // 
      // myDimension
      // 
      this.myDimension.Location = new System.Drawing.Point(99, 6);
      this.myDimension.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.myDimension.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.myDimension.Name = "myDimension";
      this.myDimension.Size = new System.Drawing.Size(120, 20);
      this.myDimension.TabIndex = 1;
      this.myDimension.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.myDimension.ValueChanged += new System.EventHandler(this.myDimension_ValueChanged);
      // 
      // SapceControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(myGroupBoxSpaceInformation);
      this.Controls.Add(this.myDimension);
      this.Controls.Add(label1);
      this.Name = "SapceControl";
      this.Size = new System.Drawing.Size(481, 277);
      myGroupBoxSpaceInformation.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.myDimension)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown myDimension;
    private System.Windows.Forms.Panel mySpaceInformationPanel;
  }
}
