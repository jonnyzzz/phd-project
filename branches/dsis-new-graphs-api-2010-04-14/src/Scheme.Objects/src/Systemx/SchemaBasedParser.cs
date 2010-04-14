using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DSIS.Scheme2.ObjectParsers;
namespace DSIS.Scheme.Objects.Systemx
{
  //TODO:!!!
  [Obsolete("What's this?")]
  public abstract class SchemaBasedParser<T, R>
  {
    private readonly XmlSchema mySchema;

    [Obsolete]
    internal protected SchemaBasedParser(ObjectParserFactory factory, string schema) 
    {      
    }

    protected SchemaBasedParser(ObjectParserFactory factory, Type @namespace, string schema)
    {
      mySchema = LoadSchema(@namespace.Namespace + "." + schema);
    }

    public R Parse(XmlElement element)
    {
      if (element.NamespaceURI != mySchema.TargetNamespace)
        return default(R);

      element.OwnerDocument.Schemas.Add(mySchema);

      var ser = new XmlSerializer(typeof(T));

      var settings = new XmlReaderSettings();
      settings.ValidationType = ValidationType.Schema;
      settings.Schemas.Add(mySchema);

      using (XmlReader reader = XmlReader.Create(new XmlNodeReader(element), settings))
      {
        return Parse((T)ser.Deserialize(reader));        
      }                  
    }

    private XmlSchema LoadSchema(string name)
    {
      using (Stream str = GetType().Assembly.GetManifestResourceStream(name))
        return XmlSchema.Read(str, null);
    }

    protected abstract R Parse(T obj);
  }
}