using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace gui
{
	/// <summary>
	/// Summary description for CommandLineParser.
	/// </summary>
	public class CommandLineParsers
	{
		private Hashtable parameters = new Hashtable();

		public CommandLineParsers(string[] commandLine)
		{
			for (int i=0; i<commandLine.Length; i++)
			{
				string param = commandLine[i];
				if (!param.StartsWith("/")) throw new CommandLineParseException("Unexpected key. All keys should starts from '/'");

				string key = param.Substring(1);
				
				String[] data = key.Split('=');

				if (data.Length > 2)  throw new CommandLineParseException("Unexpected key style. Was :" + commandLine[i] + " but expected /key[=value]");

				if (data.Length == 1)
				{
					parameters[data[0]] = "";
				} else
				{
					parameters[data[0]] = data[1];
				}
			}
		}

		public string getValue(string key)
		{
			return parameters[key] as string;
		}

		public bool hasKey(string key)
		{
			return parameters.ContainsKey(key);
		}
	}

	public class CommandLineParseException : Exception
	{
		public CommandLineParseException(string message) : base(message)
		{
		}
	}
}
