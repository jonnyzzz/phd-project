using System.ComponentModel;
using System.Windows.Forms;
using AxGLVisualization;

namespace gui
{
	/// <summary>
	/// Summary description for GL3DDebug.
	/// </summary>
	public class GL3DDebug : Form
	{
		private AxCGL3D axCGL3D1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public GL3DDebug()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (GL3DDebug));
			this.axCGL3D1 = new AxGLVisualization.AxCGL3D();
			((System.ComponentModel.ISupportInitialize) (this.axCGL3D1)).BeginInit();
			this.SuspendLayout();
			// 
			// axCGL3D1
			// 
			this.axCGL3D1.Enabled = true;
			this.axCGL3D1.Location = new System.Drawing.Point(48, 32);
			this.axCGL3D1.Name = "axCGL3D1";
			this.axCGL3D1.OcxState = ((System.Windows.Forms.AxHost.State) (resources.GetObject("axCGL3D1.OcxState")));
			this.axCGL3D1.Size = new System.Drawing.Size(368, 280);
			this.axCGL3D1.TabIndex = 0;
			// 
			// GL3DDebug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 350);
			this.Controls.Add(this.axCGL3D1);
			this.Name = "GL3DDebug";
			this.Text = "GL3DDebug";
			((System.ComponentModel.ISupportInitialize) (this.axCGL3D1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
	}
}