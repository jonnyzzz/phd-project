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
      element.OwnerDocument.Schemas.Add(GetSchema());
      
      XmlSerializer ser = new XmlSerializer(typeof(XsdSystemSpace));
      XsdSystemSpace space = (XsdSystemSpace) ser.Deserialize(new XmlNodeReader(element));
      
      return new DefaultSystemSpace(space.Dimension, space.LeftPoint, space.RightPoint, space.Division);
    }
  }
}