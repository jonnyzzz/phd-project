using System.Xml;

namespace EugenePetrenko.Gui2.Application.Document
{
  /// <summary>
  /// Summary description for XmlUtil.
  /// </summary>
  public static class XmlUtil
  {
    public static XmlDocument CreateEmptyDocument()
    {
      var document = new XmlDocument();
      document.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
      return document;
    }

    public static XmlNode SetRootNode(XmlDocument document, XmlNode newNode)
    {
      XmlNode node = document.ImportNode(newNode, true);
      document.AppendChild(node);
      return node;
    }

    public static XmlNode AppendNode(XmlDocument document, XmlNode node, XmlNode toAppend)
    {
      XmlNode anode = document.ImportNode(toAppend, true);
      node.AppendChild(anode);
      return node;
    }
  }
}