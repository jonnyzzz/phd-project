using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace gui.Panels
{
	/// <summary>
	/// Summary description for NotedTextField.
	/// </summary>
	public class NotedTextField : UserControl
	{
		public TextBox textBox;
		public Label labelCaption;
		private Panel panelSpace;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public NotedTextField()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.SizeChanged += new EventHandler(NotedTextField_SizeChanged);

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox = new System.Windows.Forms.TextBox();
			this.labelCaption = new System.Windows.Forms.Label();
			this.panelSpace = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox.Location = new System.Drawing.Point(0, 16);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(424, 20);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "textBox";
			// 
			// labelCaption
			// 
			this.labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelCaption.Location = new System.Drawing.Point(0, 0);
			this.labelCaption.Name = "labelCaption";
			this.labelCaption.Size = new System.Drawing.Size(424, 16);
			this.labelCaption.TabIndex = 1;
			this.labelCaption.Text = "labelCaption";
			this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelSpace
			// 
			this.panelSpace.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSpace.Location = new System.Drawing.Point(0, 36);
			this.panelSpace.Name = "panelSpace";
			this.panelSpace.Size = new System.Drawing.Size(424, 12);
			this.panelSpace.TabIndex = 2;
			// 
			// NotedTextField
			// 
			this.Controls.Add(this.panelSpace);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.labelCaption);
			this.Name = "NotedTextField";
			this.Size = new System.Drawing.Size(424, 136);
			this.ResumeLayout(false);

		}

		#endregion

		private void NotedTextField_SizeChanged(object sender, EventArgs e)
		{
			this.Height = panelSpace.Top + panelSpace.Height;
		}

/*
        public override Font Font
        {
            set 
            {
                labelCaption.Font = value;
                textBox.Font = value;
            }
            get
            {
                this.Font = labelCaption.Font;
                return labelCaption.Font;
            }
        }
*/

		public String Caption
		{
			set { labelCaption.Text = value; }
			get { return labelCaption.Text; }
		}

		public String Value
		{
			set { textBox.Text = value; }
			get { return textBox.Text; }
		}
	}
}