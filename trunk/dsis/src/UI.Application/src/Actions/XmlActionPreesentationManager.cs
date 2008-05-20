using System;
using System.IO;
using System.Reflection;
using System.Xml;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  public class XmlActionPreesentationManager
  {
    private readonly IActionPresentationManager myManager;

    public XmlActionPreesentationManager(IActionPresentationManager manager)
    {
      myManager = manager;

      //todo: Hack
      LoadAssembly(GetType().Assembly);
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

        foreach (XmlElement element in Util.Safe(doc.SelectNodes("MainMenu/" + ActionDescriptor.ELEMENT_NAME)))
        {
          LoadDeclarationsFromXml(element, myManager.RootAction);
        }
      }
    }

    public void LoadDeclarationsFromXml(XmlElement element, ActionDescriptor parent)
    {
      var desc = ActionDescriptor.FromXml(element, parent);
      if (desc == null)
        return;

      foreach (XmlElement node in Util.Safe(element.SelectNodes(ActionDescriptor.ELEMENT_NAME)))
        LoadDeclarationsFromXml(node, desc);

      myManager.RegisterAction(desc);
    }
  }
}