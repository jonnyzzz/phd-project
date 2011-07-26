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

        XmlElement addParent = null;
        var assemblies = new HashSet<string>{
          "System",
          "System.Core",
          "System.Xml.Linq",
          "System.Data.DataSetExtensions",
          "System.Data",
          "System.Xml"};
        foreach (XmlAttribute attr in doc.SelectNodes("m:Project/m:ItemGroup/m:Reference/@Include", ns))
        {
          assemblies.Remove(attr.Value);
          XmlNode p = attr.OwnerElement;
          for (; p != null && !(p is XmlElement); p = p.ParentNode) ;
          if (p != null)
            addParent = (XmlElement) p;
        }

        if (addParent == null)
        {
          var ancor = doc.SelectNodes("m:Project/m:Import", ns).Cast<XmlElement>().First();
          var el = doc.CreateElement("ItemGroup", NS);
          addParent = (XmlElement) ancor.ParentNode.InsertBefore(el, ancor);
        }

        if (assemblies.Count == 0) continue;

        foreach (var assembly in assemblies)
        {
          var el = doc.CreateElement("Reference", NS);
          el.SetAttribute("Include", assembly);
          addParent.AppendChild(el);
        }

        doc.Save(proj);
        Console.Out.WriteLine(proj);
      }
    }
  }
}
