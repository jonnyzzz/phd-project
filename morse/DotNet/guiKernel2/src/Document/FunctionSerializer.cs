using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Document;
using System.Linq;

namespace EugenePetrenko.Gui2.Kernel2.Document
{
  /// <summary>
  /// Summary description for FunctionSerializer.
  /// </summary>
  public class FunctionSerializer
  {
    private static string[] LoadFunctionContent(XmlNode aNode)
    {
      if (aNode == null)
      {
        throw new FunctionExceptions("Failed to load function. Wrong xml format");
      }
      XmlNodeList nodes = aNode.SelectNodes("function/equation/text()");
      if (nodes == null)
      {
        return new string[0];
      }

      return nodes.OfType<XmlNode>().Select(x => x.Value).Where(x => x != null).Select(x => x.Trim()).ToArray();
    }

    public static Function LoadFunction(XmlNode aNode)
    {
      return new Function(LoadFunctionContent(aNode));
    }

    public static XmlNode SaveFunction(Function function)
    {
      var doc = new XmlDocument();
      XmlNode newNode = doc.CreateElement("function");

      foreach (string equation in function.Equations)
      {
        XmlNode equationNode = doc.CreateElement("equation");
        equationNode.AppendChild(doc.CreateTextNode(equation));
        newNode.AppendChild(equationNode);
      }

      return newNode;
    }
  }
}