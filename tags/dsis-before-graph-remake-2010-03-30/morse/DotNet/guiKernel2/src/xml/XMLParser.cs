using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos;
using EugenePetrenko.Gui2.Kernell2.Constraints;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Kernell2.xml
{
  /// <summary>
  /// Summary description for XMLParser.
  /// </summary>
  internal class XMLParser
  {
    private const string xmlMapping = "EugenePetrenko.Gui2.Kernell2.xml.ActionMapping.xml";

    private static Assembly[] SearchAssemblies
    {
      get { return new Assembly[] {Assembly.GetExecutingAssembly()}; }
    }

    public static void DumpXMLResources()
    {
      foreach (Assembly assembly in SearchAssemblies)
      {
        foreach (string resourceName in assembly.GetManifestResourceNames())
        {
          Logger.LogMessage("Resource Name = {0}", resourceName);
        }
      }
    }


    public XMLParser()
    {
      Logger.LogMessage("Hello from Assembly Parser");

      document = new XmlDocument();
      using (Stream mapping = GetXMLMapping())
        document.Load(mapping);
    }

    public Assembly[] ParseAssemblyReferences()
    {
      assemblies.Clear();
      assemblies.AddRange(SearchAssemblies);
      ParseAssemblyReference(document);
      return Assemblies;
    }

    public void ParseActions()
    {
      ParseActions(document);
    }

    private delegate void Processor(XmlDocument document);

    private void ParseAssemblyReference(XmlDocument document)
    {
      ParseAssemblies(document);
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
        Logger.LogMessage("Ref");

        string assemblyName = node.Attributes["assembly"].Value;
        string resourceName = node.Attributes["resource"].Value;
        Assembly assembly = Assembly.Load(assemblyName);
        XmlDocument refDocument = new XmlDocument();
        using (Stream data = assembly.GetManifestResourceStream(resourceName))
          refDocument.Load(data);
        xmlDocuments.Add(refDocument);
      }

      return (XmlDocument[]) xmlDocuments.ToArray(typeof (XmlDocument));
    }

    private void ParseActionNames(XmlDocument document)
    {
      XmlNodeList list = document.SelectNodes("mappings/names/action");
      foreach (XmlNode node in list)
      {
        XmlAttributeCollection attributes = node.Attributes;
        XmlNode commentNode = node.SelectSingleNode("text()");
        string caption = attributes["caption"].Value;
        Core.Instance.ActionNamingFactory.AddActionNaming(
          attributes["name"].Value,
          caption,
          commentNode != null ? commentNode.Value : null
          );
      }
    }


    private void ParseAssemblies(XmlDocument document)
    {
      XmlNodeList list = document.SelectNodes("mappings/assemblies/assembly");
      foreach (XmlNode node in list)
      {
        string assemblyName = node.Attributes["name"].Value;
        Assembly assembly = Assembly.Load(assemblyName);
        if (!assemblies.Contains(assembly)) assemblies.Add(assembly);

        Logger.LogMessage("Loaded assembly: {0}", assembly.GetName());
      }
    }

    private IConstraint ParseConstraint(XmlNode aNode)
    {
      return new AndConstraint(aNode, new ParseConstraints(ParseConstraints));
    }

    private IConstraint[] ParseConstraints(XmlNode aNode)
    {
      XmlNodeList nodes = aNode.SelectNodes("constraint");
      if (nodes.Count == 0)
        return new IConstraint[] {};

      ArrayList constraints = new ArrayList();
      foreach (XmlNode constraintNode in nodes)
      {
        string constraintName;

        XmlAttribute attribute = constraintNode.Attributes["class"];
        if (attribute != null)
          constraintName = attribute.Value;
        else
          throw new ArgumentException("Name of constraint is not defined");

        Type constraintType = Core.Instance.TypeFinder.GetType(constraintName);
        ConstructorInfo constructor =
          constraintType.GetConstructor(new Type[] {typeof (XmlNode), typeof (ParseConstraints)});
        if (constructor != null)
        {
          IConstraint constraint =
            (IConstraint) constructor.Invoke(new object[] {constraintNode, new ParseConstraints(ParseConstraints)});
          constraints.Add(constraint);
          continue;
        }
        constructor = constraintType.GetConstructor(new Type[] {typeof (XmlNode)});
        if (constructor != null)
        {
          IConstraint constraint = (IConstraint) constructor.Invoke(new object[] {constraintNode});
          constraints.Add(constraint);
          continue;
        }
      }

      return (IConstraint[]) constraints.ToArray(typeof (IConstraint));
    }


    private void ParseActionDefs(XmlDocument document)
    {
      XmlNodeList list = document.SelectNodes("mappings/actions/action");

      foreach (XmlNode node in list)
      {
        ActionRef actionInfo = ParseActionRef(node, null);
        ParseActionRefs(node, actionInfo);
        Logger.LogMessage("Built Tree :\n {0}\nEnd", actionInfo.DumpTree());

        XmlAttributeCollection attributes = node.Attributes;
        if (IsActiveAction(attributes))
        {
          Core.Instance.NextActionFactory.RegisterAction(actionInfo);
        }
        else
        {
          Logger.LogMessage("Internal Action. Skiped");
        }
      }
    }

    private static bool IsActiveAction(XmlAttributeCollection attributes)
    {
      return attributes["internal"] == null || (attributes["internal"].Value == "true" && Core.Instance.IsInternal);
    }

    private ActionRef ParseActionRef(XmlNode node, ActionRef parent)
    {
      XmlAttributeCollection attributes = node.Attributes;
      IConstraint constraint = ParseConstraint(node);
      ActionRef actionRef = new ActionRef(parent, attributes["name"].Value, constraint, ParseIsLeaf(attributes));
      XmlNode captionNode = node.SelectSingleNode("caption");
      if (captionNode != null)
      {
        XmlNode titleNode = captionNode.SelectSingleNode("title/text()");
        XmlNode detailNode = captionNode.SelectSingleNode("detail/text()");
        actionRef.SetActionCaption(
          titleNode != null ? titleNode.Value : null,
          detailNode != null ? detailNode.Value : null);
      }
      return actionRef;
    }

    private void ParseActionRefs(XmlNode node, ActionRef info)
    {
      XmlNodeList list = node.SelectNodes("action");

      foreach (XmlNode xmlNode in list)
      {
        ActionRef actionRef = ParseActionRef(xmlNode, info);
        ParseActionRefs(xmlNode, actionRef);
        if (IsActiveAction(xmlNode.Attributes))
          info.AddActionRef(actionRef);
      }
    }

    private static bool ParseIsLeaf(XmlAttributeCollection attributes)
    {
      XmlAttribute attribute = attributes["isLeaf"];
      return attribute != null ? bool.Parse(attribute.Value) : false;
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


    private ArrayList assemblies = new ArrayList();
    private XmlDocument document = null;

    public Assembly[] Assemblies
    {
      get
      {
        ArrayList list = new ArrayList();
        foreach (Assembly assembly in assemblies)
        {
          if (!list.Contains(assembly)) list.Add(assembly);
        }
        return (Assembly[]) list.ToArray(typeof (Assembly));
      }
    }
  }
}