using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui.Panels
{
	/// <summary>
	/// Summary description for MorseNodeInfo.
	/// </summary>
	public class MorseNodeInfo : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBoxLower;
		private System.Windows.Forms.GroupBox groupBoxUpper;
		private gui.Panels.NotedTextField MinLength;
		private gui.Panels.NotedTextField MinValue;
		private gui.Panels.NotedTextField MaxValue;
		private gui.Panels.NotedTextField MaxLength;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Panel panel1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MorseNodeInfo(IMorseSpectrum morse)
		{		
			InitializeComponent();

			this.MinLength.Value = morse.lowerLength.ToString();
			this.MinValue.Value = morse.lowerBound.ToString();

			this.MaxLength.Value = morse.upperLength.ToString();
			this.MaxValue.Value = morse.upperBound.ToString();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxLower = new System.Windows.Forms.GroupBox();
			this.MinValue = new gui.Panels.NotedTextField();
			this.MinLength = new gui.Panels.NotedTextField();
			this.groupBoxUpper = new System.Windows.Forms.GroupBox();
			this.MaxValue = new gui.Panels.NotedTextField();
			this.MaxLength = new gui.Panels.NotedTextField();
			this.panel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBoxLower.SuspendLayout();
			this.groupBoxUpper.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxLower
			// 
			this.groupBoxLower.Controls.Add(this.MinValue);
			this.groupBoxLower.Controls.Add(this.MinLength);
			this.groupBoxLower.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxLower.Location = new System.Drawing.Point(20, 20);
			this.groupBoxLower.Name = "groupBoxLower";
			this.groupBoxLower.Size = new System.Drawing.Size(348, 116);
			this.groupBoxLower.TabIndex = 0;
			this.groupBoxLower.TabStop = false;
			this.groupBoxLower.Text = "Minimum";
			// 
			// MinValue
			// 
			this.MinValue.Caption = "Value";
			this.MinValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.MinValue.Location = new System.Drawing.Point(3, 64);
			this.MinValue.Name = "MinValue";
			this.MinValue.Size = new System.Drawing.Size(342, 48);
			this.MinValue.TabIndex = 1;
			this.MinValue.Value = "textBox";
			// 
			// MinLength
			// 
			this.MinLength.Caption = "Length";
			this.MinLength.Dock = System.Windows.Forms.DockStyle.Top;
			this.MinLength.Location = new System.Drawing.Point(3, 16);
			this.MinLength.Name = "MinLength";
			this.MinLength.Size = new System.Drawing.Size(342, 48);
			this.MinLength.TabIndex = 0;
			this.MinLength.Value = "textBox";
			// 
			// groupBoxUpper
			// 
			this.groupBoxUpper.Controls.Add(this.MaxValue);
			this.groupBoxUpper.Controls.Add(this.MaxLength);
			this.groupBoxUpper.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxUpper.Location = new System.Drawing.Point(20, 152);
			this.groupBoxUpper.Name = "groupBoxUpper";
			this.groupBoxUpper.Size = new System.Drawing.Size(348, 120);
			this.groupBoxUpper.TabIndex = 1;
			this.groupBoxUpper.TabStop = false;
			this.groupBoxUpper.Text = "Maxinmum";
			// 
			// MaxValue
			// 
			this.MaxValue.Caption = "Value";
			this.MaxValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.MaxValue.Location = new System.Drawing.Point(3, 64);
			this.MaxValue.Name = "MaxValue";
			this.MaxValue.Size = new System.Drawing.Size(342, 48);
			this.MaxValue.TabIndex = 3;
			this.MaxValue.Value = "textBox";
			// 
			// MaxLength
			// 
			this.MaxLength.Caption = "Length";
			this.MaxLength.Dock = System.Windows.Forms.DockStyle.Top;
			this.MaxLength.Location = new System.Drawing.Point(3, 16);
			this.MaxLength.Name = "MaxLength";
			this.MaxLength.Size = new System.Drawing.Size(342, 48);
			this.MaxLength.TabIndex = 2;
			this.MaxLength.Value = "textBox";
			// 
			// panel
			// 
			this.panel.Controls.Add(this.groupBoxUpper);
			this.panel.Controls.Add(this.panel1);
			this.panel.Controls.Add(this.groupBoxLower);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.DockPadding.Bottom = 10;
			this.panel.DockPadding.Left = 20;
			this.panel.DockPadding.Right = 40;
			this.panel.DockPadding.Top = 20;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(408, 536);
			this.panel.TabIndex = 3;
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(20, 136);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(348, 16);
			this.panel1.TabIndex = 2;
			// 
			// MorseNodeInfo
			// 
			this.Controls.Add(this.panel);
			this.Name = "MorseNodeInfo";
			this.Size = new System.Drawing.Size(408, 536);
			this.groupBoxLower.ResumeLayout(false);
			this.groupBoxUpper.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
