using System;

namespace gui.Tree
{
	/// <summary>
	/// Summary description for XmlParseException.
	/// </summary>
	public class XmlParseException : Exception
	{
		protected XmlParseException(string problem) : base(problem)
		{
		}

		public static XmlParseException UnexpectedEnd()
		{
			return new XmlParseException("Unexpected end of xml to parse");
		}

		public static XmlParseException NodeExpected(string name)
		{
			return new XmlParseException("Node <" + name + "> expected");
		}
	}
}