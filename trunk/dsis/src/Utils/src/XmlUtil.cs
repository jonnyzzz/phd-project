using System.Xml;

namespace DSIS.Utils
{
  public static class XmlUtil
  {
    public static void CreateAttribute(this XmlNode node, string attribute, string value)
    {
      var attr = node.OwnerDocument.CreateAttribute(attribute);
      attr.Value = value;
      node.Attributes.Append(attr);
    }

    public static void CreateAttribute(this XmlNode node, string attribute, string xsi, string value)
    {
      var attr = node.OwnerDocument.CreateAttribute(attribute, xsi);
      attr.Value = value;
      node.Attributes.Append(attr);
    }

    public static XmlElement CreateChildElement(this XmlNode node, string name)
    {
      return (XmlElement) node.AppendChild(node.OwnerDocument.CreateElement(name));
    }
    
    public static XmlElement CreateChildElement(this XmlNode node, string name, string xsi)
    {
      return (XmlElement) node.AppendChild(node.OwnerDocument.CreateElement(name, xsi));
    }
  }
}