using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace guiActions.src.parameters
{
	/// <summary>
	/// Summary description for ParameterControlMessageException.
	/// </summary>
	public class ParameterControlMessageException : ParametersControlException
	{
		private const string MessagesXML = "guiActions.xml.messages.xml";

		private string shortMessage = null;
		private string fullMessage = null;


		public ParameterControlMessageException(string parameterName, string ids) : base()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream stream = assembly.GetManifestResourceStream(MessagesXML);
			XmlDocument document = new XmlDocument();
			document.Load(stream);
			XmlNodeList list = document.SelectNodes(
				string.Format("messages/{0}/message[@name=\"{1}\"]", parameterName, ids )
				);

			if (list.Count > 1) throw new ParametersContorlParserException("Too much same messages found");
			if (list.Count == 0) throw new ParametersContorlParserException("No message found");

			XmlNode messageNode = list.Item(0);
			this.shortMessage = readNode(messageNode, "short");
			this.fullMessage = readNode(messageNode, "full");
		}

		private string readNode(XmlNode node, string tag)
		{
			XmlNodeList list = node.SelectNodes(tag + "/text()");
			if (list.Count > 1) throw new ParametersContorlParserException("Too much <" + tag + "> tags");
			if (list.Count == 0) throw new ParametersContorlParserException("No <" + tag + "> tag");
			XmlNode tagNode = list.Item(0);
			return tagNode.Value;
		}


		public override string Message
		{
			get { return base.Message + " -> " + shortMessage; }
		}

		public override string ErrorDescription
		{
			get { return fullMessage; }
		}

		public override string ErrorDescriptionShort
		{
			get { return shortMessage; }
		}


		private class ParametersContorlParserException : ParametersControlException
		{
			public ParametersContorlParserException(string message) : base(message)
			{
			}
		}		
	}
}
