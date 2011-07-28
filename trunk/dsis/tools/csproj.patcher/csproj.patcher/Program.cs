using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace csproj.patcher
{
  class Program
  {
    private const string NS = "http://schemas.microsoft.com/developer/msbuild/2003";
    static void Main(string[] args)
    {
      var root = args.FirstOrDefault() ?? Environment.CurrentDirectory;
      foreach (var proj in Directory.GetFiles(root, "*.csproj", SearchOption.AllDirectories))
      {
        var doc = new XmlDocument();
        using(var rdr = File.OpenRead(proj))
          doc.Load(rdr);

        var ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("m", NS);

        AddReferences(ns, doc);
        AddFramework(doc, ns);
        CleanupEmptyItemGroup(ns, doc);

        PatchProductVersion(ns, doc);

        doc.Save(proj);
        Console.Out.WriteLine(proj);
      }
    }

    private static void CleanupEmptyItemGroup(XmlNamespaceManager ns, XmlDocument doc)
    {
      foreach (XmlElement el in doc.SelectNodes("m:Project/m:ItemGroup", ns).Cast<XmlElement>().ToList())
      {
        if (el.SelectNodes("*").Cast<XmlElement>().Count() == 0)
        {
          el.ParentNode.RemoveChild(el);
        }
      }
    }

    private static void AddFramework(XmlDocument doc, XmlNamespaceManager ns)
    {
      bool hasFx = false;
      bool hasTarget = false;
      foreach (XmlElement node in doc.SelectNodes("m:Project/m:PropertyGroup/m:TargetFrameworkVersion", ns))
      {
        node.InnerText = "v4.0";
        hasFx = true;
      }

      foreach (XmlElement node in doc.SelectNodes("m:Project/m:PropertyGroup/m:TargetFrameworkProfile", ns))
      {
        node.InnerText = "\r\n";
        hasTarget = true;
      }

      if (!hasTarget)
      {
        var el = doc.CreateElement("TargetFrameworkProfile", NS);
        el.InnerText = "\r\n";
        doc.SelectNodes("m:Project/m:PropertyGroup", ns).Cast<XmlElement>().First().AppendChild(el);
      }

      if (!hasFx)
      {
        var el = doc.CreateElement("TargetFrameworkVersion", NS);
        el.InnerText = "v4.0";
        doc.SelectNodes("m:Project/m:PropertyGroup", ns).Cast<XmlElement>().First().AppendChild(el);
      }
    }

    private static void PatchProductVersion(XmlNamespaceManager ns, XmlDocument doc)
    {
      foreach (XmlElement node in doc.SelectNodes("m:Project/m:PropertyGroup/m:ProductVersion", ns))
      {
        node.InnerText = "8.0.30703";
      }
    }

    private static void AddReferences(XmlNamespaceManager ns, XmlDocument doc)
    {
      XmlElement addParent = null;
      var assemblies = new HashSet<string>
                         {
                           "System",
                           "System.Core",
                           "System.Xml.Linq",
                           "System.Data.DataSetExtensions",
                           "System.Data",
                           "System.Xml"
                         };
      foreach (XmlAttribute attr in doc.SelectNodes("m:Project/m:ItemGroup/m:Reference/@Include", ns))
      {
        if (assemblies.Remove(attr.Value))
        {
          XmlNode p = attr.OwnerElement;
          for (; p != null && !((p is XmlElement) && p.LocalName == "ItemGroup"); p = p.ParentNode) ;
          if (p != null)
            addParent = (XmlElement) p;
        }
      }

      if (addParent == null)
      {
        var ancor = doc.SelectNodes("m:Project/m:Import", ns).Cast<XmlElement>().First();
        var el = doc.CreateElement("ItemGroup", NS);
        addParent = (XmlElement) ancor.ParentNode.InsertBefore(el, ancor);
      }

      foreach (var assembly in assemblies)
      {
        var el = doc.CreateElement("Reference", NS);
        el.SetAttribute("Include", assembly);
        addParent.AppendChild(el);
      }
    }
  }
}
