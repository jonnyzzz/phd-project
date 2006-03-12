using System.Collections;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
	/// <summary>
	/// Summary description for NodeResultSet.
	/// </summary>
	public class NodeResultSet : ResultSet
	{
		private bool hasSameParent = true;
		private bool hasSameGraphs = true;

		public NodeResultSet(Node[] nodes)
		{
			Node parent = GetNodeParent( nodes[0]);
			foreach (Node node in nodes)
			{
				if (GetNodeParent(node) != parent)
					hasSameParent = false;
				if (!HasEqualsGraph(this, node.ResultSet))
					hasSameGraphs = false;
				AddResultSetEx(node.ResultSet);
			}
		}

		public Node GetNodeParent(ComputationNode node) 
		{
			node = node.Parent as ComputationNode;
			while (node != null && !(node is Node))
				node = node.Parent as ComputationNode;
			return (Node)node;
		}

		public bool HasSameParent
		{
			get { return hasSameParent; }
		}

		public bool HasSameGraphs
		{
			get { return hasSameGraphs; }
		}
	}
}
