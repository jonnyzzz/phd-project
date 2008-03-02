using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DSIS.Scheme2.XmlModel
{
  public class SchemeGraphLoader
  {
    private static XmlSchema Schema
    {
      get
      {
        using(Stream str = typeof(SchemeGraphLoader).Assembly.GetManifestResourceStream("DSIS.Scheme2.src.XmlModel.computation-graph-scheme.xsd"))
        {
          return XmlSchema.Read(str, null);
        }
      }
    }

    public XsdComputationScheme Parse(Stream stream)
    {
      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ValidationType = ValidationType.Schema;
      settings.Schemas.Add(Schema);

      // Load the AllAssembliesXml, validating against the schema
      XsdComputationScheme graph;
      using (XmlReader xmlrValidating = XmlReader.Create(stream, settings))
        graph = (XsdComputationScheme)new XmlSerializer(typeof(XsdComputationScheme)).Deserialize(xmlrValidating);

      return graph;
    }
  }
}