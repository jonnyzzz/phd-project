using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace gui.Logger
{
	/// <summary>
	/// Summary description for Logger.
	/// </summary>
	public class Logger : System.Windows.Forms.Form
	{
        #region static Loggin functions
      
        public static void Log(String s)
        {
            Console.Out.WriteLine("Logger: {0}", s);            
        }

        public static void Log(string args, params object[] arg)
        {
            Console.Out.WriteLine(args, arg);
        }
        #endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Logger()
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
            // Logger
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(200, 198);
            this.Name = "Logger";
            this.Text = "Logger";

        }
		#endregion
	}
}
