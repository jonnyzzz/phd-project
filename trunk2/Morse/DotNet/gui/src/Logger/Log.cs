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
	public class Log : System.Windows.Forms.Form
	{
        #region static Loggin functions
      
        public static void LogMessage(object owner, string args, params object[] arg)
        {         
            LogMessage(owner.GetType(), args, arg);
        }
        public static void LogMessage(Type type, string args, params object[] arg)
        {         
            Console.Out.WriteLine("Log: Class {0}, Message :{1}", type.Name, string.Format(args, arg));
        }

        public static void LogException(object owner, Exception exception, string message, params object[] arg)
        {
            LogException(owner.GetType(), exception, message, arg);
        }
        public static void LogException(Type type, Exception exception, string message, params object[] arg)
        {
            Console.Out.WriteLine("Log: Class{2}, Message {0}, Excteption: {1}", exception.ToString(), string.Format(message, arg), type.Name);
        }


        #endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Log()
		{
			InitializeComponent();
		}
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
            this.ClientSize = new System.Drawing.Size(688, 502);
            this.Name = "Logger";
            this.Text = "Logger";

        }
		#endregion
	}
}
