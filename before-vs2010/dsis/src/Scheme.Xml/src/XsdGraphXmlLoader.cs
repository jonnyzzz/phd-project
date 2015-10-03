using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DSIS.Scheme.Xml
{
  public class XsdGraphXmlLoader
  {
    public Graphs Load(Assembly assembly, string resource)
    {
      return Parse(Stream(assembly, resource));
    }

    private static Stream Stream(Assembly assembly, string name)
    {
      try
      {
        var stream = assembly.GetManifestResourceStream(name);
        if (stream == null)
          throw new ArgumentException("Resourece was not found");
        return stream;
      }
      catch (Exception e)
      {
        DumpResources(assembly);
        throw new Exception(e.Message, e);
      }
    }

    private static void DumpResources(Assembly assembly)
    {
      foreach (string resourceName in assembly.GetManifestResourceNames())
      {
        Console.Out.WriteLine("resourceName = {0}", resourceName);
      }
    }

    private static XmlSchema Schema
    {
      get
      {
        using (
          var str = typeof(XsdGraphBuilder).Assembly.GetManifestResourceStream(
            "DSIS.Scheme.Xml.resources.computation-graph-scheme-xml.xsd"))
        {
          if (str == null)
            throw new Exception("Failed to load xsd");
          return XmlSchema.Read(str, null);
        }
      }
    }

    private static Graphs Parse(Stream stream)
    {
      var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
      settings.Schemas.Add(Schema);

      // Load the AllAssembliesXml, validating against the schema
      Graphs graph;
      using (XmlReader xmlrValidating = XmlReader.Create(stream, settings))
        graph = (Graphs)new XmlSerializer(typeof(Graphs)).Deserialize(xmlrValidating);

      return graph;
    }
  }
}