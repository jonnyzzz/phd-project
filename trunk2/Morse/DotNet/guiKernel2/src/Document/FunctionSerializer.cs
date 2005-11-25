using System.Collections;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Document;

namespace EugenePetrenko.Gui2.Kernel2.Document
{
    /// <summary>
    /// Summary description for FunctionSerializer.
    /// </summary>
    public class FunctionSerializer
    {
        public static Function LoadFunction(XmlNode aNode)
        {
            ArrayList equations = new ArrayList();
            foreach (XmlNode node in aNode.SelectNodes("function/equation/text()"))
            {
                equations.Add(node.Value);
            }

            return new Function((string[]) equations.ToArray(typeof (string)));
        }

        public static XmlNode SaveFunction(Function function)
        {
            XmlDocument doc = new XmlDocument();
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