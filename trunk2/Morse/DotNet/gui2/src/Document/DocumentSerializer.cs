using System;
using System.Windows.Forms;
using System.Xml;
using gui2.TreeNodes;
using guiKernel2.Document;
using guiKernel2.Node;
using guiKernel2.Serialization;

namespace gui2.src.Document
{
	/// <summary>
	/// Summary description for DocumentSerializer.
	/// </summary>
	public class DocumentSerializer
	{
	
		public static XmlNode SaveDocument(gui2.Document.Document document, String pathBase)
		{
			XmlDocument doc = new XmlDocument();
			XmlNode rootNode = doc.CreateElement("document");

			XmlNode function = FunctionSerializer.SaveFunction(document.KernelDocument.Function);
			XmlUtil.AppendNode(doc, rootNode, function);			

			XmlNode nodes = doc.CreateElement("nodes");
			rootNode.AppendChild(nodes);

			RecursiveSaveNodes(nodes, document.RootNode, doc, pathBase);

			return rootNode;
		}

		private static void RecursiveSaveNodes(XmlNode root, Node node, XmlDocument doc, string pathBase)
		{	
			if (node == null) return;

			XmlNode internalNode = SaveNode(root, node, doc, pathBase);
			foreach (TreeNode treeNode in node.Nodes)
			{
				if (treeNode is Node)
				{
					Node myNode = (Node)treeNode;
					RecursiveSaveNodes(internalNode, myNode, doc, pathBase);
				}
			}
		}

		private static XmlNode SaveNode(XmlNode root, Node node, XmlDocument doc, string pathBase)
		{
			XmlNode myNode = doc.CreateElement("node");
			root.AppendChild(myNode);

			myNode.AppendChild(KernelNodeSerializer.SaveKernelNode(node.KernelNode, doc, pathBase ));					

			return myNode;
		}



		public static gui2.Document.Document LoadDocument(XmlNode root, string pathBase)
		{
			XmlNode myNode = root.SelectSingleNode("/document");

			Function function = FunctionSerializer.LoadFunction(myNode);

			XmlNode resultsetNode = myNode.SelectSingleNode("nodes/node");

			Node treeNode = LoadNodeTree(resultsetNode, pathBase);

			return new gui2.Document.Document(function, treeNode);
		}

		private static Node LoadNodeTree(XmlNode node, string pathBase)
		{
			Node treeNode = LoadOnlyNode(node, pathBase);
			foreach (XmlNode xmlNode in node.SelectNodes("node"))
			{
				treeNode.AddNodeChild(LoadNodeTree(xmlNode, pathBase));				
			}
			return treeNode;
		}

		private static Node LoadOnlyNode(XmlNode node, string pathBase)
		{
			KernelNode kernelNode = KernelNodeSerializer.LoadKernelNode(node, pathBase);

			return new Node(kernelNode);
		}

	}
}
