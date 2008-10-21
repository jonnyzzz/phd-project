using System.Collections.Generic;
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

    public static XmlElement CreateRootElement(this XmlDocument node, string name)
    {
      return (XmlElement) node.AppendChild(node.CreateElement(name));
    }

    public static XmlNode CreateText(this XmlNode node, params string[] text)
    {
      return CreateText(node, (IEnumerable<string>) text);
    }
    public static XmlNode CreateText(this XmlNode node, IEnumerable<string> text)
    {
      bool isFirst = true;
      var nodes = new List<XmlNode>();
      foreach (var xmlNode in text)
      {
        if (!isFirst)
        {
          nodes.Add(node.OwnerDocument.CreateElement("br"));
        } else
        {
          isFirst = false;
        }
        nodes.Add(node.OwnerDocument.CreateTextNode(xmlNode));
      }
      nodes.Each(x=>node.AppendChild(x));
      return node;
    }
    
    public static XmlElement CreateChildElement(this XmlNode node, string name, string xsi)
    {
      return (XmlElement) node.AppendChild(node.OwnerDocument.CreateElement(name, xsi));
    }
  }
}