using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DSIS.Scheme.XmlModel
{
  public class GraphModel
  {
    private static XmlSchema Schema
    {
      get
      {
        using(Stream str = typeof(GraphModel).Assembly.GetManifestResourceStream("DSIS.Scheme.XmlModel.computation-graph-scheme.xsd"))
        {
          return XmlSchema.Read(str, null);
        }
      }
    }

    public ComputationScheme Parse(Stream stream)
    {
      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ValidationType = ValidationType.Schema;
      settings.Schemas.Add(Schema);

      // Load the AllAssembliesXml, validating against the schema
      ComputationScheme graph;
      using (XmlReader xmlrValidating = XmlReader.Create(stream, settings))
        graph = (ComputationScheme)new XmlSerializer(typeof(ComputationScheme)).Deserialize(xmlrValidating);

      return graph;
    }
  }
}
