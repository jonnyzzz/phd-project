using System;

namespace Logger
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
	}
}
