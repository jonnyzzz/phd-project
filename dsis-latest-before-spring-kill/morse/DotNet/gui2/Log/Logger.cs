using System;

namespace gui2.Log
{
	/// <summary>
	/// Summary description for Logger.
	/// </summary>
	public class Logger
	{
		public static void LogMessage(string text, params object[] data)
		{
			Console.Out.WriteLine("Log: {0}", string.Format(text, data));
		}
	}
}
