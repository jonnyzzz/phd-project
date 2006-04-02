using System;
using System.Collections;
using EugenePetrenko.Gui2.Application.Runner;

namespace EugenePetrenko.Gui2.Kernell2.Container
{
	/// <summary>
	/// Summary description for CommandLineParser.
	/// </summary>
	public class CommandLineParser
	{
		private Hashtable parameters = new Hashtable();

		public CommandLineParser(string[] commandLine)
		{
			for (int i = 0; i < commandLine.Length; i++)
			{
				string param = commandLine[i];
				if (!param.StartsWith("/")) throw new CommandLineParseException("Unexpected key. All keys should starts from '/'");

				string key = param.Substring(1);

				String[] data = key.Split('=');

				if (data.Length > 2) throw new CommandLineParseException("Unexpected key style. Was :" + commandLine[i] + " but expected /key[=value]");

				if (data.Length == 1)
				{
					parameters[data[0]] = "";
				}
				else
				{
					parameters[data[0]] = data[1];
				}
			}
		}

		public string GetValue(string key)
		{
			return parameters[key] as string;
		}
		
		public string[] GetValues(string key)
		{
			string tmp = GetValue(key);
			return tmp != null ? tmp.Split(',') : null;
		}

		public bool HasKey(string key)
		{
			return parameters.ContainsKey(key);
		}
	}
}

namespace EugenePetrenko.Gui2.Application.Runner
{
	public class CommandLineParseException : Exception
    {
        public CommandLineParseException(string message) : base(message)
        {
        }
    }
}