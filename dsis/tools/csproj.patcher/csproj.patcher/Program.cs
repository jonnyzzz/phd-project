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
      var map = new Dictionary<string, string>();

      var root = args.FirstOrDefault() ?? Environment.CurrentDirectory;

      foreach (var proj in Directory.GetFiles(root, "*.csproj", SearchOption.AllDirectories))
      {
        if (Util.MakeRelative(proj, root).StartsWith("tools/")) continue;

        var doc = new XmlDocument();
        using (var rdr = File.OpenRead(proj))
          doc.Load(rdr);

        var ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("m", NS);

        var guid = doc.SelectSingleNode("m:Project/m:PropertyGroup/m:ProjectGuid/text()", ns).InnerText.ToLower().Trim();
        if (map.ContainsKey(guid))
        {
          Console.Out.WriteLine("Same guid for: {0} and {1}", proj, map[guid]);
        }
        map[guid] = proj;

        AddReferences(ns, doc);
        AddFramework(doc, ns);
        CleanupEmptyItemGroup(ns, doc);
/*
      if (doc.SelectNodes("m:Project/m:PropertyGroup/m:BasePath", ns).Count == 0)
      {
        var pg = doc.SelectNodes("m:Project/m:PropertyGroup", ns).Cast<XmlElement>().First();

        var basePath = doc.CreateElement("BasePath", NS);
        basePath.InnerText = "
      }
*/

        PatchProductVersion(ns, doc);
        PatchProductVersion2(ns, doc);
        AddBasePath(ns, doc);
        UpdateImport(ns, doc, proj);

        doc.Save(proj);
//        Console.Out.WriteLine(proj);
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
        node.InnerText = "\r\n    ";
        hasTarget = true;
      }

      if (!hasTarget)
      {
        var el = doc.CreateElement("TargetFrameworkProfile", NS);
        el.InnerText = "\r\n    ";
        AppendFirstPropertyGroup(doc, ns, el);
      }

      if (!hasFx)
      {
        var el = doc.CreateElement("TargetFrameworkVersion", NS);
        el.InnerText = "v4.0";
        AppendFirstPropertyGroup(doc, ns, el);
      }
    }

    private static XmlElement AppendFirstPropertyGroup(XmlDocument doc, XmlNamespaceManager ns, XmlElement el)
    {
      return (XmlElement) doc.SelectNodes("m:Project/m:PropertyGroup", ns).Cast<XmlElement>().First().AppendChild(el);
    }

    private static void PatchProductVersion(XmlNamespaceManager ns, XmlDocument doc)
    {
      foreach (XmlElement node in doc.SelectNodes("m:Project/m:PropertyGroup/m:ProductVersion", ns))
      {
        node.InnerText = "8.0.30703";
      }
    }
    
    private static void PatchProductVersion2(XmlNamespaceManager ns, XmlDocument doc)
    {
      foreach (var el in doc.SelectNodes("m:Project/m:PropertyGroup/ProductVersion", ns).Cast<XmlElement>().ToArray())
      {
        el.ParentNode.RemoveChild(el);
      }
      foreach (var el in doc.SelectNodes("m:Project/m:PropertyGroup/SchemaVersion", ns).Cast<XmlElement>().ToArray())
      {
        el.ParentNode.RemoveChild(el);
      }

      if (doc.SelectNodes("m:Project/m:PropertyGroup/m:ProductVersion", ns).Count == 0)
      {
        var el = doc.CreateElement("ProductVersion", NS);
        el.InnerText = "8.0.30703";
        AppendFirstPropertyGroup(doc, ns, el);
      }

      if (doc.SelectNodes("m:Project/m:PropertyGroup/m:SchemaVersion", ns).Count == 0)
      {
        var el = doc.CreateElement("SchemaVersion", NS);
        el.InnerText = "2.0";
        AppendFirstPropertyGroup(doc, ns, el);
      }
    }

    private static void AddBasePath(XmlNamespaceManager ns, XmlDocument doc)
    {
      foreach (var el in doc.SelectNodes("m:Project/m:PropertyGroup/m:BasePath", ns).Cast<XmlElement>().ToArray())
      {
        el.ParentNode.RemoveChild(el);
      }

      var element = doc.CreateElement("BasePath", NS);
      element.InnerText = "$(MSBuildProjectDirectory)\\..\\";
      AppendFirstPropertyGroup(doc, ns, element);      
    }

    private static void UpdateImport(XmlNamespaceManager ns, XmlDocument doc, string proj)
    {
      foreach (var name in new[] { "Before.Build.Targets", "After.Build.Targets" })
      {
        var before =
          (XmlElement) doc.SelectSingleNode("m:Project/m:Import[@Project='../" + name + "']", ns)
          ??
          (XmlElement) doc.SelectSingleNode("m:Project/m:Import[@Project='..\\" + name + "']", ns)
          ??
          (XmlElement) doc.SelectSingleNode("m:Project/m:Import[@Project='$(BasePath)\\" + name + "']", ns)
          ??
          (XmlElement) doc.SelectSingleNode("m:Project/m:Import[@Project='$(BasePath)/" + name + "']", ns);

        if (before == null)
        {
          Console.Out.WriteLine("Failed to patch path for " + proj);
        }
        else
        {
          before.SetAttribute("Project", "$(BasePath)\\" + name);
        }
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
