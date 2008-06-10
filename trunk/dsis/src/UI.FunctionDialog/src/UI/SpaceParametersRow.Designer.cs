namespace DSIS.UI.FunctionDialog.UI
{
  partial class SpaceParametersRow
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
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.myLeft = new System.Windows.Forms.TextBox();
      this.myRight = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.myGrid = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.myErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                 | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(25, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Left";
      // 
      // myLeft
      // 
      this.myLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                 | System.Windows.Forms.AnchorStyles.Left)));
      this.myLeft.Location = new System.Drawing.Point(34, 6);
      this.myLeft.Name = "myLeft";
      this.myLeft.Size = new System.Drawing.Size(100, 20);
      this.myLeft.TabIndex = 1;
      this.myLeft.TextChanged += new System.EventHandler(this.myLeft_TextChanged);
      // 
      // myRight
      // 
      this.myRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                  | System.Windows.Forms.AnchorStyles.Left)));
      this.myRight.Location = new System.Drawing.Point(191, 6);
      this.myRight.Name = "myRight";
      this.myRight.Size = new System.Drawing.Size(100, 20);
      this.myRight.TabIndex = 3;
      this.myRight.TextChanged += new System.EventHandler(this.myRight_TextChanged);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                 | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(153, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Right";
      // 
      // myGrid
      // 
      this.myGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                 | System.Windows.Forms.AnchorStyles.Left)));
      this.myGrid.Location = new System.Drawing.Point(355, 6);
      this.myGrid.Name = "myGrid";
      this.myGrid.Size = new System.Drawing.Size(100, 20);
      this.myGrid.TabIndex = 5;
      this.myGrid.TextChanged += new System.EventHandler(this.myGrid_TextChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                 | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(305, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(44, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Division";
      // 
      // myErrorProvider
      // 
      this.myErrorProvider.ContainerControl = this;
      // 
      // SpaceParametersRow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.myGrid);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.myRight);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.myLeft);
      this.Controls.Add(this.label1);
      this.Name = "SpaceParametersRow";
      this.Size = new System.Drawing.Size(462, 35);
      ((System.ComponentModel.ISupportInitialize)(this.myErrorProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox myLeft;
    private System.Windows.Forms.TextBox myRight;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox myGrid;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ErrorProvider myErrorProvider;
  }
}