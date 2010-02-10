using System;
using System.Windows.Forms;
using System.Xml;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernel2.Document;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Kernell2.Serialization;

namespace EugenePetrenko.Gui2.Application.Document
{
  /// <summary>
  /// Summary description for DocumentSerializer.
  /// </summary>
  public class DocumentSerializer
  {
    public static XmlNode SaveDocument(Document document, String pathBase)
    {
      XmlDocument doc = new XmlDocument();
      XmlNode rootNode = doc.CreateElement("document");

      XmlNode function = FunctionSerializer.SaveFunction(document.KernelDocument.Function);
      XmlUtil.AppendNode(doc, rootNode, function);

      XmlNode nodes = doc.CreateElement("nodes");
      rootNode.AppendChild(nodes);

      XmlNode commentNode = doc.CreateElement("comment");
      commentNode.InnerText = document.KernelDocument.Title;

      rootNode.AppendChild(commentNode);

      RecursiveSaveNodes(nodes, document.RootNode, doc, pathBase);

      return rootNode;
    }

    private static void RecursiveSaveNodes(XmlNode root, ComputationNode node, XmlDocument doc, string pathBase)
    {
      if (node == null) return;

      XmlNode internalNode = SaveNode(root, node, doc, pathBase);
      foreach (TreeNode treeNode in node.Nodes)
      {
        if (treeNode is ComputationNode || treeNode is ResultActionNameNode)
        {
          ComputationNode myNode = (ComputationNode) treeNode;
          RecursiveSaveNodes(internalNode, myNode, doc, pathBase);
        }
      }
    }

    private static XmlNode SaveNode(XmlNode root, ComputationNode cNode, XmlDocument doc, string pathBase)
    {
      XmlNode myNode = doc.CreateElement("node");
      root.AppendChild(myNode);

      XmlAttribute infoNode = doc.CreateAttribute("type");

      if (cNode is Node)
      {
        Node node = (Node) cNode;

        infoNode.Value = "node";
        XmlAttribute attr = doc.CreateAttribute("iterations");
        attr.Value = node.Iterations.ToString();

        myNode.Attributes.Append(attr);

        myNode.AppendChild(KernelNodeSerializer.SaveKernelNode(node.KernelNode, doc, pathBase));
      }
      else if (cNode is ResultActionNameNode)
      {
        ResultActionNameNode node = (ResultActionNameNode) cNode;
        infoNode.Value = "info";
        XmlAttribute attr = doc.CreateAttribute("caption");
        attr.Value = node.NodeCaption;
        myNode.Attributes.Append(attr);
      }

      myNode.Attributes.Append(infoNode);
      return myNode;
    }


    public static Document LoadDocument(XmlNode root, string pathBase)
    {
      XmlNode myNode = root.SelectSingleNode("/document");

      Function function = FunctionSerializer.LoadFunction(myNode);

      XmlNode resultsetNode = myNode.SelectSingleNode("nodes/node");

      ComputationNode treeNode = LoadNodeTree(resultsetNode, pathBase);

      Document doc = new Document(function, (Node) treeNode);

      XmlNode myCommentText = myNode.SelectSingleNode("comment/text()");
      if (myCommentText != null)
      {
        doc.KernelDocument.Title = myCommentText.Value;
      }

      return doc;
    }

    private static ComputationNode LoadNodeTree(XmlNode node, string pathBase)
    {
      ComputationNode treeNode = LoadOnlyNode(node, pathBase);
      foreach (XmlNode xmlNode in node.SelectNodes("node"))
      {
        treeNode.AddNodeChild(LoadNodeTree(xmlNode, pathBase));
      }
      return treeNode;
    }

    private static ComputationNode LoadOnlyNode(XmlNode node, string pathBase)
    {
      XmlAttribute isResult = node.Attributes["type"];
      if (isResult == null || isResult.Value == "node")
      {
        KernelNode kernelNode = KernelNodeSerializer.LoadKernelNode(node, pathBase);

        XmlNode aNode = node.SelectSingleNode("@iterations");
        return new Node(kernelNode, (aNode != null) ? int.Parse(aNode.Value) : 1);
      }
      else if (isResult.Value == "info")
      {
        return new ResultActionNameNode(node.Attributes["caption"].Value);
      }
      else throw new ArgumentException("Wrong XML format");
    }
  }
}