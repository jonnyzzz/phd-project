using System;
using System.Reflection;
using System.Xml;
using guiExternalResource.Core;

namespace guiExternalResource.src.xml
{
	/// <summary>
	/// Summary description for XMLParser.
	/// </summary>
	internal class XMLParser
	{
		private readonly string Resource = "guiExternalResource.xml.Resource.xml";
		private XmlDocument document = null;

		public XMLParser()
		{
			document = OpenDocument();
			ParseFiles(document);
			ParseString(document);
		}

		private void ParseFiles(XmlDocument document)
		{
			XmlNodeList list = document.SelectNodes("resources/files/file");
			foreach (XmlNode node in list)
			{
				XmlAttributeCollection attributes = node.Attributes;
				ResourceManager.Instance.FileResources.RegisterFile(attributes["file"].Value, attributes["path"].Value);
			}
		}

		private void ParseString(XmlDocument document)
		{
			foreach (XmlNode node in document.SelectNodes("resources/strings/string"))
			{
				XmlAttributeCollection attributes = node.Attributes;
				ResourceManager.Instance.StringResources.AddString(attributes["key"].Value, node.SelectSingleNode("text()").Value);
			}
		}

		public XmlNode XmlResource(string name)
		{
			return document.SelectSingleNode("resources/xmls/" + name);
		}
		
		private XmlDocument OpenDocument()
		{
			XmlDocument document = new XmlDocument();
			document.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(Resource));
			return document;
		}
	}
}
