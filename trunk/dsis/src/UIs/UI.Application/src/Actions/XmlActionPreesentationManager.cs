using System;
using System.IO;
using System.Reflection;
using System.Xml;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions
{
  [ComponentImplementation(Startable = true)]
  public class XmlActionPreesentationManager
  {
    private readonly IActionPresentationManager myManager;
    private readonly ActionDescriptorParserManager myActionParser;
    
    public XmlActionPreesentationManager(ActionDescriptorParserManager actionParser, IActionPresentationManager manager)
    {
      myManager = manager;
      myActionParser = actionParser;
    }

    public void LoadAssembly(Assembly assembly)
    {
      foreach (
        ActionDescriptorXmlAttributre attribute in
          assembly.GetCustomAttributes(typeof (ActionDescriptorXmlAttributre), true))
      {
        LoadXml(assembly, attribute);
      }
    }

    private void LoadXml(Assembly assembly, ActionDescriptorXmlAttributre attr)
    {
      using (Stream stream = assembly.GetManifestResourceStream(attr.Type, attr.Location))
      {
        if (stream == null)
        {
          throw new ArgumentException("Failed to find resource " + attr.Type.Namespace + ";" + attr.Location + " on " +
                                      assembly.GetName().FullName);
        }

        var doc = new XmlDocument();
        doc.Load(stream);

        foreach (XmlElement element in Util.Safe(doc.SelectNodes("MainMenu/*")))
        {
            LoadDeclarationsFromXml(element, myManager.RootAction);
        }
      }
    }

    public void LoadDeclarationsFromXml(XmlElement element, IActionDescriptor parent)
    {
      var desc = myActionParser.Parse(element, parent);
      if (desc == null)
        return;

      foreach (XmlNode node in Util.Safe(element.ChildNodes))
      {
        if (node is XmlElement)
        {
          LoadDeclarationsFromXml((XmlElement) node, desc);
        }
      }

      myManager.RegisterAction(desc);
    }
  }
}