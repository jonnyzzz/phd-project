using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace gui2.Forms
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : Form
	{
		private Label label1;
		private IContainer components;
		private Panel panel1;
		private Timer timerOpacity;

		public string data;

		public About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			String offet = new string(' ', 15);

			data =
				offet + "Created by: \n " +
					offet + "   Euegene Petrenko (evgeni.petrenko@mail.ru),\n " +
					offet + "   George Osipenko,\n " +
					offet + "   Nataly Ampilova,\n " +
					offet + "   \n\n\n " + /*Kate Motkina*/
					offet + "Special thanks to: \n " +
					offet + "   Joseph V. Romanovsky,\n" +
					offet + "   And to every one, who was involved \n" +
					offet + "	  In the development process \n\n\n" +
					offet + "                       2001-2005 ";
			label1.Text = data;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.timerOpacity = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Info;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(634, 326);
			this.label1.TabIndex = 0;
			this.label1.Text = "Produced by";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(634, 326);
			this.panel1.TabIndex = 1;
			// 
			// timerOpacity
			// 
			this.timerOpacity.Enabled = true;
			this.timerOpacity.Interval = 60;
			this.timerOpacity.Tick += new System.EventHandler(this.timerOpacity_Tick);
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(634, 326);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "About";
			this.Opacity = 0.45;
			this.Text = "About";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private int opacity = 40;
		private int direction = 1;
		private const int opacityDevider = 100;
		private const int opacityMin = 40;
		private const int opacityMax = 95;


		private void timerOpacity_Tick(object sender, EventArgs e)
		{
			opacity += direction;
			if (opacity > opacityMax || opacity < opacityMin)
			{
				direction = -direction;
			}
			this.Opacity = Math.Sqrt((double) opacity/(opacityDevider));
		}
	}
}