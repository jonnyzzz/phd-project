using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace guiControls.Progress
{
	/// <summary>
	/// Summary description for SmartProgressBar.
	/// </summary>
	public class SmartProgressBar : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panelBorder;
		private System.Windows.Forms.PictureBox pictureBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SmartProgressBar()
		{
			LowerBound = 0;
			UpperBound = 10;
			Value = 5;

			InitializeComponent();

			this.SizeChanged +=new EventHandler(SmartProgressBar_SizeChanged);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SmartProgressBar));
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.panelBorder = new System.Windows.Forms.Panel();
			this.panelBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(80, 32);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(8, 56);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.Visible = false;
			// 
			// panelBorder
			// 
			this.panelBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelBorder.Controls.Add(this.pictureBox);
			this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBorder.Location = new System.Drawing.Point(0, 0);
			this.panelBorder.Name = "panelBorder";
			this.panelBorder.Size = new System.Drawing.Size(336, 152);
			this.panelBorder.TabIndex = 1;
			this.panelBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBorder_Paint);
			// 
			// SmartProgressBar
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.panelBorder);
			this.Name = "SmartProgressBar";
			this.Size = new System.Drawing.Size(336, 152);
			this.panelBorder.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		protected int lowerBound;
		protected int upperBound;
		protected int value;

		private Image cacheImage = null;

		private Image createCache()
		{
			if (pictureBox == null || pictureBox.Image == null) return null;

			Bitmap bitmap = new Bitmap(Width, Height);
			Graphics graphics = Graphics.FromImage(bitmap);

			int w = 0;

			while (w <= Width)
			{
				graphics.DrawImage(pictureBox.Image, w, 0);
				w += pictureBox.Width;
			}
			return bitmap;
		}

		private void panelBorder_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			int width = (this.Width * value / (upperBound - lowerBound)) % (Width+1);

			Rectangle clip = Rectangle.Intersect(e.ClipRectangle, new Rectangle(0,0, width, Height));
			graphics.SetClip( clip, CombineMode.Intersect);

			if (cacheImage == null)
			{
				cacheImage = createCache();
			}

			graphics.DrawImage(cacheImage, 0, 0);
		}



		#region progress bar fields
		public int LowerBound
		{
			set
			{
				ReCache();				
				lowerBound = value;
			}
			get
			{
				return lowerBound;
			}
		}

		public int UpperBound
		{
			set
			{
				ReCache();
				upperBound = value;
			}
			get
			{
				return upperBound;
			}
		}

		public int Value
		{
			set
			{
				RePaint();
				this.value = value;
			}
			get
			{
				return value;
			}
		}


		private void RePaint()
		{
			this.Refresh();
		}

		private void ReCache()
		{
			cacheImage = createCache();
			RePaint();
		}
		#endregion

		private void SmartProgressBar_SizeChanged(object sender, EventArgs e)
		{
			if (sender != this)
			{
				this.Height = pictureBox.Image.Height;
			}
		}
	}
}
