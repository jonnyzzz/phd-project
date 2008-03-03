using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DSIS.Core.System.Impl;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme.Objects.Systemx
{
  [UsedBySpring]
  public class SystemSpaceParser : IObjectParser
  {
    private XmlSchema GetSchema()
    {
      using (Stream str = GetType().Assembly.GetManifestResourceStream(typeof(NamespaceHolder), "resources.SystemSpace.xsd"))
        return XmlSchema.Read(str, null);
    }

    public object Parse(XmlElement element)
    {
      XmlSchema schema = GetSchema();
      element.OwnerDocument.Schemas.Add(schema);            
      
      XmlSerializer ser = new XmlSerializer(typeof(XsdSystemSpace));

      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ValidationType = ValidationType.Schema;
      settings.Schemas.Add(schema);

      using(XmlReader reader = XmlReader.Create(new XmlNodeReader(element), settings))
      {                
        XsdSystemSpace space = (XsdSystemSpace) ser.Deserialize(reader);
        return new DefaultSystemSpace(space.Dimension, space.LeftPoint, space.RightPoint, space.Division);
      }            
    }
  }
}