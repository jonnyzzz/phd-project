using System;

namespace EugenePetrenko.Gui2.Logging
{
	/// <summary>
	/// Summary description for Logger.
	/// </summary>
	public class Logger
	{
		public static void LogMessage(object o)
		{
			Console.Out.WriteLine("Log: {0}", o);
		}

		public static void LogMessage(string template, params object[] data )
		{
			LogMessage((object)string.Format(template, data));
		}

		public static void LogException(Exception e)
		{
			LogMessage(e.Message + "\n" + e.StackTrace);
			if (e.InnerException != null)
			{
				LogMessage("\n\nInner Exception:");
				LogException(e.InnerException);
			}
		}
	}
}
