using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using gui.ProgressBar;

namespace gui
{
	/// <summary>
	/// Summary description for TestForm.
	/// </summary>
	public class TestForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private SmartProgressBar smartProgressBar1;
		private System.ComponentModel.IContainer components;

		public TestForm()
		{
			InitializeComponent();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.smartProgressBar1 = new SmartProgressBar();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// smartProgressBar1
			// 
			this.smartProgressBar1.BackColor = System.Drawing.SystemColors.Control;
			this.smartProgressBar1.Location = new System.Drawing.Point(40, 96);
			this.smartProgressBar1.LowerBound = 0;
			this.smartProgressBar1.Name = "smartProgressBar1";
			this.smartProgressBar1.Size = new System.Drawing.Size(472, 24);
			this.smartProgressBar1.TabIndex = 0;
			this.smartProgressBar1.UpperBound = 1000;
			this.smartProgressBar1.Value = 10;
			// 
			// TestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 278);
			this.Controls.Add(this.smartProgressBar1);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			smartProgressBar1.Value = (smartProgressBar1.Value+1) % smartProgressBar1.UpperBound;
		}
	}
}
