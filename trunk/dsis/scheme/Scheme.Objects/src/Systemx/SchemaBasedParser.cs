using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring.Util;

namespace DSIS.Scheme.Objects.Systemx
{
  public abstract class SchemaBasedParser<T, R> : Registrar<IObjectParser, ObjectParserFactory>, IObjectParser
  {
    private readonly XmlSchema mySchema;

    protected SchemaBasedParser(ObjectParserFactory factory, string schema) : base(factory)
    {
      mySchema = LoadSchema(schema);
    }

    object IObjectParser.Parse(XmlElement element)
    {
      return Parse(element);
    }

    public R Parse(XmlElement element)
    {
      if (element.NamespaceURI != mySchema.TargetNamespace)
        return default(R);

      element.OwnerDocument.Schemas.Add(mySchema);

      XmlSerializer ser = new XmlSerializer(typeof(T));

      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ValidationType = ValidationType.Schema;
      settings.Schemas.Add(mySchema);

      using (XmlReader reader = XmlReader.Create(new XmlNodeReader(element), settings))
      {
        return Parse((T)ser.Deserialize(reader));        
      }                  
    }

    private static XmlSchema LoadSchema(string name)
    {
      using (Stream str = typeof(NamespaceHolder).Assembly.GetManifestResourceStream(typeof(NamespaceHolder), name))
        return XmlSchema.Read(str, null);
    }

    protected abstract R Parse(T obj);
  }
}