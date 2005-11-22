using System.Windows.Forms;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2;

namespace EugenePetrenko.Gui2.Test.Form
{
	/// <summary>
	/// Summary description for TestFrom.
	/// </summary>
	public class TestFrom : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestFrom()
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
            // 
            // TestFrom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 390);
            this.Name = "TestFrom";
            this.Text = "TestFrom";

            this.SuspendLayout();
		    GnuPlotParameters pars = new GnuPlotParameters();
            pars.Dock = DockStyle.Fill;
            this.Controls.Add(pars);
            this.ResumeLayout();

        }
		#endregion
	}
}
