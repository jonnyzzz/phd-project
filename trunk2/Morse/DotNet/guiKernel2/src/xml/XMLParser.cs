using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.src.ActionFactory.ActionInfos;
using guiKernel2.src.Container;

namespace guiKernel2.xml
{
	/// <summary>
	/// Summary description for XMLParser.
	/// </summary>
	public class XMLParser
	{
		private const string xmlMapping = "guiKernel2.xml.ActionMapping.xml";

		private static Assembly[] SearchAssemblies
		{
			get
			{
				return new Assembly[] { Assembly.GetExecutingAssembly()};
			}
		}

		public static void DumpXMLResources()
		{
			foreach (Assembly assembly in SearchAssemblies)
			{
				foreach( string resourceName in assembly.GetManifestResourceNames() ) 
				{
					Logger.Logger.LogMessage("Resource Name = {0}", resourceName);
				}	
			}
		}


		public XMLParser()
		{
			Logger.Logger.LogMessage("Hello from Assembly Parser");

			XmlDocument document = new XmlDocument();
			document.Load(GetXMLMapping());

			ProcessDocument(document);
		}

		private void ProcessDocument(XmlDocument document)
		{
			ParseActionDefs(document);	
			ParseActionAssemblies(document);
			XmlDocument[] references = ParseMappingRef(document);
			foreach (XmlDocument referenceDocument in references)
			{
				ProcessDocument(referenceDocument);
			}			
		}

		private XmlDocument[] ParseMappingRef(XmlDocument document)
		{
			ArrayList xmlDocuments = new ArrayList();
			XmlNodeList list = document.SelectNodes("mappings/assembies/mappingsRef");
			foreach (XmlNode node in list)
			{
				Console.Out.WriteLine("Ref");

				string assemblyName = node.Attributes["assembly"].Value;
				string resourceName = node.Attributes["resource"].Value;
				Assembly assembly = Assembly.Load(assemblyName);
				Stream data = assembly.GetManifestResourceStream(resourceName);
				XmlDocument refDocument = new XmlDocument();
				refDocument.Load(data);
				xmlDocuments.Add(refDocument);
			}

			return (XmlDocument[])xmlDocuments.ToArray(typeof(XmlDocument));
		}

		private void ParseActionAssemblies(XmlDocument document)
		{
			ArrayList assembliesList = new ArrayList(implAssemblies);
			XmlNodeList list = document.SelectNodes("mappings/assembies/actionAssembly");
			foreach (XmlNode node in list)
			{
				string assemblyName = node.Attributes["name"].Value;
				Assembly assembly = Assembly.Load(assemblyName);
				assembliesList.Add( assembly);

				Logger.Logger.LogMessage("Loaded assembly: {0}", assembly.GetName());
			}
			this.implAssemblies = (Assembly[])assembliesList.ToArray(typeof(Assembly));
		}

		private void ParseActionDefs(XmlDocument document)
		{
			XmlNodeList list = document.SelectNodes("mappings/action");
	
			foreach (XmlNode node in list)
			{
				XmlAttributeCollection attributes = node.Attributes;			
				
				ActionInfo actionInfo = new ActionInfo(attributes["name"].Value, attributes["resultType"].Value, attributes["metadata"].Value, bool.Parse(attributes["isLeaf"].Value));
				XmlNodeList refNodeList = node.SelectNodes("nextActions");

				if (refNodeList.Count > 1) throw new XMLParserException("Too much NextAction Tags");
				foreach (XmlNode refNode in refNodeList)
				{
					ParseActionRefs(refNode, actionInfo);	
				}
				
				Logger.Logger.LogMessage("Built Tree :\n {0}\nEnd", actionInfo.DumpTree());

				Core.Instance.NextActionFactory.RegisterAction(actionInfo);
			}
		}

		private void ParseActionRefs(XmlNode node, ActionRef info)
		{
			XmlNodeList list = node.SelectNodes("actionReference");

			foreach (XmlNode xmlNode in list)
			{
				XmlAttributeCollection attributes = xmlNode.Attributes;
				ActionRef actionRef = new ActionRef(attributes["name"].Value, bool.Parse(attributes["isLeaf"].Value));
				ParseActionRefs(xmlNode, actionRef);
				info.AddActionRef(actionRef);
			}
		}


		private Stream GetXMLMapping()
		{
			foreach (Assembly assembly in SearchAssemblies)
			{
				foreach (string resourceName in assembly.GetManifestResourceNames())
				{
					if (resourceName.Equals(xmlMapping))
					{
						return assembly.GetManifestResourceStream(resourceName);
					}
				}
			}

			throw new XMLParserException("Unable to load resource file");
		}


		private Assembly[] implAssemblies = new Assembly[0];

		public Assembly[] ImplAssemblies
		{
			get { return implAssemblies; }
		}

	}
}
