using System;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using gui.Visualization.JonATL;

namespace gui.Tree.Node.Action
{
	public class ComputationNodeVisualizer3D : ComputationNodeAction
	{
		private IntPtr graph;

		public ComputationNodeVisualizer3D(IntPtr graph) : base()
		{
			this.graph = graph;
			menus = new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.VisualizeAction(new ComputationNodeMenuFactory.UniversalMenuItemClick(visualize)),
				};
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return menus;
		}

		private ComputationNodeMenuItem[] menus;

		public void visualize()
		{
			Visualization3D vis = new Visualization3D();
			vis.ShowMe(graph);
		}
	}
}