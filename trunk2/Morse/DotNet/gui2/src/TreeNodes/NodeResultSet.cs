using System.Collections;
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
			Node parent = (Node) nodes[0].Parent;
			foreach (Node node in nodes)
			{
				if (node.Parent != parent)
					hasSameParent = false;
				if (!HasEqualsGraph(this, node.ResultSet))
					hasSameGraphs = false;
				AddResultSetEx(node.ResultSet);
			}
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
