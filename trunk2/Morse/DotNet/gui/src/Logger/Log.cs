using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace gui.Logger
{
	/// <summary>
	/// Summary description for Logger.
	/// </summary>
	public class Log : Form
	{
		#region static Loggin functions

		public static void LogMessage(object owner, string args, params object[] arg)
		{
			LogMessage(owner.GetType(), args, arg);
		}

		public static void LogMessage(Type type, string args, params object[] arg)
		{
			ShowMessage(type, string.Format(args, arg));
		}

		public static void LogException(object owner, Exception exception, string message, params object[] arg)
		{
			LogException(owner.GetType(), exception, message, arg);
		}

		public static void LogException(Type type, Exception exception, string message, params object[] arg)
		{
			ShowMessage(type, string.Format("{0}\n\t{1}\n\t{2}\n", string.Format(message, arg), exception.Message, exception.StackTrace));
		}

		private static void ShowMessage(Type cls, string message)
		{
			Console.Out.WriteLine("Log: Thread={0}, Class={1}, Message = {2}\n", Thread.CurrentThread.Name, cls.Name, message);
		}

		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public Log()
		{
			InitializeComponent();
		}

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