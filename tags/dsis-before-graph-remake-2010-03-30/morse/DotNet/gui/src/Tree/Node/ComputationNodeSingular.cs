using gui.Tree.Node.Action;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Menu;
using gui.Tree.Node.Util;
using MorseKernelATL;

namespace gui.Tree.Node
{
	/// <summary>
	/// Summary description for ComputationNodeSingular.
	/// </summary>
	public class ComputationNodeSingular : ComputationNode
	{
		public ComputationNodeSingular(IKernelNode node) : base(node)
		{
			//ComputationNodeDynamicTest.ComputationNodeDynamicTestResult res = ComputationNodeDynamicTest.parseNode(node);
			//this.items = res.items;
			this.actions = DynamicActionNodeTest.Instance.CreateAction(this);
			this.Text = generateCaption(node);
		}

		//private ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[]{};
		private ComputationNodeAction[] actions;

		protected override ComputationNodeMenuItem[] getMenuItems()
		{
			return fromActions(actions);
		}

		#region generate Caption methods

		private string generateCaption(IKernelNode mnode)
		{
			string result = "";
			if (mnode is IGraph)
			{
				IGraph node = (IGraph) mnode;
				InfoGraphParser parser = new InfoGraphParser(node.graphInfo());
				result = string.Format("Nodes : {0}, Edges : {1}", parser.Nodes, parser.Edges);

				if (mnode is CSymbolicImageGraph) result = "Symbolic Image. " + result;
				else if (mnode is CSymbolicImageGroup) result = "Symbolic Image Group. " + result;
				else if (mnode is CProjectiveBundleGraph) result = "Projective Bundle. " + result;
				else if (mnode is CProjectiveBundleGroup) result = "Projective Bundle Group. " + result;
			}
			else if (mnode is CMorseSpectrum)
			{
				CMorseSpectrum node = (CMorseSpectrum) mnode;
				result = string.Format("Morse Spectrum estimation: [{0}, {1}]", node.lowerBound, node.upperBound);
			}
			return result;
		}

		#endregion
	}
}