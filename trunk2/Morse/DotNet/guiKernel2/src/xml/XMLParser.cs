using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using guiKernel2.ActionFactory.ActionInfos;
using guiKernel2.ActionFactory.Constraints;
using guiKernel2.Constraints;
using guiKernel2.Container;

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

			 document = new XmlDocument();
			document.Load(GetXMLMapping());					
		}

		public void ParseAssemblyReferences()
		{
			ParseAssemblyReference(document);
		}

		public void ParseActions()
		{
			ParseActions(document);
		}

		private delegate void Processor(XmlDocument document);

		private void ParseAssemblyReference(XmlDocument document)
		{
			ParseActionAssemblies(document);			
			ProcessDocument(document, new Processor(ParseAssemblyReference));			
		}

		private void ParseActions(XmlDocument document)
		{
			ParseActionDefs(document);				
			ParseActionNames(document);
			ProcessDocument(document, new Processor(ParseActions));
		}
			
		private void ProcessDocument(XmlDocument document, Processor processor)
		{
			XmlDocument[] references = ParseMappingRef(document);
			foreach (XmlDocument referenceDocument in references)
			{
				processor(referenceDocument);
			}			
		}

		private XmlDocument[] ParseMappingRef(XmlDocument document)
		{
			ArrayList xmlDocuments = new ArrayList();
			XmlNodeList list = document.SelectNodes("mappings/assemblies/mappingsRef");
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

		private void ParseActionNames(XmlDocument document)
		{
			XmlNodeList list = document.SelectNodes("mappings/names/action");
			foreach (XmlNode node in list)
			{
				XmlAttributeCollection attributes = node.Attributes;
				Core.Instance.ActionNamingFactory.AddActionNaming(attributes["name"].Value, attributes["caption"].Value);
			}
		}


		private void ParseActionAssemblies(XmlDocument document)
		{
			ArrayList assembliesList = new ArrayList(implAssemblies);
			XmlNodeList list = document.SelectNodes("mappings/assemblies/actionAssembly");
			foreach (XmlNode node in list)
			{
				string assemblyName = node.Attributes["name"].Value;
				Assembly assembly = Assembly.Load(assemblyName);
				assembliesList.Add( assembly );

				Logger.Logger.LogMessage("Loaded assembly: {0}", assembly.GetName());
			}
			this.implAssemblies = (Assembly[])assembliesList.ToArray(typeof(Assembly));


			ArrayList assembliesSource = new ArrayList(actionSourceAssemblies);
			list = document.SelectNodes("mappings/assemblies/actionSource");
			foreach (XmlNode node in list)
			{
				string assemblyName = node.Attributes["assembly"].Value;
				Assembly assembly = Assembly.Load(assemblyName);
				assembliesSource.Add(assembly);

				Logger.Logger.LogMessage("Loaded assemby Source: {0}", assembly.GetName());
			}

			this.actionSourceAssemblies = (Assembly[])assembliesSource.ToArray(typeof(Assembly));
		}

		private IConstraint ParseConstraint(XmlNode aNode)
		{
			XmlNodeList nodes = aNode.SelectNodes("constraint");
			if (nodes.Count == 0) return new EmptyConstraint();

			ArrayList constraints = new ArrayList();

			foreach (XmlNode constraintNode in nodes)
			{
				
				string constraintName;

				XmlAttribute attribute = constraintNode.Attributes["class"];
				if (attribute != null)
				{
					constraintName = attribute.Value;
				} 
				else
				{
					constraintName = "DefaultConstraintFactory";
				}

				Type constraintType = Core.GetType(constraintName);
				ConstructorInfo constructor = constraintType.GetConstructor(new Type[]{});
				IConstraintFactory constraintFactory = (IConstraintFactory)constructor.Invoke(new object[] {});
				constraints.Add(constraintFactory.CreateConstraint(constraintNode));
			}

			return new AndConstraint((IConstraint[])constraints.ToArray(typeof(IConstraint)));
		}


		private void ParseActionDefs(XmlDocument document)
		{
			XmlNodeList list = document.SelectNodes("mappings/actions/action");
	
			foreach (XmlNode node in list)
			{
				XmlAttributeCollection attributes = node.Attributes;

				IConstraint constraint = ParseConstraint(node);
				ActionRef actionInfo = new ActionRef(attributes["name"].Value, constraint, bool.Parse(attributes["isLeaf"].Value));
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
				IConstraint constraint = ParseConstraint(xmlNode);
				ActionRef actionRef = new ActionRef(attributes["name"].Value, constraint, bool.Parse(attributes["isLeaf"].Value));
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


		private Assembly[] implAssemblies = new Assembly[] {};
		private Assembly[] actionSourceAssemblies = new Assembly[] {};
		private XmlDocument document = null;

		public Assembly[] ImplAssemblies
		{
			get { return implAssemblies; }
		}

		public Assembly[] ActionSourceAssemblies
		{
			get { return actionSourceAssemblies; }
		}

		public Assembly[] Assemblies
		{
			get
			{
				ArrayList list = new ArrayList();
				foreach (Assembly assembly in implAssemblies)
				{
					if (!list.Contains(assembly)) list.Add(assembly);
				}
				foreach (Assembly assembly in actionSourceAssemblies)
				{
					if (!list.Contains(assembly)) list.Add(assembly);
				}
				{
					Assembly assembly = Assembly.GetExecutingAssembly();
					if (!list.Contains(assembly)) list.Add(assembly);
				}
				return (Assembly[])list.ToArray(typeof(Assembly));
			}
		}

	}
}
